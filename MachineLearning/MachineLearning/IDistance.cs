using System;
namespace MachineLearning
{
	public interface IDistance
	{
		double Between(int[] pixels, int[] pixels2);
	}
}

