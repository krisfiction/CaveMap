# CaveMap

making a cave map useing cellular automaton.

1. generate a map using 40% chance for each tile to be a wall
2. filter map
   * if 5 or more tiles around a tile are walls then that tile will become a wall
   * if 3 or less tiles around a tile are walls then that tile will become a floor
   * if 4 tiles around a tile are walls then the tile remains unchanged

# Keys Used
* f5 = create new map
* spacebar = run filter

# ToDo
* connect all void spaces

# Pictures
Initialize Map
![map1](/ReadMe/map1.png)
Pass 1
![map2](/ReadMe/map2.png)
Pass 2
![map3](/ReadMe/map3.png)
Pass 10
![map4](/ReadMe/map4.png)
