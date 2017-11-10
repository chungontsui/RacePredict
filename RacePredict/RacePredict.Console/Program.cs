using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacePredict.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			Repository r = new Repository();
			ScoreModel s = new ScoreModel();

			/*
			The following was obtained from 46408.csv
			 */

			string[] trainers = {	"Shaune Ritchie",
									"Graham Richardson & Gavin Parker",
									"Shelley Hale",
									"Trevor & Martin Cruz",
									"Phillip Stevens",
									"Stephanie Tierney",
									"Bill Pomare",
									"Murray Baker & Andrew Forsman" };

			string[] jockeys = {	"Samantha Collett",
									"Shaun McKay",
									"Mark Du Plessis",
									"Danielle Johnson",
									"Jasmine Fawcett",
									"Lynsey Satherley",
									"Anna Jones",
									"Michael Coleman"};

			List<Tuple<SearchType, string>> inputs = new List<Tuple<SearchType, string>>();

			

			for (int cnt = 0; cnt < trainers.Count(); cnt++)
			{
				inputs.Add(new Tuple<SearchType, string>(SearchType.Jockey, jockeys[cnt]));
				inputs.Add(new Tuple<SearchType, string>(SearchType.Trainer, trainers[cnt]));

				var result = s.GetCombineScore(inputs);

				System.Console.WriteLine($"{result.Item1}: {result.Item2}");

				inputs.Clear();
			}

			System.Console.ReadLine();
		}
	}
}
