# Build an Apartment Starter Project

This project is part of [Udacity](https://www.udacity.com "Udacity - Be in demand")'s [VR Developer Nanodegree](https://www.udacity.com/course/vr-developer-nanodegree--nd017).

## Getting Started

To clone this project, download from Git:
```bash
git clone https://github.com/szelenka/UdacityVRApartment.git
```

The **Android** apk build file can be found in the **Build.zip** file in this repository.

When launched, the required globe will be to your left on top of the surface. To make the globe rotate, click the screen.

## Built With
- [Unity 2017.2.0f3](https://unity3d.com/unity/whats-new/unity-2017.2.0)
- [GVR Unity SDK v1.70.0](https://github.com/googlevr/gvr-unity-sdk/tree/v1.70.0)
- [Poly Toolkit for Unity v1.3.0](https://developers.google.com/poly/develop/toolkit-unity)

## Versioning

For the versions available, see the [tags on this repository](https://github.com/szelenka/UdacityVRApartment/tags). 

## Authors

- **Scott Zelenka** - *Initial work* 

## Artists

- Udacity VR Nanodegree assets
- Poly assets
	- Poly by Google
	- Kendra Chen
	- Stephen White
	- Francisco Hui
	- Jarlan Perez
	- Adam Marc Williams
	- Alex Safayan
	- Anastasiia Ku
	- Niels Glodny
	- Jason Oudshoorn
	- Gabriel Martzloff
	- Peter Simcoe
- Textures
	- http://lowendmac.com/2007/aggressively-stupid-the-story-behind-after-dark/
- Sounds
	- http://www.freesfx.co.uk/info/eula/

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Reflection

### How long it took to complete the project

It took about 10 days of periodic working 2-3 hours at a time to complete the project. A majority of that time was googling how to perform certain things in Unity. The largest timesink was trying to place the GameObjects exactly on top of one another. This eventually was answered with "[Vertex Snapping](https://docs.unity3d.com/Manual/PositioningGameObjects.html)"

### One thing you liked about the projecct

This project forced me to actually place and manipulate 3D models in the scene. It was open-ended which allowed for some creative feedom, and reinforced the concepts from the lectures.

### One thing that was particularly challenging about the project

Locating 3D models on the same scale! While the assets included in the project were designed to exist in the same universe, when importing assets from Poly, it quickly became apparent how difficult it is to locate 3D assets which all align to the same theme. This project ignored the need for creating consistent 3D models and assumes they'll be available, which is disapointing.

Another side-effect of importing some assets from Poly, was that there were some which did not have proper UV mapping. This allowed realtime lighting to cast shadows on them, but because the UV was missing and the version of Unity required to submit this project prevents Unity from dynamically generating them, whenever Baked Lighting was selected the shadows disapeared.

### Lighting

When altering the **Baked Resolution** between 2, 5, 40, 80 the resolution of the light and shadows increased. On the lower end, you could hardly see any shadows cast from the lights, while on the higher end you could see distinct shadows. It also took longer to "bake" the lighting with the higher resolution, and the resulting lightmap files grew larger.

When the lighting was compressed and the resolution was low, you could see a lot of artifacts but the filesize of the lightmap was significantly smaller than the uncompressed version.

### Performance

Running with the Unity Profiler on a Samsung Galaxy S6, the framerate was constantly below 16ms (60 fps). At times it would jump to 5-10ms (100-200 fps), with occasional spikes to 33ms (30 fps). The process which was consuming the most CPU was either "PostLateUpdate.FinishFrameRendering > Camera.Render > Drawing > Render.OpaqueGemoetry" which seems to be the simple render of the 3D assets in the scene, or "PostLateUpdate.PlayerSendFrameStarted > FrameEvents.XRBeginFrame > XR.WaitForGPU > XR.WaitForGPU" which according to google means the "VSync" process is waiting on access to a resource.

I tried adding some code to a "SettingsScript" in the Start() method, which should have locked this setting, but I wasn't able to see any significant performance change.