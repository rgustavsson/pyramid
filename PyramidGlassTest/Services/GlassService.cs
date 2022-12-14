using PyramidGlassTest.Models;

namespace PyramidGlassTest.Services
{
	public class GlassService : IGlassService
    {
		private readonly int secondsToPourGlass = 10;
		public TimeToFillResponse GetTimeToFill(int row, int glass)
        {
			if (row < 2 || row > 50)
			{
				return new TimeToFillResponse()
				{
					Status = Enums.Status.ERROR,
					ErrorCode = Enums.ErrorCode.INVALID_ROW_INPUT
				};
			}
			if (glass < 1 || glass > row)
			{
				return new TimeToFillResponse()
				{
					Status = Enums.Status.ERROR,
					ErrorCode = Enums.ErrorCode.INVALID_GLASS_INPUT
				};
			}

			int glassesPoured = 0;
			double duration = 0;
			double lastGlassValue = 0;

			while (duration == 0)
			{
				glassesPoured++;
				//Console.WriteLine($"Pour glass number {glassesPoured}");
				double[] currentRow = new double[] { glassesPoured };

				// We start pouring from the top and so with every pour we iterate from the first row down to the one we're aiming for
				for (var r = 1; r < row; r++)
				{
					var nextRow = new double[currentRow.Length + 1]; // Need this so that I can pour the overflow from current row to the next

					for (var g = 0; g < currentRow.Length; g++) // For every glass in the row
					{
						//Console.WriteLine($"Row {r}, glass {g + 1}");
						var glassValue = currentRow[g] - 1;
						double overflow = Math.Max(0, glassValue);
						if (overflow > 0)
						{
							//Console.WriteLine($"Overflow in glass is {overflow} so lets spread this onto the next row");
							nextRow[g] += overflow / 2;
							nextRow[g + 1] += overflow / 2;
						}
					}
					currentRow = nextRow;
				}

				if (currentRow.Length == row && currentRow[glass - 1] >= 1)
				{
					// We've hit the desired row and my glass is full
					double glassOverflow = currentRow[glass - 1] - 1;
					double glassDiff = currentRow[glass - 1] - lastGlassValue;
					duration = glassesPoured * secondsToPourGlass - glassOverflow / glassDiff * secondsToPourGlass;
				}
				lastGlassValue = currentRow[glass - 1];
			}
			if(duration > 0)
			{
				duration = Math.Round(duration, 3);
			}

			return new TimeToFillResponse() { Status = Enums.Status.SUCCESS, SecondsToFillGlass = duration };
		}
    }
}
