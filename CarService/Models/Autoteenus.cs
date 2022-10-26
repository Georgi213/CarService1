using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Autoteenus
    {
        [Key]
        public int AutoteenusID { get; set; }
        public string autoteenus { get; set; }
        public int Hind { get; set; }
        public int Aeg { get; set; }
    }
}
