# Pony Challenge

Challenge documentation : https://ponychallenge.trustpilot.com/index.html

## Implementation
   Solution is composed of 4 projects:
 - PonyChallenge.Client
 - PonyChallenge.Game
 - PonyChallenge.UI
 - PonyChallenge.Utils
 
#### PonyChallenge.Client
Library wraps communication with PonyChallenge server.


#### PonyChallenge.UI
Console application responsible for displaying game scenes.
Includes reading data from console and validate it. 

#### PonyChallenge.Utils
Library containing implementation of PriorityQueue, not mine :) 

#### PonyChallenge.Game
Library responsible for the game logic and player's strategy
This is the place where path finding strategies are implemented.

###### Random 
  - Generates random direction
###### Console input 
  - Gets directions from keyboard
###### BreadthFirstSearch
  - Uses BFS to discover the path between Pony and Endpoint. 
  - The algorithm is fast but doesn't guarantee shortest path
  - Domokun position is considered to have 4 walls around him
  - Sometimes domokun is blocking the path so an heuristic is use to stay away from him until path is clear again
  - Another strategy can be applied when domokun is blocking the way:
    - Discover cycles in graph 
    - Go there and wait for Domokun
    - Trick him to follow you in the cycle
    - Exist cycle when path is clear
###### Dijkstra
  - Uses Dijkstra path finding algorithm to discover shortest path to endpoint
  - The algorithm is slower but guarantees shortest path
  - Sometimes domokun is blocking the way and there is nothing that can be done
