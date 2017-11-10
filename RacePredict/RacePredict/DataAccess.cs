using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacePredict
{
	public class DataAccess
	{
		public IEnumerable<RaceDataEntities> GetRaceData()
		{
			using (var context = new dbNZGoodies_TestEntities())
			{
				return context.RaceDataEntities.ToList();
			}
		}

		public List<RaceDataEntities> GetRaceDataByHorseName(string Horse)
		{
			if (string.IsNullOrEmpty(Horse))
			{
				throw new Exception("Horse Name is empty");
			}

			using (var context = new dbNZGoodies_TestEntities())
			{
				return context.RaceDataEntities.Where(r => r.HorseName.Equals(Horse)).ToList();
			}

		}

		public List<RaceDataEntities> GetRaceDataByJockeyName(string Jockey)
		{
			if (string.IsNullOrEmpty(Jockey))
			{
				throw new Exception("Jockey Name is empty");
			}

			using (var context = new dbNZGoodies_TestEntities())
			{
				return context.RaceDataEntities.Where(r => r.JockeyName.Contains(Jockey)).ToList();
			}
		}

		public IEnumerable<RaceDataEntities> GetRaceDataByHorseId(int HorseId)
		{
			using (var context = new dbNZGoodies_TestEntities())
			{
				return context.RaceDataEntities.Where(r => r.HorseID == HorseId);
			}
		}

		public List<RaceDataEntities> GetRaceDataByTrainerName(string Trainer)
		{
			if (string.IsNullOrEmpty(Trainer))
			{
				throw new Exception("Trainer Name is empty");
			}
			using (var context = new dbNZGoodies_TestEntities())
			{
				return context.RaceDataEntities.Where(r => r.Trainer.Contains(Trainer)).ToList();
			}
		}
	}
}
