using Domain.Entidades;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using System.Collections.Generic;

namespace Domain.Service
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _repo;
        public CardService(ICardRepository repo)
        {
            _repo = repo;
        }

        public Card Get(int id)
        {
            //Busca no banco o card
            var card = _repo.Get(id);

            return card;
        }
        public List<Card> GetAll()
        {
            //Busca no banco os cards
            var cards = _repo.GetAll();

            return cards;
        }
        public bool VerificarExiste(int id)
        {
            return _repo.Get(id) != null;
        }

        public Card Add(Card card)
        {
            _repo.Add(card);
            return card;
        }

        public void Update(Card card)
        {
            _repo.Update(card);
        }

        public void Delete(Card card)
        {
            _repo.Delete(card);
        }
    }
}
