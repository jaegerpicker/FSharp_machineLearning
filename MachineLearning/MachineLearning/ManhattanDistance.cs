using System;
namespace MachineLearning
{
	public class ManhattanDistance : IDistance
	{
		public double Between(int[] pixels, int[] pixels2)
		{
			if (pixels.Length != pixels2.Length)
			{
				throw new ArgumentException("Inconstitent Image Sizes");
			}

			var length = pixels.Length;
			var distance = 0;
			for (int i = 0; i < length; i++)
			{
				distance += Math.Abs(pixels[i] - pixels2[i]);
			}
			return distance;
		}
	}
}

