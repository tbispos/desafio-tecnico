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
        /// <summary>
        /// Buscar um Card no Banco
        /// </summary>
        /// <param name="id">id do Card a ser buscado</param>
        /// <returns>Card</returns>
        Card Get(int id);

        /// <summary>
        /// Buscar uma listagem de Cards no Banco
        /// </summary>
        /// <returns>List<Card></returns>
        List<Card> GetAll();

        /// <summary>
        /// Inserir um Card novo no Banco
        /// </summary>
        /// <param name="card">Entidade Card</param>
        /// <returns>Card</returns>
        Card Add(Card card);

        /// <summary>
        /// Atualizar um Card novo no Banco
        /// </summary>
        /// <param name="card">Entidade Card</param>
        /// <returns></returns>
        void Update(Card card);

        /// <summary>
        /// Excluir um Card do Banco
        /// </summary>
        /// <param name="card">Entidade Card</param>
        /// <returns></returns>
        void Delete(Card card);
    }
}
