using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Models.Entity
{
    public class User_Role
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class UserRoleEntityConfiguration : IEntityTypeConfiguration<User_Role>
    {
        public void Configure(EntityTypeBuilder<User_Role> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(y => y.User_Role)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Role)
                .WithMany(y => y.User_Role)
                .HasForeignKey(x => x.RoleId);

        }
    }

}
