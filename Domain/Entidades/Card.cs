using Domain.Util;

namespace Domain.Entidades
{
    public class Card
    {
        public int                  id          { get; set; }
        public string               titulo      { get; set; }
        public string               conteudo    { get; set; }
        public Enums.ListaStatus    lista       { get; set; }

    }
}
