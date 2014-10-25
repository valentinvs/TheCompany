using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheCompany.Data
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string TitleEN { get; set; }
        public string TitleBG { get; set; }
        public string DescriptionEN { get; set; }
        public string DescriptionBG { get; set; }
        public double Grams { get; set; }
        public decimal Price { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("Menu")]
        public virtual int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
