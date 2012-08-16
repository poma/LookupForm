using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Threading;

namespace LookupFormNamespace
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class LookupForm : Window, INotifyPropertyChanged
	{
		public List<object> List { get; private set; }
		public Func<object, string> LookupProperty { get; private set; }
		public bool IgnoreCase { get; set; }

		private string _searchText;
		public string SearchText
		{
			get { return _searchText ?? ""; }
			set
			{
				if (_searchText == value) return;
				_searchText = value;
				_collectionView.View.Refresh();
				if (listBox.Items.Count > 0 && listBox.SelectedItem == null)
					listBox.SelectedIndex = 0;
				OnPropertyChanged("SearchText");
			}
		}

		private CollectionViewSource _collectionView;
		public CollectionViewSource CollectionView
		{
			get
			{
				if (_collectionView == null)
				{
					_collectionView = new CollectionViewSource();
					_collectionView.Source = List;
					_collectionView.Filter += CollectionViewSource_Filter;
				}
				return _collectionView;
			}
		}

		private object selectedItem;
		public object SelectedItem
		{
			get { return selectedItem; }
			set { selectedItem = value; }
		}

		public LookupForm(List<object> list, Func<object, string> lookupProperty)
		{
			LookupProperty = lookupProperty;
            List = list;
			InitializeComponent();

			// Just in case
			new DispatcherTimer { IsEnabled = true, Interval = TimeSpan.FromMilliseconds(200) }
				.Tick += (obj, args) => { if (!textBox.IsFocused) textBox.Focus(); };

		}

		/// <summary>
		/// This function precesses all keystrokes
		/// </summary>
		private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
			switch (e.Key)
			{
				case Key.Escape:
					DialogResult = false;
					break;
				case Key.Enter:
					SelectCurrentItem();
					break;
				case Key.Up:
					if (listBox.SelectedIndex > 0)
					{
						listBox.SelectedIndex--;
						listBox.ScrollIntoView(listBox.SelectedItem);
					}
					break;
				case Key.Down:
					if (listBox.SelectedIndex < listBox.Items.Count - 1)
					{
						listBox.SelectedIndex++;
						listBox.ScrollIntoView(listBox.SelectedItem);
					}
					break;
				case Key.PageUp:
					if (listBox.Items.Count > 0)
					{
						listBox.SelectedIndex = 0;
						listBox.ScrollIntoView(listBox.SelectedItem);
					}
					break;
				case Key.PageDown:
					if (listBox.Items.Count > 0)
					{
						listBox.SelectedIndex = listBox.Items.Count - 1;
						listBox.ScrollIntoView(listBox.SelectedItem);
					}
					break;

				default:
					// This will just send keystroke to textbox
					e.Handled = false;
					textBox.Focus();
					break;
			}	
		}

		private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
		{
			e.Accepted = LookupProperty(e.Item).IndexOf(SearchText, IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) >= 0;
		}

		private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			SelectCurrentItem();
		}

		private void SelectCurrentItem()
		{
			var item = listBox.SelectedItem as Data;
			if (item == null) return; // I think this can happen only with empty list
			DialogResult = true;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged(string property)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(property));
		}
	}
}
