using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace LookupFormNamespace
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		// Here is how to use this dialog
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			// Your list with data
			List<object> list = Names.Select(a => (object)new Data { Text = a }).ToList();

			// Function that selects searchable text
			// This is not the same as displayed text
			// To customize how your object looks in ListBox use DataTemplate or override ToString()
			Func<object, string> lookup = a => (a as Data).Text;


			var wnd = new LookupForm(list, lookup);
			if (wnd.ShowDialog() == true)
				MessageBox.Show("Selected: " + wnd.SelectedItem);
		}

		#region Names list
		static List<string> Names = new List<string>
		{
			"james", "john", "robert", "michael", "william", "david", "richard", "charles", "joseph", "thomas", "christopher", "daniel", "paul", 
			"mark", "donald", "george", "kenneth", "steven", "edward", "brian", "ronald", "anthony", "kevin", "jason", "matthew", "gary", "timothy", 
			"jose", "larry", "jeffrey", "frank", "scott", "eric", "stephen", "andrew", "raymond", "gregory", "joshua", "jerry", "dennis", "walter", 
			"patrick", "peter", "harold", "douglas", "henry", "carl", "arthur", "ryan", "roger", "joe", "juan", "jack", "albert", "jonathan", 
			"justin", "terry", "gerald", "keith", "samuel", "willie", "ralph", "lawrence", "nicholas", "roy", "benjamin", "bruce", "brandon", 
			"adam", "harry", "fred", "wayne", "billy", "steve", "louis", "jeremy", "aaron", "randy", "howard", "eugene", "carlos", "russell", 
			"bobby", "victor", "martin", "ernest", "phillip", "todd", "jesse", "craig", "alan", "shawn", "clarence", "sean", "philip", "chris", 
			"johnny", "earl", "jimmy", "antonio", "danny", "bryan", "tony", "luis", "mike", "stanley", "leonard", "nathan", "dale", "manuel", 
			"rodney", "curtis", "norman", "allen", "marvin", "vincent", "glenn", "jeffery", "travis", "jeff", "chad", "jacob", "lee", "melvin", 
			"alfred", "kyle", "francis", "bradley", "jesus", "herbert", "frederick", "ray", "joel", "edwin", "don", "eddie", "ricky", "troy", 
			"randall", "barry", "alexander", "bernard", "mario", "leroy", "francisco", "marcus", "micheal", "theodore", "clifford", "miguel", 
			"oscar", "jay", "jim", "tom", "calvin", "alex", "jon", "ronnie", "bill", "lloyd", "tommy", "leon", "derek", "warren", "darrell", 
			"jerome", "floyd", "leo", "alvin", "tim", "wesley", "gordon", "dean", "greg", "jorge", "dustin", "pedro", "derrick", "dan", "lewis", 
			"zachary", "corey", "herman", "maurice", "vernon", "roberto", "clyde", "glen", "hector", "shane", "ricardo", "sam", "rick", "lester", 
			"brent", "ramon", "charlie", "tyler", "gilbert", "gene", "marc", "reginald", "ruben", "brett", "angel", "nathaniel", "rafael", "leslie", 
			"edgar", "milton", "raul", "ben", "chester", "cecil", "duane", "franklin", "andre", "elmer", "brad", "gabriel", "ron", "mitchell", "roland", 
			"arnold", "harvey", "jared", "adrian", "karl", "cory", "claude", "erik", "darryl", "jamie", "neil", "jessie", "christian", "javier", "fernando", 
			"clinton", "ted", "mathew", "tyrone", "darren", "lonnie", "lance", "cody", "julio", "kelly", "kurt", "allan", "nelson", "guy", "clayton", "hugh", 
			"max", "dwayne", "dwight", "armando", "felix", "jimmie", "everett", "jordan", "ian", "wallace", "ken", "bob", "jaime", "casey", "alfredo", "alberto", 
			"dave", "ivan", "johnnie", "sidney", "byron", "julian", "isaac", "morris", "clifton", "willard", "daryl", "ross", "virgil", "andy", "marshall", 
			"salvador", "perry", "kirk", "sergio", "marion", "tracy", "seth", "kent", "terrance", "rene", "eduardo", "terrence", "enrique", "freddie", "wade"
		};
		#endregion
	}

	// Your data object
	public class Data
	{
		public string Text { get; set; }

		public override string ToString()
		{
			return Text;
		}
	}
}
