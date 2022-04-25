using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFonksiyonlari_ODEV1
{
    public class StringsMethods
    {
        public void IndexOf()
        {
            
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
        }



        public void Contains()
        {
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
        }



        public void Split()
        {
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
        }
    }
}
