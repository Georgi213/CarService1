using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Klient
    {
        [Key]
        public int KlientID { get; set; }
        public string Nimi { get; set; }
        public string email { get; set; }
        public string Telefon { get; set; }

        public int Vanus { get; set; }
    }
}
