using Microsoft.EntityFrameworkCore;
using Server.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Dal
{
    public class MigrationDbContext : DbContext
    {
		public MigrationDbContext(DbContextOptions<MigrationDbContext> options)
			: base(options)
		{ }

		public DbSet<Evento> Eventos { get; set; }
		public DbSet<Participante> Participantes { get; set; }
	}
}
