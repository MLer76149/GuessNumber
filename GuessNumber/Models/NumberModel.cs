using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GuessNumber.Models
{
    public class NumberModel
    {
        public int? RandomNumber { get; set; }

        [DisplayName("Nummer")]
        [Range(0, 100, ErrorMessage ="Nummer muss zwischen 0 und 100 liegen")]
        public int? GuessedNumber { get; set; }

        public List<int>? Guesses { get; set; }

        public bool? NumberGuessed { get; set; }

        public string? Reset { get; set; }
    }
}
