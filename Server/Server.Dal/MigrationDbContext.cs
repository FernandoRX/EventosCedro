using Microsoft.EntityFrameworkCore;
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
	}
}
