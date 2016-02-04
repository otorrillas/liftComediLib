import comedi as c
import io as io
import channels as channel
import constants as const

class ElevInterface:
    
    def set_motor_direction(dirn):
    	if dirn == 0:
    		io.write_analog(channel.MOTOR, 0)
    	elif dirn > 0:
    		io.clear_bit(channel.MOTORDIR)
    		io.write_analog(channel.MOTOR, const.MOTOR_SPEED)
    	else:
    		io.set_bit(channel.MOTORDIR)
    		io.write_analog(channel.MOTOR, const.MOTOR_SPEED)

	
	def get_floor_sensor_signal():
		if io.read_bit(channel.SENSOR_FLOOR1):
			return 0
		elif io.read_bit(channel.SENSOR_FLOOR2):
			return 1
		elif io.read_bit(channel.SENSOR_FLOOR3):
			return 2
		elif io.read_bit(channel.SENSOR_FLOOR4):
			return 3
		else:
			return -1


    def __init__(self):
    	init_success = io.init()
    	assert init_success, "Unable to initialize elevator hardware!"

