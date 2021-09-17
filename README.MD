The application was built on .Net Framework 4.6.1 as a WPF application.

It should be easily possible to extend the app for "Rectangle" and other Polygons by simply updating the enum **PrimitiveType** and the **JsonInputReader** class.
In order to be able to easily switch between different types of Input readers, IOC and dependency injection was implements with "Caliburn Micro" nuget library.

## RUN Instructions

The application can be launched by starting the "VectorGraphicsViewer.exe" in the [src](src) folder or by opening the source code in Visual Studio and building and running it.
A [sample_input](sample_input.json) file is attached.

