# Computer Graphics Project
Eduardo (Main character)

The main character is a simple marble ball. I made the camera follow it around and the player moves in a direction relative to the camera view. We wanted to make the marble ball roll when the player moves but I encountered a problem. If the hierarchy of the player prefab was as such (Player(Empty) > Playerball / Main Camera) and the scripts as well as the rigidbody were on the playerball, the camera wouldn’t move(unless I made a separate script for the camera movement). So I added the scripts to the Empty Player instead. That led to another problem because the camera kept rotating with the player. I decided to ditch the rigidbody and instead used the Character Controller. It does not handle physics so I had to handle that in the code to make the ball rotate. I did so by getting the Playerball mesh and rotating it related to the distance travelled since the last frame. The following is the code for rolling the ball.



I also did the shader for the marble ball. The shader includes Ambient + Diffuse + Rim + Reflection and is also transparent. I tried making a distortion so that the objects appearing behind it would appear a little distorted as it usually happens with marble balls but it didn’t work well so I couldn’t implement it at this time. I’ll work to implement it by the end of the project though. 

I don’t think the ambient shader is working as intended. I haven’t figured out why yet but I am working on it.


The reflection works well. It reflects the light from the skybox onto the ball. There is a little distortion to the reflection though.

I plan on making the rim lighting reflect the world light. I haven’t tried to make it yet but if I can do that the ball will have a rim lighting that reflects the light it receives, so the bottom wouldn’t have any light while the top or side facing the light would.

I also tried to make flying texts that have rim light shaders on them to make them look neon or glitchy but I haven’t been able to make it look right. Instead of it becoming a neon type of text, it changes color depending on how you look at it.


I also did a day/night cycle with the game directional light by animating its rotation on the x-axis.

I also added a simple win/lose condition, the player just has to reach the platform before the time expires. I added a simple rim lighting to it to make it more visible.

I also made the script to toggle the shaders on and off for showcase. I made it by changing the important values of the shaders in order to turn them off.

When the key is pressed, all the shader properties are disabled. After that, the code turns on the shaders that are intended to be turned on.






Alexander (Marble ribbon, water shader)
In order to see the marble roll around, we needed an object inside of it. To do this, I added a ribbon as a child of the ball.

The ribbon has a lit shader with a texturemap, and a SineTime function that changes the color of the shader by subtracting from BaseColor.


I created a water shader by utilizing Tiling and Offset with Time. The surface type is set to be transparent. Since I don’t have a particular texture I want to use, I use gradient noise. There are two different color properties 

Andre Fiuza (3D artist)

Attempted to make a swaying grass effect. It got really confusing since I followed a video and nothing from our classes since we didn't learn about it yet. I struggled to understand how to just make a simple wave movement.


