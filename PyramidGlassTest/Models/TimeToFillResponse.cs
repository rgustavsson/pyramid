using PyramidGlassTest.Enums;

namespace PyramidGlassTest.Models
{
	public class TimeToFillResponse
	{
		public Status Status { get; set; }
		public ErrorCode? ErrorCode { get; set; }
		public double SecondsToFillGlass { get; set; }

	}
}
