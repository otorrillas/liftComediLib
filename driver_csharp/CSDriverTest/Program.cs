// Test equivalent to the main.c file at https://github.com/TTK4145/Project/blob/master/driver/main.c
using System;
namespace Elev.Test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            LibElev.Init();

            Console.WriteLine("Press stop button to stop elevator and exit program\n");

            LibElev.Set.MotorDirection(Dirn.Up);

            while (true)
            {
                // Change direction when we reach top/bottom floor
                if (LibElev.Get.FloorSensorSignal() == C.nFloors - 1)
                    LibElev.Set.MotorDirection(Dirn.Down);
                else if (LibElev.Get.FloorSensorSignal() == 0)
                    LibElev.Set.MotorDirection(Dirn.Up);

                // Stop elevator and exit program if the stop button is pressed
                if (LibElev.Get.StopSignal() != 0)
                {
                    LibElev.Set.MotorDirection(Dirn.Stop);
                    return;
                }
            }
        }
    }
}