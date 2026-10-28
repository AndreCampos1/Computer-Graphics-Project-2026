Shader "Unlit/HologramText"
{

    Properties

    {
        _BaseTex ("Font Texture", 2D) = "white" {}

        _BaseColor ("Base Color", Color) = (1, 1, 1, 1)   // Base color of the object

        _RimColor ("Rim Color", Color) = (0, 0.5, 0.5, 1) // Color for the rim light

        _RimPower ("Rim Power", Range(0.5, 8.0)) = 3.0    // Controls sharpness of rim lighting

        _Glow ("Glow Intensity", Float) = 2.0

    }

    SubShader

    {

        Tags { "RenderPipeline" = "UniversalRenderPipeline" "RenderType" = "Opaque" "Queue" = "Transparent" }

        Blend SrcAlpha One 
        ZWrite Off
        Cull Off

        Pass

        {

            HLSLPROGRAM

            #pragma vertex vert

            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes

            {

                float4 positionOS : POSITION;  // Object space position

                float3 normalOS : NORMAL;      // Object space normal

                float4 tangentOS : TANGENT;    // Tangent space for rim light calculations

                float2 uv : TEXCOORD0;

            };

            struct Varyings

            {

                float4 positionHCS : SV_POSITION; // Homogeneous clip-space position

                float3 viewDirWS : TEXCOORD1;     // View direction in world space

                float3 normalWS : TEXCOORD2;      // World space normal

                float2 uv : TEXCOORD0;

            };

            TEXTURE2D(_BaseTex);
            SAMPLER(sampler_BaseTex);

            CBUFFER_START(UnityPerMaterial)

                float4 _BaseColor;   // Base color property

                float4 _RimColor;    // Rim color property

                float _RimPower;     // Rim power property

                float _Glow;

                float4 _BaseTex_ST;

            CBUFFER_END

            Varyings vert(Attributes IN)

            {

                Varyings OUT;

                // Transform object space position to homogeneous clip-space position

                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);

                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseTex);

                // Transform object space normal to world space

                OUT.normalWS = normalize(TransformObjectToWorldNormal(IN.normalOS));

                // Calculate the view direction in world space (from the camera to the surface)

                float3 worldPosWS = TransformObjectToWorld(IN.positionOS.xyz);

                OUT.viewDirWS = normalize(GetCameraPositionWS() - worldPosWS);

                return OUT;

            }

            // Fragment Shader

            half4 frag(Varyings IN) : SV_Target

            {

                // Normalize the world space normal and view direction

                half3 normalWS = normalize(IN.normalWS);

                half3 viewDirWS = normalize(IN.viewDirWS);

                half textAlpha = SAMPLE_TEXTURE2D(_BaseTex, sampler_BaseTex, IN.uv).a;

                // Rim lighting calculation (using dot product between normal and view direction)

                half rimFactor = 1.0 - saturate(dot(viewDirWS, normalWS));

                half rimLighting = pow(rimFactor, _RimPower);

                // Combine rim lighting color with the base color

                half3 finalColor = _BaseColor.rgb + (_RimColor.rgb * rimLighting * _Glow);

                half finalAlpha = (_BaseColor.a + rimLighting) * textAlpha;

                return half4(finalColor, finalAlpha);

            }

            ENDHLSL

        }

    }

}
