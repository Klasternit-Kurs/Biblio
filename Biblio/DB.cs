using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
	public class DB : DbContext
	{
		public DB() : base(@"Data Source=DESKTOP-75VO5EN\TESTSERVER;Initial Catalog=Biblio;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
		{ }

		public DbSet<Clan> Clans { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Clan>().HasKey(c => c.Id);
		}
	}
}
