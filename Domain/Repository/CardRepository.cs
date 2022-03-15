using Domain.Context;
using Domain.Entidades;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
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
            _context.Add(card);
            _context.SaveChanges();

            return card;    
        }

        public Card Get(int id)
        {
            var card = _context.Card
                        .Where(x => x.id == id)
                        .AsNoTracking()
                        .FirstOrDefault<Card>();

            return card;
        }

        public List<Card> GetAll()
        {
            var cards = _context.Card
                .AsNoTracking()
                .ToList<Card>();

            return cards;
        }

        public void Update(Card card)
        {
            _context.Update(card);
            _context.SaveChanges();
        }

        public void Delete(Card card)
        {
            _context.Remove(card);
            _context.SaveChanges();
        }
    }
}
