namespace Covariance_and_contravariance_of_delegates
{

    interface IConverter<in T, out U>
    {
        U Convert(T value);
    }

    class StringToIntConverter : IConverter<string, int>
    {
        public int Convert(string value)
        {
            return int.Parse(value);
        }
    }

    class ObjectToStringConverter : IConverter<object, string>
    {
        public string Convert(object value)
        {
            return value.ToString();
        }
    }

    internal class Program
    {
        static U[] ConvertArray<T, U>(T[] array, IConverter<T, U> converter)
        {
            U[] result = new U[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = converter.Convert(array[i]);
            }
            return result;
        }

        static void Main(string[] args)
        {

            string[] stringArray = { "1", "2", "3", "4", "5" };

            // Создадим экземпляр конвертера строк в целые числа
            StringToIntConverter stringToIntConverter = new StringToIntConverter();

            // Применим метод ConvertArray для конвертации массива строк в массив целых чисел
            int[] intArray = ConvertArray(stringArray, stringToIntConverter);

            // Выведем результат на консоль
            Console.WriteLine("Converted array:");
            foreach (int number in intArray)
            {
                Console.WriteLine(number);
            }

            // Создадим массив объектов
            object[] objectArray = { 1, 2, 3, 4, 5 };

            // Создадим экземпляр конвертера объектов в строки
            ObjectToStringConverter objectToStringConverter = new ObjectToStringConverter();

            // Применим метод ConvertArray для конвертации массива объектов в массив строк
            string[] stringArray2 = ConvertArray(objectArray, objectToStringConverter);

            // Выведем результат на консоль
            Console.WriteLine("Converted array:");
            foreach (string str in stringArray2)
            {
                Console.WriteLine(str);
            }

            Console.ReadLine();
        }
    }
}