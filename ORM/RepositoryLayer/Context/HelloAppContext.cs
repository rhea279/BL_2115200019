
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Context
{
    public class HelloAppContext :DbContext
    {
        public HelloAppContext(DbContextOptions<HelloAppContext> options) : base(options) { }
        public virtual DbSet<UserEntity> Users { get; set; }
    }
}
