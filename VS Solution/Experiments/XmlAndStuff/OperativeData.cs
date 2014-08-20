using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlAndStuff
{
	//Days whose weekday number matches DayNum are assigned this metadata.
	public class DayMetadata
	{
		public Guid ID { get; set; }
		public int DayNum { get; set; }
		public string DayName { get; set; }
		public Guid DefaultDayTypeID { get; set; }
	}

	public class Meal
	{
		public Guid MealTypeID { get; set; }
		public Guid SelectedRecipeID { get; set; }
	}

	public class Day
	{
		public DateTime SpecifiedDate { get; set; }
		public Guid DayMetadataID { get; set; }
		public Guid CurrentDayTypeID { get; set; }
		public List<Meal> Meals { get; set; }
	}

	public class Data
	{
		//Defaults are specified for a day by which day of the week it is.
		// Therefore, we need 7 defaults, one for each day of the week.
		// Therefore, we should assume (or assert) that this array is always 7 length.
		public List<DayMetadata> DayDefaults { get; set; }
		public List<Day> SpecifiedDays { get; set; }
	}
}
