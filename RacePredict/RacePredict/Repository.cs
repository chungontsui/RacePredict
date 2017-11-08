using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacePredict
{
	public class Repository
	{
		private DataAccess _da;

		public Repository()
		{
			_da = new DataAccess();
		}
		public IEnumerable<RaceDataEntities> GetRaceDataByJockeyName(string Jockey)
		{
			if (string.IsNullOrEmpty(Jockey))
			{
				throw new Exception("Jockey Name is empty");
			}

			return _da.GetRaceData().Where(r => r.JockeyName.Contains(Jockey));
		}

		public IEnumerable<RaceDataEntities> GetRaceDataByHorseName(string Horse)
		{
			if (string.IsNullOrEmpty(Horse))
			{
				throw new Exception("Horse Name is empty");
			}

			return _da.GetRaceData().Where(r => r.HorseName.Contains(Horse));
		}

		public IEnumerable<RaceDataEntities> GetRaceDataByHorseId(int HorseId)
		{
			return _da.GetRaceData().Where(r => r.HorseID == HorseId);
		}

		public IEnumerable<RaceDataEntities> GetRaceDataByTrainerName(string Trainer)
		{
			if (string.IsNullOrEmpty(Trainer))
			{
				throw new Exception("Trainer Name is empty");
			}

			return _da.GetRaceData().Where(r => r.Trainer.Contains(Trainer));
		}
	}
}
