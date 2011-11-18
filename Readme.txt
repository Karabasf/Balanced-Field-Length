Release Notes)

Main status)
Orientation phase, pre-alpha

Planning)

Excel functionality
- Writing a more general method/code/class/.dll for the excel functionality
- Implement more functionality in the excel options

GUI
- Decoupling of the plane class
- Make a numeric textbox only
- ?

Plane class
- Decoupling with the GUI
- Abstract the plane further, to enhance modularity

Version information

Version 0.05)
- Remake for the GUI, GUI is now more user friendly

Note:
Airplane simulation and Excelsheet generation is not yet possible for this project.

Version 0.042)
- Excel functions rewritten and moved to another .dll file
- Extra functionality added in the Jetplane Class
- A more general approach is applied
- Code is revised and cleaned. Hardcoded sections are removed as much as possible

Version 0.04)

- Added more functionality to the Jetplane class. It is now able to return values when the user specifies a VFail. The following data is returned:
	* Time
	* Height
	* Distance
	* Velocity

- Added a button to generate .csv documents for the previous functionality. Format is as such:

	time ; velocity ; distance ; height

Version 0.03)

- Added more functionality for the excel automation:
	* Ability to input values for the VFail and their corresponding distances
	* Ability to plot the distances vs. VFail

- Improved the format of the aircraftdata generation

- Added a test button to test the passing of parameters to another form. Functionality will be expanded in the future.

Version 0.02)

- Added a comparison.dll. This file contains the method to deduce the BFL and the corresponding VDecision

- Orientation phase for excel interoperability/automation

- Added extra functionality, such as:
	*Added 'get' functions in the Jetplane class to retrieve parameters
	*Export .txt files for Aircraft/Simulation data
	*Export .txt files for the values of the distances for an aborted and a continued take off. These values are in meters

version 0.01)

- Jetplane Class made with the following functionality:
	* Ability to set (relevant) parameters
	* Ability to calculate several values 
	* Ability to calculate distance vs. VFail

- Basic GUI for testing, GUI shows the distance for an aborted and a continued take off vs. VFail

- Constructors made; basic contructor is already defined and equal to the 2 jet engine plane

 