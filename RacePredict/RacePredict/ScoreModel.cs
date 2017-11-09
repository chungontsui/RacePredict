using System;
using System.Collections.Generic;
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
					decimal dayPastFactor = (rd.Date.Subtract(MinDate).Days) / Period;

					Regex regex = new Regex(@"\d+");
					Match match = regex.Match(rd.Finishingposition.Replace("=", ""));
					if (match.Success)
					{
						if (int.TryParse(rd.Finishingposition, out iFinishingPos))
						{
							Scores.Add((iFinishingPos * dayPastFactor));
						}
					}
				}

				result = new Tuple<string, decimal>(SearchString, Scores.Average());

			}
			else
			{
				result = new Tuple<string, decimal>(SearchString, 0);
			}
			return result;
			
		}
	}
}
