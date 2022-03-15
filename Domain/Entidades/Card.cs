using Domain.Util;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int                  id          { get; set; }
        public string               titulo      { get; set; }
        public string               conteudo    { get; set; }
        public Enums.ListaStatus    lista       { get; set; }
        public Card()
        {
            //id = Guid.NewGuid();
        }

    }
}
