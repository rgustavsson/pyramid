# Visualisation of what happens when glasses are poured

```
glassesPoured = 1 (increments with every new glass that we simulate)

While ():

for r (loop from row 1, which is the top glass, down to the row that holds the glass that we want to fill)
currentRow: [1]
nextRow [0,0]
check overflow for every glass in current row: 
	currentRow[i] > 1 = overflow
	divide overflow between the two glasses bellow
set currentRow to nextRow that now contains all overflow from previous row
check so that we have hit desired row and glass, if its full calculate time 

```

getTimeToFill(3, 2) -> desired row = [X] [1] [X];

```
while 
  currentRow = [1] (pouring 1 glass)
	
  r = 1
	[0] [0]

	r = 2
	[0] [0] [0]
```

--> First glass does not pour down to the second row

```
while 
  currentRow = [2] (pouring 2 glasses)

	r = 1
	[0.5] [0.5]

	r = 2
	[0] [0] [0]
```

--> Second glass pours down to the second row, nothing to pour down to the third row

```
while 
	currentRow = [3] (pouring 3 glasses)

	r = 1
	[1] [1]

	r = 2
	[0] [0] [0]

```

--> Third glass does not pour down to the third row

```
while 
	currentRow = [4]  (pouring 4 glasses)

	r = 1
	[1.5] [1.5]

	r = 2
	[0.25] [0.25 + 0.25] [0.25]

```

--> Fourth glass pours down to the third row, nothing to pour down to the fourth row

```
while 
	currentRow = [5]  (pouring 5 glasses)

	r = 1
	[2] [2]

	r = 2
	[0.5] [0.5 + 0.5] [0.5]

```
--> Fifth glass pours down to the third row and fills the second glass on that row

Result:

```
  5 glasses
  10 sec each
  5 * 10 = 50 seconds to fill glass 2 on row 3
```
