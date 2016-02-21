C# driver
====

Objected-oriented driver. Following elements are used to control the elevator:
- `Elev.ICar`: interface responsible for handling the operations related to the elevator car.
- `Elev.IPanel`: interface responsible for handling the actions related to the control panel.
- `Elev.Elevator`: class containing constants and static methods used to obtain objects implementing the aforementioned interfaces

There is an example of use of both interfaces in `Program.cs`. To run the program you need to compile it (e.g. using Microsoft Visual Studio or MonoDevelop) and make sure that the native library `libelev.so` is accessible for the executable file making use of the wrapper. To use the wrapper in your own program, simply add `LibElev.cs` to your project and copy `libelev.so` to the output directory.
