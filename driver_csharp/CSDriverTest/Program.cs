// Test equivalent to https://github.com/TTK4145/Project/blob/master/driver/main.c with some extras
using System;
using System.Threading.Tasks;
namespace Elev.Test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                ICar car = Elevator.GetElevator();
                IPanel panl = Elevator.GetPanel();

                // Extra: updating floor lights as the elevator passes by
                Task.Run(() =>
                {
                    while (true)
                    {
                        int floor = car.FloorSensorSignal;
                        if (floor != -1)
                            panl.FloorIndicator = floor;
                    }
                });

                // Extra: turning on button lights when pressed
                Task.Run(() =>
                {
                    while (true)
                    {
                        for(int floor=0; floor < Elevator.FloorCount; ++floor)
                            for(int button = 0; button < Elevator.ButtonCount; ++button)
                                if (panl.ButtonSignal[(Button)button, floor] == true)
                                    panl.ButtonLamp[(Button)button, floor] = true;
                    }
                });

                Console.WriteLine("Press stop button to stop elevator and exit program\n");

                car.MotorDirection = Direction.Up;

                while (true)
                {
                    // Change direction when we reach top/bottom floor
                    if (car.FloorSensorSignal == Elevator.FloorCount - 1)
                        car.MotorDirection = Direction.Down;
                    else if (car.FloorSensorSignal == 0)
                        car.MotorDirection = Direction.Up;

                    // Stop elevator and exit program if the stop button is pressed
                    if (car.StopSignal == true)
                    {
                        car.MotorDirection = Direction.Stop;
                        return;
                    }
                }
            }
            catch (DllNotFoundException)
            {
                Console.WriteLine("Put libelev.so in the same folder as your exe-file!\n");
                Console.Read(); // Prevent console from closing
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Read(); // Prevent console from closing
            }
        }
    }
}