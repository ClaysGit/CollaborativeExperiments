using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This references the other project, with the "action" code.
// For this to work, you must first Right Click on the project,
// select "Add Reference...", and then select the desired project in the Solution tab.
// Having done that, all the code in that project can be called from this one. This line
// just tells the compiler that we're using code from that Reference.
using Library;

namespace Launcher
{
	class Program
	{
		static void Main( string[] args )
		{
			//Get the first thing out of the input
			var firstInput = "";
			if ( args.Length > 0 )
			{
				firstInput = args[ 0 ];
			}

			//Create our ThingDoer
			var thingDoer = new ThingDoer();

			//Initialize it
			thingDoer.Initialize();

			//Use the ThingDoer to accomplish whatever the input asks of us
			if ( String.Equals( firstInput, "action1" ) )
			{
				thingDoer.PerformSomeAction1();
			}
			else if ( String.Equals( firstInput, "action2" ) )
			{
				thingDoer.PerformSomeAction2();
			}

			//Let the ThinngDoer cleanup any resources it might be using.
			thingDoer.Shutdown();
		}
	}
}
