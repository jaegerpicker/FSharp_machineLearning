using System;
using System.Collections.Generic;
using System.Linq;
namespace MachineLearning
{
	public class Evaluator
	{
		private static double current = 0.0;
		private static double total = 0.0;
		public static double Correct(IEnumerable<Observation> validationSet, IClassifier classifier)
		{
			total = (double)validationSet.ToList().Count;
			return validationSet.Select(obs => Score(obs, classifier)).Average();
		}

		private static double Score(Observation obs, IClassifier classifier)
		{
			current++;
			Console.WriteLine("Percent done: {0:P2} ", current / total);
			if (classifier.Perdict(obs.Pixels) == obs.Label)
			{
				return 1.0;
			}
			else {
				return 0.0;
			}
		}
		public Evaluator()
		{
		}
	}
}

