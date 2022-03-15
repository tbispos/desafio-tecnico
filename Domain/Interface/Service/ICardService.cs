﻿using Domain.Entidades;
using System.Collections.Generic;

namespace Domain.Interface.Service
{
    public interface ICardService
    {
        Card Get(int id);
        List<Card> GetAll();
        bool VerificarExiste(int id);
        Card Add(Card card);
        void Update(Card card);
        void Delete(Card card);

    }
}