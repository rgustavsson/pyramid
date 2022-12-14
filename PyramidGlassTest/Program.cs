using PyramidGlassTest.Services;

var glassService = new GlassService();

int row = 5;
int glass = 2;
var result = glassService.GetTimeToFill(row, glass);
if (result.Status == PyramidGlassTest.Enums.Status.SUCCESS)
{
	Console.WriteLine($"Success! It takes {result.SecondsToFillGlass} seconds to fill glass {glass} on row {row}");
}
else
{
	Console.WriteLine($"Ouch! Something went wrong. Error code is {result.ErrorCode}, check it up!");
}
