using Domain.Entidades;
using System.Collections.Generic;

namespace Domain.Interface.Service
{
    public interface ICardService
    {
        /// <summary>
        /// Buscar um Card no Repositório
        /// </summary>
        /// <param name="id">id do Card a ser buscado</param>
        /// <returns>Card</returns>
        Card Get(int id);

        /// <summary>
        /// Buscar uma listagem de Cards no Repositório
        /// </summary>
        /// <returns>List<Card></returns>
        List<Card> GetAll();

        /// <summary>
        /// Busca um Card no Repositório e depois retornar True o False se o Card existir ou não
        /// </summary>
        /// <param name="id">id do Card a ser verificado</param>
        /// <returns>bool</returns>
        bool VerificarExiste(int id);

        /// <summary>
        /// Inserir um Card novo no Repositório
        /// </summary>
        /// <param name="card">Entidade Card</param>
        /// <returns>Card</returns>
        Card Add(Card card);

        /// <summary>
        /// Atualizar um Card novo no Repositório
        /// </summary>
        /// <param name="card">Entidade Card</param>
        /// <returns></returns>
        void Update(Card card);

        /// <summary>
        /// Excluir um Card no Repositório
        /// </summary>
        /// <param name="card">Entidade Card</param>
        /// <returns></returns>
        void Delete(Card card);

    }
}
