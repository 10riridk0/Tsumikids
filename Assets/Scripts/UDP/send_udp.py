from __future__ import print_function
import socket
import time
from contextlib import closing

def main():
  host = '192.168.137.1'
  port = 4000
  count = 0
  
  sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
  with closing(sock):
    while True:
      #message = 'Hello world : {0}'.format(count).encode('utf-8')
      message = input("code=").encode('utf-8')
      print(message, flush = True)
      sock.sendto(message, (host, port))
      count += 1
      time.sleep(1)
  return

if __name__ == '__main__':
  main()
