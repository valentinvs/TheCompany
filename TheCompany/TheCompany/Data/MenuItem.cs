using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheCompany.Data
{
    public class MenuItem : MenuObject
    {
        public int Id { get; set; }
        public string DescriptionEN { get; set; }
        public string DescriptionBG { get; set; }
        public double Grams { get; set; }
        public decimal Price { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
