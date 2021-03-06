using System;
using System.Collections.Generic;
using System.Linq;

namespace KP.Extensions.Strings
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
        /// Устанавливает, является ли строка пустой или состоит только из пробелов.
        /// </summary>
        /// <remarks>
        /// Сокращение для <c>string.IsNullOrWhiteSpace(str)</c>
        /// </remarks>
        /// <param name="str">Исходная строка для проверки.</param>
        /// <returns>
        /// <see langword="true"/>, если строка является пустой или состоит из пробелов.<br></br>
        /// <see langword="false"/> иначе.
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

        /// <summary>
        /// Устанавливает, есть ли в строке какие-либо символы, кроме пробелов.
        /// </summary>
        /// <param name="str">Строка для проверки.</param>
        /// <returns>
        /// <see langword="true"/>, если в строке есть хоть один символ, отличающийся от пробела. <br></br>
        /// <see langword="false"/>, если строка <see langword="null"/>, пустая или состоит из пробелов.
        /// </returns>
        public static bool HasValue(this string str) => !string.IsNullOrWhiteSpace(str);

        /// <summary>
        /// Соединяет исходную строку и массив строк в одну новую строку, в которой
        /// все строки будут разделены пробелом.
        /// </summary>
        /// <remarks>
        /// Исходная строка будет на первом месте.
        /// Параметр <paramref name="strings"/> может включать в себя и пустые, и <see langword="null"/>-строки.
        /// </remarks>
        /// <param name="str">Исходная строка.</param>
        /// <param name="strings">Массив строк для соединения.</param>
        /// <returns>Новая строка, в которой все строки объединены и разделены пробелом.</returns>
        public static string JoinSpaced(this string str, params string[] strings)
        {
            List<string> stringsWithValue = new();
            if (str.HasValue())
                stringsWithValue.Add(str);

            stringsWithValue.AddRange(strings
                .Where(s => s.HasValue())
                .Select(s => s.Trim()));

            return string.Join(" ", stringsWithValue);
        }

        /// <summary>
        /// Парсит строку в число. Если строка не является числом, возвращается значение по умолчанию.
        /// </summary>
        /// <param name="str">Строка для парсинга.</param>
        /// <returns>
        /// Число <see cref="int"/>, если парсинг успешен.
        /// Иначе <see langword="null"/>.
        /// </returns>
        public static int? ToIntOrDefault(this string str)
        {
            var stringIsParsed = int.TryParse(str, out int result);
            if (stringIsParsed)
                return result;
            else
                return null;
        }

        /// <summary>
        /// Парсит строку в дату. Если строка не является датой, возвращается значение по умолчанию.
        /// </summary>
        /// <param name="str">Строка для парсинга.</param>
        /// <returns>
        /// Дата <see cref="DateTime"/>, если парсинг успешен.
        /// Иначе <see langword="null"/>.
        /// </returns>
        public static DateTime? ToDateTimeOrDefault(this string str)
        {
            var stringIsParsed = DateTime.TryParse(str, out var result);

            if (stringIsParsed)
                return result;
            else
                return null;
        }

        /// <summary>
        /// Соотносит текст к значению перечисления <typeparamref name="T"/>.
        /// </summary>
        /// <remarks>
        /// Для пустой/<see langword="null"/>/пробельной строки вернётся значение по умолчанию для перечисления <typeparamref name="T"/>.
        /// </remarks>
        /// <typeparam name="T">Тип перечисления.</typeparam>
        /// <param name="str">Исходная строка для интерпретации.</param>
        /// <returns>Значение перечисления <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentException">Если <paramref name="str"/> не входит в значения <typeparamref name="T"/>.</exception>
        /// <exception cref="OverflowException"></exception>
        public static T ToEnum<T>(this string str) where T : Enum
        {
            if (str.IsNullOrEmpty() || str.IsNullOrWhiteSpace())
                return default;

            return (T)Enum.Parse(typeof(T), str);
        }
    }
}
