using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs
{
    public class CardDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int     id           { get; set; }
        [Required]
        public string   titulo      { get; set; }
        [Required]
        public string   conteudo    { get; set; }
        [Required]
        public string   lista       { get; set; }
    }
}
