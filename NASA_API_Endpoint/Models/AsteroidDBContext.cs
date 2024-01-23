using Microsoft.EntityFrameworkCore;
using NASA_API_Endpoint.Models;

namespace NASA_API_Endpoint.DBModels
{
	public class AsteroidDBContext : DbContext
	{
		public AsteroidDBContext(DbContextOptions<AsteroidDBContext> options) : base(options)
		{

		}

		public DbSet<AsteroidModel> Asteroid { get; set; }

		public DateTime DateAdded { get; set; }

	}
}

