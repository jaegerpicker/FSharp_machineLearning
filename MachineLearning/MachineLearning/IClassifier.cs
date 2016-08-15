using System;
using System.Collections.Generic;
namespace MachineLearning
{
	public interface IClassifier
	{
		void Train(IEnumerable<Observation> trainingSet);
		string Perdict(int[] pixels);
	}
}

