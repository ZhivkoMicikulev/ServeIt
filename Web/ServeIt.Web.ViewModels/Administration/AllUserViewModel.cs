namespace ServeIt.Web.ViewModels.Administration
{
    public class AllUserViewModel
    {
        public bool IsDeleted { get; set; }

        public string Username { get; set; }

        public string UserId { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string RegisterDate { get; set; }

        public string IsOwner { get; set; }
    }
}
