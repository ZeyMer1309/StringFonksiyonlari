using System;
using System.Collections.Generic;
using System.Reflection;

namespace StringFonksiyonlari_ODEV1
{
    class Program
    {
        static List<string> methods = new List<string>() { "IndexOf", "Contains", "Split" };

        #region Başlık
        static void setTitle()
        {
            Console.Clear();
            Console.Write("\n\t\t\t\t\t");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("TURKCELL GELECEĞİ YAZANLAR ÖDEVİ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(" Ömer Gürbüz ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\n");
        }
        #endregion
        #region Ana Menü

        static int iter = 0;

        static void mainMenu()
        {
            ConsoleKeyInfo key;

            setTitle();
            Console.WriteLine(" String Method'ları\n");

            foreach (var method in methods)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" ");
                if (iter == methods.IndexOf(method))
                    selectedCell(String.Format("{0,-21}", method));
                else
                    Console.Write(String.Format("{0,-21}", method));

                if (methods.IndexOf(method) % 5 == 4)
                    Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\n");

            do
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow && iter != methods.Count - 1)
                {
                    iter++;
                    mainMenu();
                }
                else if (key.Key == ConsoleKey.LeftArrow && iter != 0)
                {
                    iter--;
                    mainMenu();
                }
                else if (key.Key == ConsoleKey.UpArrow && iter > 4)
                {
                    iter -= 5;
                    mainMenu();
                }
                else if (key.Key == ConsoleKey.DownArrow && iter < methods.Count - 5)
                {
                    iter += 5;
                    mainMenu();
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Type type = typeof(StringsMethods);
                    MethodInfo[] programsMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                    for (int i = 0; i < programsMethods.Length; i++)
                    {
                        if (methods[iter] == programsMethods[i].Name)
                        {
                            setTitle();

                            StringsMethods c = new StringsMethods();
                            programsMethods[i].Invoke(c, null);

                            Console.WriteLine("\n\n Tekrar denemek için ENTER tuşuna basın. Çıkmak için herhangi bir tuşu kullanın.");
                            ConsoleKeyInfo keyInfo = Console.ReadKey();
                            if (keyInfo.KeyChar == 13)
                                i--;
                            else
                                mainMenu();
                        }
                    }
                }
            } while (true);
        }

        static void selectedCell(string methodName)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(methodName.Substring(0, methodName.IndexOf(' ')));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(methodName.Substring(methodName.IndexOf(' ')));
        }

        #endregion

        static void Main(string[] args)
        {
            // 17 Ocak 2022 TURKCELL Geleceği Yazanlar Ödevi
            // String fonksiyonlarından indexof, contains, split'i kullanarak örnek bir proje ortaya çıkarın.

            mainMenu();
        }
    }
}
