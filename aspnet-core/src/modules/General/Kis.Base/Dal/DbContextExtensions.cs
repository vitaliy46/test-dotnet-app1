using System;
using Microsoft.EntityFrameworkCore;

namespace Kis.Base.Dao
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// Присоединяет сущность к контексту данных в состоянии "изменена"
        /// TODO Хорошо было бы описать, для чего это нужно
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="context">Контекст данных</param>
        /// <param name="entity">Объект присоединяемой сущности</param>
        /// <returns></returns>
        public static T AttachAs<T>(this DbContext context, T entity, EntityState state) 
            where T : class
        {
            if (context == null) throw new ArgumentNullException("context");
            if (entity == null) throw new ArgumentNullException("entity");

            context.Entry(entity).State = state;
            return entity;
        }
    }
}
