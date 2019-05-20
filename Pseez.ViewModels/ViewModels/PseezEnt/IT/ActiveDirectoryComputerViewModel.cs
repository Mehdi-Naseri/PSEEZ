namespace Pseez.ViewModels.ViewModels.PseezEnt.IT
{
    public class ActiveDirectoryComputerViewModel
    {
        public string SamAccountName { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Enabled { get; set; }
        //public DateTime? LastLogon { get; set; }
        public string LastLogon { get; set; }
    }
}