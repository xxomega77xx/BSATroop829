namespace BSATroop829.Models
{
    public class ManageUserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IList<UserRolesViewModel> UserRoles { get; set; }
    }
}
