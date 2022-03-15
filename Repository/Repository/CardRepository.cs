using Domain.Context;
using Domain.Entidades;
using Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _context;

        public CardRepository(AppDbContext context)
        {
            _context = context;
        }
        public Card Add(Card card)
        {
            throw new NotImplementedException();
        }

        public void Delete(Card card)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
