# Computer Graphics Project
Eduardo (Main character)

The main character is a simple marble ball. I made the camera follow it around and the player moves in a direction relative to the camera view. We wanted to make the marble ball roll when the player moves but I encountered a problem. If the hierarchy of the player prefab was as such (Player(Empty) > Playerball / Main Camera) and the scripts as well as the rigidbody were on the playerball, the camera wouldn’t move(unless I made a separate script for the camera movement). So I added the scripts to the Empty Player instead. That led to another problem because the camera kept rotating with the player. I decided to ditch the rigidbody and instead used the Character Controller. It does not handle physics so I had to handle that in the code to make the ball rotate. I did so by getting the Playerball mesh and rotating it related to the distance travelled since the last frame. The following is the code for rolling the ball.

<img width="571" height="288" alt="Screenshot 2026-10-27 203511" src="https://github.com/user-attachments/assets/6e56021c-d5a0-4bd6-826b-d3460ec21edb" />

I also did the shader for the marble ball. The shader includes Ambient + Diffuse + Rim + Reflection and is also transparent. I tried making a distortion so that the objects appearing behind it would appear a little distorted as it usually happens with marble balls but it didn’t work well so I couldn’t implement it at this time. I’ll work to implement it by the end of the project though. 

<img width="817" height="298" alt="Screenshot 2026-10-27 204159" src="https://github.com/user-attachments/assets/6b47f6ee-49a1-4c6b-92dc-4e4b63b4e99b" />

I don’t think the ambient shader is working as intended. I haven’t figured out why yet but I am working on it.

<img width="1030" height="386" alt="Screenshot 2026-10-27 204238" src="https://github.com/user-attachments/assets/b11b6c08-86f5-495b-910d-4606f7064a8c" />

The reflection works well. It reflects the light from the skybox onto the ball. There is a little distortion to the reflection though.

<img width="637" height="277" alt="Screenshot 2026-10-27 204923" src="https://github.com/user-attachments/assets/ad748802-1e84-4e7b-9c6d-c4ee072d0033" />

I plan on making the rim lighting reflect the world light. I haven’t tried to make it yet but if I can do that the ball will have a rim lighting that reflects the light it receives, so the bottom wouldn’t have any light while the top or side facing the light would.

I also tried to make flying texts that have rim light shaders on them to make them look neon or glitchy but I haven’t been able to make it look right. Instead of it becoming a neon type of text, it changes color depending on how you look at it.

<img width="405" height="194" alt="Screenshot 2026-10-27 211527" src="https://github.com/user-attachments/assets/3d4a868d-2553-4457-a821-2735a739e626" />

I also did a day/night cycle with the game directional light by animating its rotation on the x-axis.

I also added a simple win/lose condition, the player just has to reach the platform before the time expires. I added a simple rim lighting to it to make it more visible.

I also made the script to toggle the shaders on and off for showcase. I made it by changing the important values of the shaders in order to turn them off.

<img width="402" height="146" alt="Screenshot 2026-10-27 213214" src="https://github.com/user-attachments/assets/c7a72865-a96b-4250-aa3c-05fddec6ac56" />

When the key is pressed, all the shader properties are disabled. After that, the code turns on the shaders that are intended to be turned on.
<img width="573" height="183" alt="Screenshot 2026-10-27 213501" src="https://github.com/user-attachments/assets/c2ca03a4-355e-4826-ab10-5e652b57a8b1" />
<img width="577" height="275" alt="Screenshot 2026-10-27 213537" src="https://github.com/user-attachments/assets/5128ee73-ad9c-4be5-bfa2-cc0e2d78166d" />
<img width="580" height="366" alt="Screenshot 2026-10-27 213546" src="https://github.com/user-attachments/assets/86fd0957-667c-423f-86b2-2169bb5f1510" />
<img width="607" height="192" alt="Screenshot 2026-10-27 213556" src="https://github.com/user-attachments/assets/109088f9-dc76-447b-9e6d-daac866d5724" />



Alexander (Marble ribbon, water shader)
In order to see the marble roll around, we needed an object inside of it. To do this, I added a ribbon as a child of the ball.

The ribbon has a lit shader with a texturemap, and a SineTime function that changes the color of the shader by subtracting from BaseColor.
<img width="299" height="115" alt="Screenshot_2026-10-28_002704" src="https://github.com/user-attachments/assets/bb7d8f61-59ca-4eb5-9ee0-ef161f7bfe10" />


I created a water shader by utilizing Tiling and Offset with Time. The surface type is set to be transparent. Since I don’t have a particular texture I want to use, I use gradient noise. There are two different color properties so that negative space isn't just white. 
<img width="925" height="570" alt="Screenshot_2026-10-28_011323" src="https://github.com/user-attachments/assets/c6c76b63-9a0d-4bdc-b7a8-d6551027e10b" />


Andre Fiuza (3D artist)

Attempted to make a swaying grass effect. It got really confusing since I followed a video and nothing from our classes, since we didn't learn about it yet. I struggled to understand how to make a simple wave movement, and it took too long so I gave up on it in order to focus on adding simple colors to the entire environment that I made in Blender. 
<img width="1358" height="618" alt="Screenshot 2026-10-28 010800" src="https://github.com/user-attachments/assets/fd80f9ac-40a3-4129-a455-0f9b01a76e78" />


