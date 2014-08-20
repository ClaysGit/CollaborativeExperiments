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
			var programConfigPath = "config.xml";
			var definitionsPath = "definitions.xml";
			var dataPath = "data.xml";

			GuaranteeFiles( programConfigPath, definitionsPath, dataPath );

			var programConfiguration = DeserializeXmlObject<ProgramConfiguration>( programConfigPath );
			var definitions = DeserializeXmlObject<Definitions>( definitionsPath );
			var loadedData = DeserializeXmlObject<Data>( dataPath );

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

			SerializeXmlObject<Definitions>( definitions, definitionsPath );

			if ( !loadedData.DayDefaults.Any() )
			{
				loadedData.DayDefaults.Add( new DayMetadata()
					{
						DayName = "Sunday",
						DayNum = 0,
						DefaultDayTypeID = definitions.DayTypes[0].ID,
						ID = Guid.NewGuid()
					} );
			}

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

			SerializeXmlObject<Data>( loadedData, dataPath );




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

		public static void GuaranteeFiles( string programConfigPath, string definitionsPath, string dataPath )
		{
			if ( !File.Exists( programConfigPath ) )
			{
				SerializeXmlObject<ProgramConfiguration>( new ProgramConfiguration(), programConfigPath );
			}

			if ( !File.Exists( definitionsPath ) )
			{
				SerializeXmlObject<Definitions>( new Definitions(), definitionsPath );
			}

			if ( !File.Exists( dataPath ) )
			{
				SerializeXmlObject<Data>( new Data(), dataPath );
			}
		}

		public class ProgramConfiguration
		{
			public ProgramConfiguration()
			{
				Username = "";
				CalendarName = "";
			}

			public string Username { get; set; }
			public int RefreshToken { get; set; }
			public string CalendarName { get; set; }
		}
	}
}
