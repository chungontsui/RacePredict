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
					result = GetRaceDataByHorseName(SearchString);
					break;
				case SearchType.Jockey:
					result = GetRaceDataByJockeyName(SearchString);
					break;
				case SearchType.Trainer:
					result = GetRaceDataByTrainerName(SearchString);
					break;
			}
			return result;
		}

		public List<RaceDataEntities> GetRaceDataByJockeyName(string Jockey)
		{
			if (string.IsNullOrEmpty(Jockey))
			{
				throw new Exception("Jockey Name is empty");
			}

			return _da.GetRaceData().Where(r => r.JockeyName.Contains(Jockey)).ToList();
		}

		public List<RaceDataEntities> GetRaceDataByHorseName(string Horse)
		{
			if (string.IsNullOrEmpty(Horse))
			{
				throw new Exception("Horse Name is empty");
			}

			return _da.GetRaceData().Where(r => r.HorseName.Contains(Horse)).ToList();
		}

		public IEnumerable<RaceDataEntities> GetRaceDataByHorseId(int HorseId)
		{
			return _da.GetRaceData().Where(r => r.HorseID == HorseId);
		}

		public List<RaceDataEntities> GetRaceDataByTrainerName(string Trainer)
		{
			if (string.IsNullOrEmpty(Trainer))
			{
				throw new Exception("Trainer Name is empty");
			}

			return _da.GetRaceData().Where(r => r.Trainer.Contains(Trainer)).ToList();
		}
	}
}
