using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Tellimus
    {
        [Key]
        public int TellimusID { get; set; }
        public int TootajaID { get; set; }
        public Tootaja Tootaja { get; set; }
        public int AutoteenusID { get; set; }
        public Autoteenus Autoteenus { get; set; }
        public int KlientID { get; set; }
        public Klient Klient { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Kuupaev { get; set; }
        [DataType(DataType.Time)]
        public DateTime Aeg { get; set; }
    }
}
