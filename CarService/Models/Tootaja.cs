using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Tootaja
    {
        [Key]
        public int TootajaID { get; set; }
        public string Nimi { get; set; }
        public int Vanus { get; set; }
        public string email { get; set; }
        public int Telefon { get; set; }
        public string haridus { get; set; }
    }
}
