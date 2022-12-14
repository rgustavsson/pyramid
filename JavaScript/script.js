const getTimeToFill = function(row, glass) {
	if(row < 2 || row > 50) {
		console.log("Please pick a row between 1 and 51");
		return;
	}

	if(glass < 1 || glass > row) {
		console.log(`Please pick a glass between 0 and ${row + 1}. This range is based on your selected row.`);
		return;
	}

	const secondsToPourGlass = 10;
	let glassesPoured = 0;
	let duration = 0;
	let lastGlassValue = 0;
    
	while(!duration) {
		glassesPoured++;
		//console.log('Pour glass ' + glassesPoured);
		let currentRow = [glassesPoured];

		// We start pouring from the top and so with every pour we iterate from the first row down to the one we're aiming for
		for(let r = 1; r < row; r++) {
			
			let nextRow = Array(currentRow.length + 1).fill(0); // So that I can pour the overflow from current row to the next one
			
			for(let g = 0; g < currentRow.length; g++) { // For every glass in the row
				let overflow = Math.max(0, currentRow[g] - 1);
				if(overflow > 0) {
					nextRow[g] += overflow / 2;
					nextRow[g + 1] += overflow / 2;
				}
			}
			currentRow = nextRow;
		}
		
		if(currentRow.length === row && currentRow[glass - 1] >= 1) {
			// We've hit the desired row and my glass is full
			const glassOverflow = currentRow[glass - 1] - 1;
			const glassDiff = currentRow[glass - 1] - lastGlassValue;
			duration = glassesPoured * secondsToPourGlass - glassOverflow/glassDiff * secondsToPourGlass;
		}
		lastGlassValue = currentRow[glass - 1];
	}
    return duration;
};

const duration = getTimeToFill(5, 2);
if(duration) {
	console.log(`Duration: ${Math.round(duration * 1000) / 1000}s`);
}

function execute() {
	var row = document.getElementById("row")?.valueAsNumber;
	var glass = document.getElementById("glass")?.valueAsNumber;
	const duration = getTimeToFill(row, glass);
	alert(`${Math.round(duration * 1000) / 1000} seconds`)
}
