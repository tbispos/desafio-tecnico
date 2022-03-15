using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface ICardRepository
    {
        Card Get(int id);
        List<Card> GetAll();
        Card Add(Card card);
        void Update(Card card);
        void Delete(Card card);
    }
}
