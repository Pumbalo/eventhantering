using Microsoft.EntityFrameworkCore;
using test.web.Models;

namespace test.web.Data;

public class TestContext: DbContext
{
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Member> Members => Set<Member>();
    public DbSet<MemberEvent> MemberEvent => Set<MemberEvent>();
    public TestContext(DbContextOptions options) : base(options)
    {
    }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Sätt upp sammansatt primärnyckel som består av EventId och MemberId...
        modelBuilder.Entity<MemberEvent>() //StudentCourse = MemberEvent
            .HasKey(sc => new{sc.EventId, sc.MemberId});
        
        // Sätt upp förhållandet att en member kan vara anmäld på flera events...
        modelBuilder.Entity<MemberEvent>()
            .HasOne(sc => sc.Member)
            .WithMany(c => c.MemberEvents)
            .HasForeignKey(sc => sc.MemberId);

        // Sätt upp förhållandet att ett event kan ha flera members...
        modelBuilder.Entity<MemberEvent>()
            .HasOne(sc => sc.Event)
            .WithMany(c => c.MemberEvents)
            .HasForeignKey(sc => sc.EventId);
    }

}
