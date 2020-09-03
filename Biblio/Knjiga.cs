using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
	public class Knjiga : INotifyPropertyChanged
	{
		private int _id;
		public int Id 
		{ 
			get => _id; 
			set
			{
				_id = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
			}
		}
		public string Naziv { get; set; }
		public int Primeraka { get; set; } = 1;

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
