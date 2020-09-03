using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
	public class Clan : INotifyPropertyChanged
	{
		public int Id { get; set; }

		public int Knjiga { get; set; }

		private string _ime;
		public string Ime 
		{ 
			get => _ime; 
			set
			{
				_ime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ime"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImeIPrezime"));
			}
		}
		
		private string _prezime;
		public string Prezime
		{
			get => _prezime;
			set
			{
				_prezime = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Prezime"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImeIPrezime"));
			}
		}

		public string ImeIPrezime { get => $"{Ime} {Prezime}"; }

		private DateTime _postaoClan;
		public DateTime PostaoClan 
		{ 
			get => _postaoClan; 
			set
			{
				_postaoClan = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PostaoClan"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("KasniMeseci"));
			}
		}

		private int _placenih;
		public int PlacenihClanarina 
		{ 
			get => _placenih; 
			set
			{
				_placenih = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PlacenihClanarina"));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("KasniMeseci"));
			}
		}


		public int KasniMeseci
		{
			get
			{
				int razlikaGodina = DateTime.Now.Year - PostaoClan.AddMonths(PlacenihClanarina).Year;
				int razlikaMeseci = DateTime.Now.Month - PostaoClan.AddMonths(PlacenihClanarina).Month;
				return razlikaGodina * 12 + razlikaMeseci;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
