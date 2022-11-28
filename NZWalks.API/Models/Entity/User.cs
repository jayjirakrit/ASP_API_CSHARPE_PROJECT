using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NZWalks.API.Models.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        //Navigation Property
        public List<User_Role> User_Role { get; set; }
    }

    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Email).HasColumnType("nvarchar(255)");
            builder.Property(x => x.Password).HasColumnType("nvarchar(255)");

        }
    }
}
