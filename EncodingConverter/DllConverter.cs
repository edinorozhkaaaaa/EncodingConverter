using System.Text;

namespace EncodingConverter
{
    public class DllConverter
    {
        // Преобразует строку из одной кодировки в другую и возвращает преобразованную строку.
        // sourceEncoding - исходная кодировка.
        // destinationEncoding - целевая кодировка.
        public static string ConvertEncoding(string text, Encoding sourceEncoding, Encoding destinationEncoding)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text), "Строка не может быть null.");
            }

            if (sourceEncoding == null)
            {
                throw new ArgumentNullException(nameof(sourceEncoding), "Исходная кодировка не может быть null.");
            }

            if (destinationEncoding == null)
            {
                throw new ArgumentNullException(nameof(destinationEncoding), "Целевая кодировка не может быть null.");
            }

            try
            {
                // Преобразуем строку в массив байтов в исходной кодировке
                byte[] sourceBytes = sourceEncoding.GetBytes(text);

                // Преобразуем массив байтов в целевую кодировку
                byte[] destinationBytes = Encoding.Convert(sourceEncoding, destinationEncoding, sourceBytes);

                // Преобразуем массив байтов обратно в строку в целевой кодировке
                return destinationEncoding.GetString(destinationBytes);
            }
            catch (Exception ex)
            {
                // Перехватываем возможные исключения и выбрасываем более информативное
                throw new Exception("Произошла ошибка при преобразовании кодировки.", ex);
            }
        }


        // Преобразует строку из UTF-8 в ASCII.
        public static string ConvertUTF8ToASCII(string text)
        {
            return ConvertEncoding(text, Encoding.UTF8, Encoding.ASCII);
        }


        /// Преобразует строку из ASCII в UTF-8.
        public static string ConvertASCIIToUTF8(string text)
        {
            return ConvertEncoding(text, Encoding.ASCII, Encoding.UTF8);
        }
    }
}
