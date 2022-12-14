using PyramidGlassTest.Models;

namespace PyramidGlassTest.Services
{
	public interface IGlassService
    {
		TimeToFillResponse GetTimeToFill(int row, int glass);
	}
}
