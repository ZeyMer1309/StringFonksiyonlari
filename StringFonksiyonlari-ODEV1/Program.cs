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

                    foreach (var item in programsMethods)
                    {
                        if (methods[iter] == item.Name)
                        {
                            StringsMethods c = new StringsMethods();
                            item.Invoke(c, null);
                            break;
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
        #region Menüler
        public class StringsMethods
        {
            public void IndexOf()
            {
                setTitle();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" IndexOf Komutu");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" IndexOf komutu, verilen cümle içindeki istenen karakter(ler)in ilk hangi konumda başladığını, eğer ki yoksa -1 değerini döndüren komuttur.\n");

                Console.Write(" Lütfen ana cümleyi giriniz\n ");
                string sentence = Console.ReadLine();
                Console.Write(" Aranacak parçayı girin\n ");
                string part = Console.ReadLine();

                int locate = sentence.IndexOf(part);

                if (locate != -1)
                {
                    Console.WriteLine($"\n Aranan ifade cümle içinde ilk defa {locate} indisinde bulundu.");

                    Console.WriteLine(" " + sentence);
                    for (int i = 0; i < locate; i++)
                        Console.Write(" ");

                    Console.Write(" ");
                    for (int i = 0; i < part.Length; i++)
                        Console.Write("^");

                    Console.WriteLine();
                }
                else
                    Console.WriteLine("\n Aranan ifade cümlede bulunamadı.");

                Console.WriteLine("\n\n Tekrar denemek için ENTER tuşuna basın. Çıkmak için herhangi bir tuşu kullanın.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                    IndexOf();
                else
                    mainMenu();
            }

            public void Contains()
            {
                setTitle();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Contains Komutu");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Contains komutu, verilen cümle içindeki istenen karakter(ler)in olup olmadığını (bool) döndüren komuttur.\n");

                Console.Write(" Lütfen ana cümleyi giriniz\n ");
                string sentence = Console.ReadLine();
                Console.Write(" Aranacak parçayı girin\n ");
                string part = Console.ReadLine();

                bool isThere = sentence.Contains(part);

                if (isThere)
                {
                    Console.WriteLine($"\n Aranan ifade cümle içinde bulundu.");

                    int locate = sentence.IndexOf(part);

                    Console.WriteLine(" " + sentence);
                    for (int i = 0; i < locate; i++)
                        Console.Write(" ");

                    Console.Write(" ");
                    for (int i = 0; i < part.Length; i++)
                        Console.Write("^");

                    Console.WriteLine();
                }
                else
                    Console.WriteLine("\n Aranan ifade cümlede bulunamadı.");

                Console.WriteLine("\n\n Tekrar denemek için ENTER tuşuna basın. Çıkmak için herhangi bir tuşu kullanın.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                    Contains();
                else
                    mainMenu();
            }

            public void Split()
            {
                setTitle();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Split Komutu");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Split komutu, belirlenen sembol(ler)e göre verilmiş olan string'i parçalayan komuttur.\n");

                Console.Write(" Lütfen parçalanacak cümleyi giriniz\n ");
                string sentence = Console.ReadLine();
                Console.Write(" Parçalama için kullanılacak sembolü girin\n ");
                char brace = Console.ReadKey().KeyChar;
                Console.WriteLine();

                Console.WriteLine("\n Cümledeki, belirlenen sembolleri arayacak olursak");
                Console.WriteLine(" " + sentence);

                string indicator = "";
                foreach (var ch in sentence)
                {
                    if (ch != brace)
                        indicator += " ";
                    else
                        indicator += "^";
                }
                Console.WriteLine(" " + indicator);

                Console.WriteLine("\n Parçaları ayrı ayrı yazmak gerekirse");
                string[] parts = sentence.Split(brace); //hobileri , ile ayırıp hobiListe içine aktarıyoruz.
                foreach (string part in parts)
                    Console.WriteLine(" " + part);

                Console.WriteLine("\n\n Tekrar denemek için ENTER tuşuna basın. Çıkmak için herhangi bir tuşu kullanın.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                    Split();
                else
                    mainMenu();
            }

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
