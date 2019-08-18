## **Section 10: Debugging Applications**

### **Debugging Tools in Visual Studio**

**Shortcuts**
* `F9`: Sets a breakpoint
* `F5`: Run in the debug mode
* `Ctrl + F5`: Run without debug mode
* `F10`: In debug mode, is step over
* `F11`: In debug mode, is step into
* `Shift + F11`: In debug mode, is step out
* `Shift + F5`: In debug mode, will run the rest of the application and stop the debug mode

The watch window will allow you to watch the variables as you step through the code. When a varialbe changes, it will be in red.

**Removing Side Effects**

**More Shorcuts**
* `Ctrl + Shift + F5`: Restart the application
* `Ctrl + Shift + F9`: Delete all the breakpoints

Side effects can come when manipulating the arguments passed into a method. It's best to make a copy of the data when manipulting it.

**Defensive Programming**

Check the input first before doing any processing, so you can catch any input errors.

A good programmer will think of edge cases.

**Call Stack Window**

The top is where you currently are and the bottom is where you started.

**Locals & Autos Window**

Autos window is like the watch, but automatically following all variables.
Locals is similar to autos, but doesn't list all of the different types of variables.