using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RacePredict.Test
{
	public class Test
	{
		private Repository repo;
		public Test()
		{
			repo = new Repository();
		}

		[Test]
		public void CanGetRaceDataByJockeyName()
		{
			string jockeyName = "Leah Hemi";

			Assert.That(repo.GetRaceDataByJockeyName(jockeyName) != null, "Can not return jockey with the name " + jockeyName);
		}

		[Test]
		public void CanGetRaceDataByHorseName()
		{
			string horseName = "Little Tee";

			Assert.That(repo.GetRaceDataByHorseName(horseName) != null, "Can not return horse with the name " + horseName);
		}

		[Test]
		public void CanGetRaceDataByTrainerName()
		{
			string trainerName = "Gary Vile";

			Assert.That(repo.GetRaceDataByTrainerName(trainerName) != null, "Can not return trainer with the name " + trainerName);
		}
		[Test]
		public void CanGetRaceDataGeneric()
		{
			SearchType SType = SearchType.Jockey;
			string JockeyName = "Anna Jones";

			var result = repo.GetRaceDataGeneric(SearchType.Jockey, JockeyName);

			Assert.That(result != null, "We have an issue getting results, the reuslt is NULL");
		}
		[Test]
		public void CanGetScore()
		{
			ScoreModel _Score = new ScoreModel();

			var result = _Score.GetScore(SearchType.Jockey, "Leah Hemi");

			Assert.That(result.Item2 > 0, "There seems to some issues getting the Score");
		}
	}
}
