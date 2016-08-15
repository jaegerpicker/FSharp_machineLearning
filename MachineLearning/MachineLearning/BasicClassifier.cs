using System;
using System.Collections.Generic;
using System.Linq;

namespace MachineLearning
{
	public class BasicClassifier : IClassifier
	{
		private IEnumerable<Observation> data;
		private readonly IDistance distance;
		public BasicClassifier(IDistance distance)
		{
			this.distance = distance;
		}

		public string Perdict(int[] pixels)
		{
			Observation currentBest = null;
			var shortest = Double.MaxValue;
			foreach (Observation ob in this.data)
			{
				var dist = this.distance.Between(ob.Pixels.Skip(1).ToArray(), pixels);
				if (dist < shortest)
				{
					shortest = dist;
					currentBest = ob;
				}
			}
			return currentBest.Label;
		}

		public void Train(IEnumerable<Observation> trainingSet)
		{
			this.data = trainingSet;
		}
	}
}

