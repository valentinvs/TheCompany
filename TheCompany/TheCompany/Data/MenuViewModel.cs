using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TheCompany.Data
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Parent Menu")]
        public int? ParentMenuId { get; set; }

        [Display(Name = "Title EN")]
        public string TitleEN { get; set; }

        [Display(Name = "Title BG")]
        public string TitleBG { get; set; }

        public IEnumerable<MenuItem> MenuItems { get; set; }

        public IEnumerable<SelectListItem> Menus { get; set; }
    }
}
