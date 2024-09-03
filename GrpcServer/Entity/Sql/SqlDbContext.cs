using GrpcServer.Entity.Sql.dbo;
using Microsoft.EntityFrameworkCore;

namespace GrpcServer.Entity
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions options) : base(options) 
        { }

        public DbSet<Student> Student { get; set; }
    }
}
