# RTS-Camera-Scripts

For the script to work, empty gameobjects such as:
CameraRoot, which is the parent CameraHolder, which is the parent of the main camera, must be created.

So in the end:

             CameraRoot
              CameraHolder
                MainCamera
               
All scripts apart from InputAxis must be placed on the CameraRoot.

You will also need to create an additional axis called "Horizontal QE" in the project settings 
(if you have a better name, great, I don't know how to name an axis that will read Q and E keys).
