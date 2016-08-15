using System;

namespace MachineLearning
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var distance = new ManhattanDistance();
			var classifier = new BasicClassifier(distance);
			var trainingPath = @"/Users/scampbell/CODE/fsharp_machineLearningBook/data/train.csv"; 
			var training = DataReader.ReadObservations(trainingPath);
			classifier.Train(training);
			var validationPath = @"/Users/scampbell/CODE/fsharp_machineLearningBook/data/test.csv";
			var validation = DataReader.ReadObservations(validationPath);

			var correct = Evaluator.Correct(validation, classifier);
			Console.WriteLine("Correctly Classifed: {0:P2}", correct);
			Console.ReadLine();
		}
	}
}
