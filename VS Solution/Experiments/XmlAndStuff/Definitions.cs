using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlAndStuff
{
	public class MealType
	{
		public MealType()
		{
			Name = "";
		}

		public Guid ID { get; set; }
		public string Name { get; set; }
	}

	public class RecipeType
	{
		public RecipeType()
		{
			Name = "";
			Ingredients = new List<string>();
			MealTypesSuitedFor = new List<Guid>();
		}

		public Guid ID { get; set; }
		public string Name { get; set; }
		public List<string> Ingredients { get; set; }
		public List<Guid> MealTypesSuitedFor { get; set; }
	}

	public class DayType
	{
		public DayType()
		{
			Name = "";
			OrderedMealsForDay = new List<Guid>();
		}

		public Guid ID { get; set; }
		public string Name { get; set; }
		public List<Guid> OrderedMealsForDay { get; set; }
	}

	public class Definitions
	{
		public Definitions()
		{
			MealTypes = new List<MealType>();
			RecipeTypes = new List<RecipeType>();
			DayTypes = new List<DayType>();
		}

		public List<MealType> MealTypes { get; set; }
		public List<RecipeType> RecipeTypes { get; set; }
		public List<DayType> DayTypes { get; set; }
	}
}
