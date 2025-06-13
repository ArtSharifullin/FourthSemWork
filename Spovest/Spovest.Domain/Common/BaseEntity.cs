using Spovest.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spovest.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        /// <summary>
        /// Уникальный идентификатор поста на странице пользователя
        /// </summary>
        public int Id { get; set; }
    }
}
