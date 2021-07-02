using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitProjects.PrimitiveTypes.Extensions
{
    /// <summary>
    /// Класс расширений для строк.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Устанавливает, является ли строка <see langword="null"/> или <see cref="string.Empty"/>.
        /// </summary>
        /// <remarks>
        /// Сокращение для <c><see cref="string"/>.IsNullOrEmpty(<paramref name="str"/>)</c>.
        /// </remarks>
        /// <param name="str">Строка для проверки.</param>
        /// <returns>
        /// <see langword="true"/>, если строка <see langword="null"/> или <c>""</c>. <br></br>
        /// <see langword="false"/> иначе.
        /// </returns>
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        /// <summary>
        /// Устанавливает, есть ли в строке какие-либо символы, кроме пробелов.
        /// </summary>
        /// <param name="str">Строка для проверки.</param>
        /// <returns>
        /// <see langword="true"/>, если в строке есть хоть один символ, отличающийся от пробела. <br></br>
        /// <see langword="false"/>, если строка <see langword="null"/>, пустая или состоит из пробелов.
        /// </returns>
        public static bool HasValue(this string str) => !string.IsNullOrWhiteSpace(str);
    }
}
