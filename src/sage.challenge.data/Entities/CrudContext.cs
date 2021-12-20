using Microsoft.EntityFrameworkCore;

namespace sage.challenge.data.Entities
{
    /// <summary>
    /// Database context
    /// </summary>
    public class CrudContext: DbContext
    {
        public CrudContext(DbContextOptions options): base(options) { }
        public virtual DbSet<User> Users { get; set; }
    }
}
