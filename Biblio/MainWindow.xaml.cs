using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biblio
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DB Baza = new DB();


		public MainWindow()
		{
			InitializeComponent();
			Baza.Clans.ToList();
			dgClanovi.ItemsSource = Baza.Clans.Local;
			BindingGroup = new BindingGroup();
			DataContext = new Clan();
		}

		private void Unos(object sender, RoutedEventArgs e)
		{
			if (Baza.Clans.ToList().Contains(DataContext as Clan))
				return;
			BindingGroup.CommitEdit();
			(DataContext as Clan).PostaoClan = DateTime.Now;
			Baza.Clans.Add(DataContext as Clan);
			Baza.SaveChanges();
			DataContext = new Clan();
		}

		private void Promena(object sender, SelectionChangedEventArgs e)
		{
			DataContext = dgClanovi.SelectedItem;
		}

		private void Izmena(object sender, RoutedEventArgs e)
		{
			BindingGroup.CommitEdit();
			Baza.SaveChanges();
		}

		private void Nov(object sender, RoutedEventArgs e)
		{
			DataContext = new Clan();
		}

		private void Brisanje(object sender, RoutedEventArgs e)
		{
			Baza.Clans.Remove(dgClanovi.SelectedItem as Clan);
			Baza.SaveChanges();
			DataContext = new Clan();
		}

		private void Uplati(object sender, RoutedEventArgs e)
		{
			if (dgClanovi.SelectedItem != null)
			{
				(dgClanovi.SelectedItem as Clan).PlacenihClanarina++;
				Baza.SaveChanges();
			}
		}
	}

	public class IntToColor : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is int b && b <= 0)
				return Colors.Green.ToString();
			return Colors.Red.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class IntToString : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is int b && b > 0)
				return b.ToString();
			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
