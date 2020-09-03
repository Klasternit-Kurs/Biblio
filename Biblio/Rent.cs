using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
	public class Rent
	{
		public int Id { get; set; }

		public DateTime Uzeo { get; set; } 
		public DateTime? Vratio { get; set; }

		public int Zadrzavanje { get; set; } = 7;
		
		public TimeSpan? Kasnjenje
		{
			get
			{
				if (Vratio != null)
					return Vratio - Uzeo.AddDays(Zadrzavanje);
				else
					return DateTime.Now - Uzeo.AddDays(Zadrzavanje);
			}
		}

		public Knjiga Knjiga { get; set; }
		public Clan Clan { get; set; }

	}
}
