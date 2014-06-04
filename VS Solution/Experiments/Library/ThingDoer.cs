using System;
using System.Collections.Generic;
using System.IO; //I added this one because it has code for messing with Files (ie File.WriteAllText)
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
	public class ThingDoer
	{
		public void Initialize()
		{
			_message = "Hello World";
		}

		public void PerformSomeAction1()
		{
			Console.WriteLine( _message );
		}

		public void PerformSomeAction2()
		{
			File.WriteAllText( "PerformSomeAction2.txt", _message );
		}

		public void Shutdown()
		{
			//Normally this should be used to clean up any resources you're holding on to...
			// But in this case we use it to make debugging a little nicer. Debugging a Command Line Program
			// typically closes the Command Line window once it runs out of code. This gives us a pause point at the end.

			//Pause until the Enter key is entered into the command line. 
			Console.ReadLine();
		}

		private string _message = "";
	}
}
