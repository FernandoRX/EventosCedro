using Microsoft.EntityFrameworkCore;
using Server.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Dal
{
    public class DataBase : DbContext
    {
		//public DataBase(DbContextOptions<DataBase> options)
		//	: base(options)
		//{ }


		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseMySql("server=localhost;userid=root;password=root;database=eventoscedro;");
		}

		public DbSet<Evento> Eventos { get; set; }
	}
}
