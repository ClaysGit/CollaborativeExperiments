using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace XmlAndStuff
{
	public class Program
	{
		static void Main( string[] args )
		{
			//Let's assume that the first arg is the xml file for program config..
			//The second goes to definitions..
			//The third goes to normal data...stored info about the subsequent days

			var programConfiguration = DeserializeXmlObject<ProgramConfiguration>( args[ 0 ] );
			var definitions = DeserializeXmlObject<Definitions>( args[ 1 ] );
			var loadedData = DeserializeXmlObject<Data>( args[ 2 ] );

			if ( !definitions.MealTypes.Any() )
			{
				definitions.MealTypes.Add( new MealType()
					{
						ID = Guid.NewGuid(),
						Name = "Lunch"
					} );
			}

			if ( !definitions.RecipeTypes.Any() )
			{
				definitions.RecipeTypes.Add( new RecipeType()
				{
					ID = Guid.NewGuid(),
					Ingredients = new List<string>() { "Bacon", "Love", "Tomato" },
					MealTypesSuitedFor = new List<Guid>() { definitions.MealTypes[ 0 ].ID },
					Name = "BLT"
				} );
			}

			if ( !definitions.DayTypes.Any() )
			{
				definitions.DayTypes.Add( new DayType()
				{
					ID = Guid.NewGuid(),
					Name = "Work + Gym",
					OrderedMealsForDay = new List<Guid>() { definitions.MealTypes[ 0 ].ID }
				} );
			}

			SerializeXmlObject<Definitions>( definitions, args[ 1 ] );

			loadedData.SpecifiedDays.Add( new Day()
			{
				CurrentDayTypeID = definitions.DayTypes[ 0 ].ID,
				DayMetadataID = loadedData.DayDefaults[ 0 ].ID,
				Meals = new List<Meal>()
				{
					new Meal() { MealTypeID=definitions.MealTypes[0].ID, SelectedRecipeID=definitions.RecipeTypes[0].ID },
					new Meal() { MealTypeID=definitions.MealTypes[0].ID, SelectedRecipeID=Guid.Empty }
				},
				SpecifiedDate = DateTime.Now
			} );

			SerializeXmlObject<Data>( loadedData, args[ 2 ] );




			//This helps us load/store all the good info...but it's not really easy to work with yet...
			// To ACTUALLY operate on the data, we might do this:
			var recipeTypesByID = definitions.RecipeTypes.ToDictionary( r => r.ID );
			
			//Now we can look up a recipe by it's ID really cleanly...
			var recipeID = loadedData.SpecifiedDays.Last().Meals.First().SelectedRecipeID;
			var todaysRecipe = recipeTypesByID[ recipeID ];

			//So, to easily interact with data, use Dictionaries. When we want it in a list, for storage purposes...
			var recipeTypesToStore = recipeTypesByID.ToList().Select( r => r.Value );
		}

		//An introduction to templates... The <T> means that "I'll tell you what type T is when I call this function."
		// So we can call it with a different type each time. This provides us with a convenient means to have one function create different types of data.
		public static T DeserializeXmlObject<T>( string path )
		{
			var deserializer = new XmlSerializer( typeof( T ) );

			//What is "using" you ask? Whatever is created in the using statement's opening line is ALWAYS
			// destroyed for us after we leave the "using" block. So...filestream gets cleaned up appropriately
			// after we're done with it, even if the program crashes while deserializing a file.
			using ( var fileStream = File.OpenRead( path ) )
			{
				return (T)deserializer.Deserialize( fileStream );
			}
		}

		public static void SerializeXmlObject<T>( T obj, string path )
		{
			var serializer = new XmlSerializer( typeof( T ) );

			using ( var filestream = File.OpenWrite( path ) )
			{
				serializer.Serialize( filestream, obj );
			}
		}

		public class ProgramConfiguration
		{
			public string Username { get; set; }
			public int RefreshToken { get; set; }
			public string CalendarName { get; set; }
		}
	}
}
