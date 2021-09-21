# Custom-Blender-Unity-Import-Settings
Use a per-project custom Unity-BlenderToFBX.py. A custom one is included in this repository that fixes importing no UV by using the default export settings from Blender instead of custom ones that sometimes fail for some misic reason.

# How to install
In Unity go to Window > Package Manager, click on the + button, `Add package from git URL...` and paste:

> https://github.com/forestrf/Custom-Blender-Unity-Import-Settings.git

That's it.

# How to use
It works without doing anything else.
If you want to use your custom `Unity-BlenderToFBX.py` file, copy the original file (or the one included in this project) and paste it anywhere in the project inside your Assets folder. The script that does the magic will use the first file named
`Unity-BlenderToFBX.py` that it finds inside the Assets folder, and if none is found it will use the included one in this project.

# How it works
This script will replace the contents of the file `(unity installation folder)/Editor/Data/Tools/Unity-BlenderToFBX.py` with the one that you want when importing a model, and revert it back after the model has been imported.
The included replacement works by using the default export settings from Blender to fbx instead of the custom ones that Unity defined, fixing the problems with importing wrong UV.
