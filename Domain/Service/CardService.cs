using Domain.Entidades;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using System.Collections.Generic;

namespace Domain.Service
{
    public class CardService : ICardService
    {
        private readonly ICardRepository cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        public Card Get(int id)
        {
            //Busca no banco o card
            var card = cardRepository.Get(id);

            return card;
        }
        public List<Card> GetAll()
        {
            //Busca no banco os cards
            var cards = cardRepository.GetAll();

            return cards;
        }
        public bool VerificarExiste(int id)
        {
            return cardRepository.Get(id) != null;
        }

        public Card Add(Card card)
        {
            cardRepository.Add(card);
            return card;
        }

        public void Update(Card card)
        {
            cardRepository.Update(card);
        }

        public void Delete(Card card)
        {
            cardRepository.Delete(card);
        }
    }
}
