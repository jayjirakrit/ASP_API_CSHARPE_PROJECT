using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Models.Entity
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        // Navigation Properties
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }

    public class WalkEntityConfiguration : IEntityTypeConfiguration<Walk>
    {
        public void Configure(EntityTypeBuilder<Walk> builder)
        {
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
            
            builder.HasOne(x => x.Region)
                .WithMany(x => x.Walks)
                .HasForeignKey(x => x.RegionId);

        }
    }

}
