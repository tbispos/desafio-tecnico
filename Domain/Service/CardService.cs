using Domain.Entidades;
using Domain.Interface.Service;
using System.Collections.Generic;

namespace Domain.Service
{
    public class CardService : ICardService
    {
        public List<Card> GetAll()
        {
            List<Card> ret = new List<Card>();

            for (int i = 0; i < 10; i++)
            {
                Card c = new Card();
                c.id        = i;
                c.titulo    = i + "tit";
                c.conteudo  = i + "cont";
                c.lista     = Util.Enums.ListaStatus.Doing;

                ret.Add(c);
            }
            ret[2].lista = Util.Enums.ListaStatus.ToDo;
            ret[3].lista = Util.Enums.ListaStatus.Done;


            return ret;
        }
    }
}
