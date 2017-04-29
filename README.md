# SmartRedMotionServer
Server program for SmartRedMotion project

It connects to ATMega via serial port and gets information whether is there any movement in room. If there's no movement for chosen amount of time, it sends TCP packets to all previously chosen computers with SmartRedMotionClient program and the client shuts them down.
