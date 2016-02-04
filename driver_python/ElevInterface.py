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
    		io.write_analog(channel.MOTOR, const.MOTOr_SPEED)
    	else:
    		io.set_bit(channel.MOTORDIR)
    		io.write_analog(channel.MOTOR, const.MOTOr_SPEED)

	def set_button_lamp(button, floor, value):
		# CHECK: 
		# 	0 <= floors < N_FLOORS
		#	0 <= button < N_BUTTONS

		if value:
			io.set_bit(const.lamp_channel_matrix[floor][button])
		elif:
			io.clear_bit(const.lamp_channel_matrix[floor][button])

	def set_floor_indicator(floor):
		# CHECK: 
		# 	0 <= floors < N_FLOORS

		if floor & 0x02:
			io.set_bit(channel.LIGHT_FLOOR_IND1)
		else:
			io.clear_bit(channel.LIGHT_FLOOR_IND1)

		if floor & 0x01:
			io.set_bit(channel.LIGHT_FLOOR_IND2)
		else:
			io.clear_bit(channel.LIGHT_FLOOR_IND2)
	def set_door_open_lamp(value):

	def set_stop_lamp(value):

	def get_button_signal(button, floor):

	def get_floor_sensor_signal():

	def get_stop_signal():

	def get_obstruction_signal():


    def __init__(self):
    	# init_success = io.init()
