namespace NZWalks.API.Models.Entity
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        //Navigation Property
        public List<User_Role> User_Role { get; set; }
    }
}
