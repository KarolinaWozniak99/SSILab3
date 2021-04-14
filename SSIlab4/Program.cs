using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSIlab4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] X = { "deszczowo", "goraco", "slaby" };

            string C1 = "tak";
            string C2 = "nie";
            

            Console.WriteLine("Prawdopodobieństwo P(C=C1|X)="+POstatecze(C1,X));
            Console.WriteLine("Prawdopodobieństwo P(C=C2|X)=" + POstatecze(C2,X));

            double x = POstatecze(C1, X);
            double y = POstatecze(C2, X);


            if (x>y)
                Console.WriteLine("Pozytywna decyzja o wyjściu na spacer");
            else
                Console.WriteLine("Negatywna decyzja o wyjsciu na spacer");

            Console.ReadKey();
        }


        static public string[] Zmien (string[] tab)
        {
            int[] newTab = new int[tab.Length];

            for (int i = 0; i < tab.Length; i++)
            {
                try
                {
                    newTab[i] = Convert.ToInt32(tab[i]);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Blad!"+e);
                }
                if (newTab[i] < 16)
                    tab[i] = "chlodno";
                else if (newTab[i] > 20)
                    tab[i] = "goraco";
                else
                    tab[i] = "cieplo";
            }           
            return (tab);
        }

        public static double P(string[] tab1, string c)
        {
            double licznik = 0;
            for (int i = 0; i < tab1.Length; i++)
            {
                if (c == tab1[i])
                    licznik++;
            }
            return licznik;
        }
        
        public static double POstatecze(string c, string[] tab)
        {
            

            string[] pogoda = { "slonecznie", "deszczowo", "pochmurno", "pochmurno", "slonecznie", "slonecznie", "deszczowo", "slonecznie", "pochmurno", "deszczowo" };
            string[] temp = { "23", "15", "17", "21", "20", "25", "22", "14", "19", "16" };
            string[] wiatr = { "umiarkowany", "mocny", "slaby", "umiarkowany", "mocny", "slaby", "slaby", "mocny", "mocny", "slaby" };
            string[] decyzja = { "tak", "nie", "tak", "nie", "tak", "tak", "tak", "nie", "nie", "nie" };
            string[] tempOgolnie = Zmien(temp);


            double nP = 0, nT=0, nW=0;
            

            for (int i = 0; i < decyzja.Length; i++)
            {
                if (c == decyzja[i])
                {
                    if (pogoda[i] == tab[0])
                        nP++;
                    if (tempOgolnie[i] == tab[1])
                        nT++;
                    if (wiatr[i] == tab[2])
                        nW++;
                }
            }
            double x = P(decyzja, c);
            double prawdC = P(decyzja, c) / decyzja.Length;

            nP /= x;
            nT /= x;
            nW /= x;

            double PrawdoOstateczne = prawdC * nP * nT * nW;
            return PrawdoOstateczne;
        }
        
    }
}
