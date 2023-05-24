using AlumniProject.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AlumniProject.Data;

public class AlumniDbContext : DbContext
{
	public AlumniDbContext(DbContextOptions<AlumniDbContext> options): base(options)
	{
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Specify the desired delete behavior
        modelBuilder
             .Entity<EventParticipant>()
             .HasOne(p => p.Alumni)
             .WithMany(a => a.EventParticipants)
             .OnDelete(DeleteBehavior.NoAction);
         //   .

        // Other configurations...

        base.OnModelCreating(modelBuilder);
    }
    public virtual DbSet<AccessRequest> AccessRequest { get; set; }
    public virtual DbSet<Alumni> Alumni { get; set; }
    public virtual DbSet<AlumniClass> AlumniClasse { get; set; }
    public virtual DbSet<Major> Major { get; set; }
    public virtual DbSet<Education> Education { get; set; }
    public virtual DbSet<Event> Event { get; set; }
    public virtual DbSet<Fund> Fund { get; set; }
    public virtual DbSet<EventParticipant> EventParticipant {get; set; }
    public virtual DbSet<Grade> Grade { get; set; }
    public virtual DbSet<New> New { get; set; }
    public virtual DbSet<TagsNew> TagsNew { get; set; }
    public virtual DbSet<Post> Post { get; set; }
    public virtual DbSet<School> School { get; set; }
    public virtual DbSet<AlumniToClass> AlumniToClass { get; set; }
    public virtual DbSet<NewsTagNew> NewsTagNew { get; set; }

}
