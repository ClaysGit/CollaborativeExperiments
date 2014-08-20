using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlAndStuff
{
	public class MealType
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
	}

	public class RecipeType
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
		public List<string> Ingredients { get; set; }
		public List<Guid> MealTypesSuitedFor { get; set; }
	}

	public class DayType
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
		public List<Guid> OrderedMealsForDay { get; set; }
	}

	public class Definitions
	{
		public List<MealType> MealTypes { get; set; }
		public List<RecipeType> RecipeTypes { get; set; }
		public List<DayType> DayTypes { get; set; }
	}
}
