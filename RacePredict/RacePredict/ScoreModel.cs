using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RacePredict
{
	public class ScoreModel
	{
		Repository repo;
		public ScoreModel()
		{
			repo = new Repository();
		}

		public Tuple<string, decimal> GetScore(SearchType SType, string SearchString, int SearchPeriodDays = 0)
		{
			Tuple<string, decimal> result; 

			var raceData = repo.GetRaceDataGeneric(SType, SearchString).OrderByDescending(r => r.Date);

			DateTime MaxDate = raceData.Max(r => r.Date);
			DateTime MinDate = raceData.Min(r => r.Date);

			int Period = MaxDate.Subtract(MinDate).Days;

			if (SearchPeriodDays > 0)
			{
				//raceData.
			}

			if (raceData != null)
			{
				int iFinishingPos = 0;

				List<decimal> Scores = new List<decimal>();

				foreach (RaceDataEntities rd in raceData)
				{
					Debug.WriteLine($"Days Diff: {rd.Date.Subtract(MinDate).Days}");

					decimal dayPastFactor = Decimal.Divide((decimal)(rd.Date.Subtract(MinDate).Days) , (decimal)Period);

					Regex regex = new Regex(@"\d+");
					Match match = regex.Match(rd.Finishingposition.Replace("=", ""));
					if (match.Success)
					{
						if (int.TryParse(rd.Finishingposition, out iFinishingPos))
						{
							Debug.WriteLine($"iFinishingPos: {iFinishingPos}; dayPastFactor: {dayPastFactor}");
							Scores.Add((iFinishingPos * dayPastFactor));
						}
					}
				}
				
				result = new Tuple<string, decimal>(SearchString, Math.Round(Scores.Average(), 2));

			}
			else
			{
				result = new Tuple<string, decimal>(SearchString, 0);
			}
			return result;
			
		}

		/// <summary>
		/// For Getting a Combined Score of e.g. HorseName + Jockey + Trainer
		/// </summary>
		/// <param name="InputCombos"></param>
		/// <returns>
		/// Sum of the Score of all InputEntities
		/// </returns>
		public Tuple<string, decimal> GetCombineScore(IEnumerable<Tuple<SearchType, string>> InputCombos)
		{
			string combo_name = string.Empty;
			decimal total_score = 0;

			for (int cnt = 0; cnt < InputCombos.Count(); cnt++)
			{
				combo_name += InputCombos.ElementAt(cnt).Item2 + (cnt != (InputCombos.Count() - 1) ? "-" : "");

				var temp = GetScore(InputCombos.ElementAt(cnt).Item1, InputCombos.ElementAt(cnt).Item2);

				total_score = Decimal.Add(total_score, temp.Item2);
			}

			return new Tuple<string, decimal>(combo_name, total_score);
		}
	}
}
