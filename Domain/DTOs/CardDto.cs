using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class CardDto
    {   
        public int    id       { get; set; }
        [Required]             
        public string titulo   { get; set; }
        [Required]             
        public string conteudo { get; set; }
        [Required]             
        public string lista    { get; set; }
    }
}
