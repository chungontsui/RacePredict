using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacePredict
{
	public enum SearchType
	{
		Horse,
		Jockey,
		Trainer
	}
	public class Repository
	{
		private DataAccess _da;

		public Repository()
		{
			_da = new DataAccess();
		}

		public IEnumerable<RaceDataEntities> GetRaceDataGeneric(SearchType SType, string SearchString)
		{
			List<RaceDataEntities> result = new List<RaceDataEntities>();
			switch(SType)
			{
				case SearchType.Horse:
					result = _da.GetRaceDataByHorseName(SearchString);
					break;
				case SearchType.Jockey:
					result = _da.GetRaceDataByJockeyName(SearchString);
					break;
				case SearchType.Trainer:
					result = _da.GetRaceDataByTrainerName(SearchString);
					break;
			}
			return result;
		}


	}
}
