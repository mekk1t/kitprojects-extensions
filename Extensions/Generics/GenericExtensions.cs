using System.Collections.Generic;

namespace KP.Extensions.Generics
{
    /// <summary>
    /// Класс расширений с применением дженериков.
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Возвращает <see langword="null"/> если <paramref name="obj"/> значимого типа <typeparamref name="T"/>
        /// является значением по умолчанию.
        /// </summary>
        /// <typeparam name="T">Значимый тип объекта.</typeparam>
        public static T? ToNullIfDefault<T>(this T obj) where T : struct
        {
            if (EqualityComparer<T>.Default.Equals(obj, default))
                return null;
            else
                return obj;
        }
    }
}
