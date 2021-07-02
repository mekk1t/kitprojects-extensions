using System.Collections.Generic;

namespace KitProjects.PrimitiveTypes.Extensions
{
    /// <summary>
    /// Класс расширений с применением дженериков.
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Возвращает <see langword="null"/> вместо значения по умолчанию для значимых типов.
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
