using System.Collections.Generic;
namespace TheCompany.Data
{
    public class Menu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<MenuItem> MenuItems { get; set; }
    }
}
