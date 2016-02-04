### io.py ###

import comedi as c
import channels as chan

c_con = None

def init():
	c_con = c.comedi_open('/dev/comedi0')

	if c_con == None:
		return 0

	status = 0
	for i in range(8):
		status |= c.dio_config(c_con, channel.PORT_1_SUBDEVICE, i + channel.PORT_1_CHANNEL_OFFSET, channel.PORT_1_DIRECTION)
    	status |= c.dio_config(c_con, channel.PORT_2_SUBDEVICE, i + channel.PORT_2_CHANNEL_OFFSET, channel.PORT_2_DIRECTION)
    	status |= c.dio_config(c_con, channel.PORT_3_SUBDEVICE, i + channel.PORT_3_CHANNEL_OFFSET, channel.PORT_3_DIRECTION)
    	status |= c.dio_config(c_con, channel.PORT_4_SUBDEVICE, i + channel.PORT_4_CHANNEL_OFFSET, channel.PORT_4_DIRECTION)
    
	return status == 0

def set_bit(bchannel):
	c.dio_write(c_con, bchannel >> 8, bchannel & 0xff, 1)

def clear_bit(bchannel):
	c.dio_write(c_con, bchannel >> 8, bchannel & 0xff, 0)

def read_bit(bchannel):
	data = 0
	c.dio_read(c_con, bchannel >> 8, bchannel & 0xff, data)
	return data

def write_analog(bchannel, value):
	c.data_write(c_con, bchannel >> 8, bchannel & 0xff, c.AREF_GROUND, value)

def read_analog(bchannel):
	data = 0
	c.data_read(c_con, bchannel >> 8, bchannel & 0xff, c.AREF_GROUND, data)
	return data