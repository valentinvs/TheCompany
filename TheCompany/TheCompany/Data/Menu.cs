using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheCompany.Data
{
    public class Menu : MenuObject
    {
        public Menu()
        {
            this.MenuItems = new HashSet<MenuItem>();
            this.Menus = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public virtual HashSet<MenuItem> MenuItems { get; set; }
        public virtual HashSet<Menu> Menus { get; set; }

        public int? ParentMenuId { get; set; }
        public Menu ParentMenu { get; set; }
    }
}
