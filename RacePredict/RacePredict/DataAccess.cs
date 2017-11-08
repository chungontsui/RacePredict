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
				return context.RaceDataEntities;
			}
		}
	}
}
