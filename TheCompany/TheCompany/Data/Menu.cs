using System.Collections.Generic;
namespace TheCompany.Data
{
    public class Menu
    {
        public int Id { get; set; }
        public string TitleEN { get; set; }
        public string TitleBG { get; set; }
        public virtual List<MenuItem> MenuItems { get; set; }
        public bool Deleted { get; set; }
    }
}
