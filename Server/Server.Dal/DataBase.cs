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
		public DbSet<Evento> Eventos { get; set; }
		public DbSet<Participante> Participantes { get; set; }

		private static DataBase instance;

		private DataBase() { }

		public static DataBase Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DataBase();
				}
				return instance;
			}
		}


		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseMySql(Environment.GetEnvironmentVariable("ConnectionString"));
		}

	}
}
