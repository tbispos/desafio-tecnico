using Domain.Entidades;
using System.Collections.Generic;

namespace Domain.Interface.Service
{
    public interface ICardService
    {
        public List<Card> GetAll();

    }
}
