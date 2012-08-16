using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace LookupForm
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
			List<object> list = Enumerable.Range(0, 100).Select(a => (object)new Data { Text = "Customer-" + a.ToString() }).ToList();

			// Function that selects searchable text
			// This is not the same as displayed text
			// To customize how your object looks in ListBox use DataTemplate or override ToString()
			Func<object, string> lookup = a => (a as Data).Text;


			var wnd = new MainWindow(list, lookup);
			if (wnd.ShowDialog() == true)
				MessageBox.Show("Selected: " + wnd.SelectedItem);
		}
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
