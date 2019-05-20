namespace Pseez.ViewModels.ViewModels.PseezEnt.IT
{
    public class ActiveDirectoryUserViewModel
    {
        public string SamAccountName { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public bool? Enabled { get; set; }
        //public DateTime? LastLogon { get; set; }
        public string LastLogon { get; set; }
    }
}