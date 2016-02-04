C++ driver
====

Objected-Oriented driver. It relies on two different objects:
- **ElevInterface**: responsible of handling the operations related with the elevator itself (e.g. changing motor direction).
- **PanelInterface**: responsible of handling the actions related with the control panel (e.g. powering on the floor indicator).

There is an example of *use* of both objects at **main.cpp**.
