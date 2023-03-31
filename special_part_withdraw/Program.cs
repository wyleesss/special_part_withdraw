using System;
using System.Text;

internal static class Program
{
    static int NIndexOf(char ch, string str, int N) // <-- функція знаходить н-ний певниий елемент в рядку.
    { 
        int Index = 0;

        for (int i = 0; i < N; i++)
            Index = str.IndexOf(ch, Index) + 1;

        return Index;
    }
    static string GetAttribute(string Request, string AttributeName) // <-- функція виймає певний атрибут із запиту(рядка) за параметром
    {                                                                //     параметр має відповідати шаблонній назві атрибуту
        Request = Request.Replace(" ", "");                          //     до прикладу "author_id".
        int StartIndex = -1;

        switch(AttributeName)
        {
            case "index":
                StartIndex = 0;
                break;

            case "id":
                StartIndex = NIndexOf(';', Request, 1);
                break;

            case "text":
                StartIndex = NIndexOf(';', Request, 2);
                break;

            case "author_id":
                StartIndex = NIndexOf(';', Request, 3);
                break;

            case "created_id":
                StartIndex = NIndexOf(';', Request, 4);
                break;

            case "newest_id":
                StartIndex = NIndexOf(';', Request, 5);
                break;

            case "oldest_id":
                StartIndex = NIndexOf(';', Request, 6);
                break;

            case "result_count":
                StartIndex = NIndexOf(';', Request, 7);
                break;

            case "next_token":
                StartIndex = NIndexOf(';', Request, 8);
                break;

            case "geo":
                StartIndex = NIndexOf(';', Request, 9);
                return Request.Substring(StartIndex);

            default:
                break;
        }

        int EndIndex = Request.IndexOf(';', StartIndex + 1); 

        if (StartIndex == -1 ||  EndIndex == -1 || (StartIndex == EndIndex - 1 && StartIndex != 0))
            return String.Empty;

        return Request.Substring(StartIndex, EndIndex - StartIndex);
    }
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        int Choice;
        string Result;
        ConsoleKeyInfo ForExit;

        do
        {
            Console.Clear();

            Console.Write("ВВЕДІТЬ ЗАПИТ У ФОРМАТІ:\n<< index;id;text;author_id;created_at;newest_id;oldest_id;result_count;next_token;geo >>\n-> ");
            string Request = new string(Convert.ToString(Console.ReadLine()));
            Console.WriteLine("\nОБЕРІТЬ АТРИБУТ ДЛЯ ВИЙНЯТТЯ:");
            Console.Write("1 - index; \t        2 - id;\n" +
                              "3 - author_id;  \t4 - created_id;\n" +
                              "5 - newest_id;  \t6 - oldest_id;\n" +
                              "7 - result_count;\t8 - next_token;\n" +
                              "9 - geo;\n-> ");
            Choice = Convert.ToInt32(Console.ReadLine());

            while (Choice < 1 || Choice > 9)
            {
                Console.Write("error!\n-> ");
                Choice = Convert.ToInt32(Console.ReadLine());
            }

            switch (Choice)
            {
                case 1:
                    Result = GetAttribute(Request, "index");
                    break;

                case 2:
                    Result = GetAttribute(Request, "id");
                    break;

                case 3:
                    Result = GetAttribute(Request, "author_id");
                    break;

                case 4:
                    Result = GetAttribute(Request, "created_id");
                    break;

                case 5:
                    Result = GetAttribute(Request, "newest_id");
                    break;

                case 6:
                    Result = GetAttribute(Request, "oldest_id");
                    break;

                case 7:
                    Result = GetAttribute(Request, "result_count");
                    break;

                case 8:
                    Result = GetAttribute(Request, "next_token");
                    break;

                case 9:
                    Result = GetAttribute(Request, "geo");
                    break;

                default:
                    Result = String.Empty;
                    break;
            }

            Console.WriteLine("\nРЕЗУЛЬТАТ:");
            if (String.IsNullOrEmpty(Result))
                Console.WriteLine("хибний формат або атрибут відсутній");

            else
                Console.WriteLine(Result);

            Console.WriteLine("\n\nдля виходу натисніть ESC\nдля продовження - будь-яку іншу клавішу");

            ForExit = Console.ReadKey();

        } 
        while (ForExit.Key != ConsoleKey.Escape);
    }
}