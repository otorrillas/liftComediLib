/// <summary>
/// Methods and constants imported from the native shared library libelev.so
/// Remember to copy 'libelev.so' to the output directory, e.g. bin/Release/
/// </summary>
using System;
using System.Runtime.InteropServices;
namespace Elev
{
    /// Motor direction for function Set.MotorDirection().
    public static class Dirn
    {
    	public const int Down = -1;
    	public const int Stop = 0;
    	public const int Up = 1;
    }
    /// Button types for function Set.ButtonLamp() and Get.ButtonSignal()
    public static class Button
    {
    	public const int Up = 0;
    	public const int Down = 1;
    	public const int Command = 2;
    }
    /// Other constants
    public static class C
    {
    	public const int nFloors = 4;
    	public const int nButtons = 3;
    }
    /// Methods imported from libelev.so
    public static class LibElev
    {
    	[DllImport("libelev.so", EntryPoint = "elev_init")]
    	public static extern void Init();
    	
        public static class Set
        {
            /// <param name="dirn"> New direction of the elevator.</param>
            [DllImport("libelev.so", EntryPoint = "elev_set_motor_direction")]
            public static extern void MotorDirection(int dirn);

            /// <param name="button"> Which type of lamp to set. Can be Button.Up,
            /// Button.Down or Button.Command (button "inside" the elevator).</param>
            /// <param name="floor"> Floor of lamp to set. Must be 0-3.</param>
            /// <param name="value"> Non-zero value turns lamp on, 0 turns lamp off.</param>
            [DllImport("libelev.so", EntryPoint = "elev_set_button_lamp")]
            public static extern void ButtonLamp(int button, int floor, int value);

            /// <param name="floor"> Which floor lamp to turn on. Other floor lamps are turned off.</param>
            [DllImport("libelev.so", EntryPoint = "elev_set_floor_indicator")]
            public static extern void FloorIndicator(int floor);

            /// <param name="value"> Non-zero value turns lamp on, 0 turns lamp off.</param>
            [DllImport("libelev.so", EntryPoint = "elev_set_door_open_lamp")]
            public static extern void DoorOpenLamp(int value);

            /// <param name="value"> Non-zero value turns lamp on, 0 turns lamp off.</param>
            [DllImport("libelev.so", EntryPoint = "elev_set_stop_lamp")]
            public static extern void StopLamp(int value);
        }

        public static class Get
        {
            /// <returns> 0 if button is not pushed. 1 if button is pushed.</returns>
            /// <param name="button"> Which button type to check. Can be BUTTON_CALL_UP,
            /// BUTTON_CALL_DOWN or BUTTON_COMMAND (button "inside the elevator).</param>
            /// <param name="floor"> Which floor to check button. Must be 0-3.</param>
            [DllImport("libelev.so", EntryPoint = "elev_get_button_signal")]
            public static extern int ButtonSignal(int button, int floor);

            /// <returns> -1 if elevator is not on a floor. 0-3 if elevator is on floor. 0 is
            /// ground floor, 3 is top floor.</returns>
            [DllImport("libelev.so", EntryPoint = "elev_get_floor_sensor_signal")]
            public static extern int FloorSensorSignal();

            /// <returns> 1 if stop button is pushed, 0 if not.</returns>
            [DllImport("libelev.so", EntryPoint = "elev_get_stop_signal")]
            public static extern int StopSignal();

            /// <returns> 1 if obstruction is enabled. 0 if not.</returns>
            [DllImport("libelev.so", EntryPoint = "elev_get_obstruction_signal")]
            public static extern int ObstructionSignal();
        }
    }
}
