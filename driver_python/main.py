import ElevInterface as elev
import PanelInterface as pan
import constants as const


def main():
    elevInt = elev.ElevInterface()
    panelInt = pan.PanelInterface()

    print "Press STOP button to stop elevator and exit program.\n"

    elevInt.set_motor_direction(const.DIRN_STOP)

    while True:
    	currFloor = elevInt.get_floor_sensor_signal()

    	if currFloor == (const.N_FLOORS - 1):
    		elevInt.set_motor_direction(const.DIRN_DOWN)
    		panelInt.set_floor_indicator(currFloor)
    	elif currFloor == 0:
    		elevInt.set_motor_direction(const.DIRN_UP)
    		panelInt.set_floor_indicator(currFloor)
    	elif currFloor > 0:
    		panelInt.set_floor_indicator(currFloor)

    	if panelInt.get_stop_signal():
    		elevInt.set_motor_direction(const.DIRN_STOP)
    		return 0


if __name__ == "__main__":
    main()