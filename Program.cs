namespace Lottokone
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string lopetus = "";

            int kokonaisVoitto = 0;
            string moodi = Kysymoodi();

            if (moodi == "K")
            {
                do
                {

                    Ohjeteksti();
                    List<int> kayttajanNumerot = Tarkistanumerot();

                    int maara = Tarkistaint("Valitse pelien määrä: ");

                    Console.WriteLine($"\nTulostetaan {maara}:\n");

                    int nettotulos = -maara;
                    int voittojenMaara = 0;

                    List<List<int>> kaikkiArvotutRivit = new List<List<int>>();

                    for (int i = 0; i < maara; i++)
                    {
                        int bonus = 0;
                        int osumat = 0;

                        List<int> rivi = Arvottujalukuja();
                        rivi.Sort();

                        Thread.Sleep(10);
                        kaikkiArvotutRivit.Add(rivi);

                        foreach (int luku in rivi)
                        {
                            if (kayttajanNumerot.Contains(luku))
                            {
                                osumat++;
                            }
                        }

                        if (osumat == 3)
                        {
                            bonus = 1;
                        }
                        else if (osumat == 4)
                        {
                            bonus = 10;
                        }
                        else if
                            (osumat == 5)
                        {
                            bonus = 100;
                        }
                        else if (osumat == 6)
                        {
                            bonus = 10000;
                        }
                        else if (osumat == 7)
                        {
                            bonus = 1000000;
                        }

                        if (osumat >= 3)
                        {
                            voittojenMaara++;
                        }

                        kokonaisVoitto += bonus;

                        nettotulos = Plussa(nettotulos, bonus);

                        Console.WriteLine($"Rivi {i + 1}: {string.Join(", ", rivi)} -> Osumia: {osumat}");

                    }

                    Yhteenveto(maara, kokonaisVoitto, nettotulos, voittojenMaara);

                    Console.WriteLine("Jatketaanko tätä peliä? (K/E");
                    lopetus = Console.ReadLine().Trim().ToUpper();

                } while (lopetus == "K");

                Console.WriteLine("KIITOS RAHASTA");

            }
            else if (moodi == "J")
            {
                do
                {
                    int pelimäärä = 0;
                    int voittojentulo = 0;
                    int voittojenMaara = 0;

                    Console.WriteLine("Jatkuvassa pelissä peli jatkuu niin kauan kunnes painat mitä tahansa näppäintä.");
                    Ohjeteksti();
                    Console.WriteLine("");
                    List<int> kayttajanNumerot = Tarkistanumerot();


                    List<List<int>> kaikkiArvotutRivit = new List<List<int>>();

                    while (!Console.KeyAvailable)
                    {
                        pelimäärä++;
                        voittojentulo = Plussa(voittojentulo, -1);
                        int bonus = 0;
                        int osumat = 0;

                        List<int> rivi = Arvottujalukuja();
                        rivi.Sort();

                        Thread.Sleep(10);
                        kaikkiArvotutRivit.Add(rivi);

                        foreach (int luku in rivi)
                        {
                            if (kayttajanNumerot.Contains(luku))
                            {
                                osumat++;
                            }
                        }

                        if (osumat == 3)
                        {
                            bonus = 1;
                        }
                        else if (osumat == 4)
                        {
                            bonus = 10;
                        }
                        else if
                            (osumat == 5)
                        {
                            bonus = 100;
                        }
                        else if (osumat == 6)
                        {
                            bonus = 10000;
                        }
                        else if (osumat == 7)
                        {
                            bonus = 1000000;
                        }

                        if (osumat >= 3)
                        {
                            voittojenMaara++;
                        }

                        kokonaisVoitto += bonus;

                        if (bonus > 0)
                        {
                            voittojentulo = Plussa(voittojentulo, bonus);
                        }

                        Console.Write($"\rPelit {pelimäärä}: Käytetty raha {pelimäärä} € : Voitettu raha {kokonaisVoitto} €");

                    }
                    Console.ReadKey(true);

                    Console.WriteLine("\nPeli päättyi.");
                    Yhteenveto(pelimäärä, kokonaisVoitto, voittojentulo, voittojenMaara);


                    Console.WriteLine("Jatketaanko tätä peliä? (K/E");
                    lopetus = Console.ReadLine().Trim().ToUpper();

                } while (lopetus == "K");

                Console.WriteLine("KIITOS RAHASTA");
            }

        }

        static void Yhteenveto(int pelejä, int kokonaisVoitto, int tulos, int voitto)
        {

            Console.WriteLine();
            Console.WriteLine("======== YHTEENVETO ========");
            Console.WriteLine();

            int käytettyRaha = pelejä;

            Console.WriteLine($"Pelikierroksia: {pelejä}");
            Console.WriteLine($"Käytetty rahamäärä: {käytettyRaha} €");
            Console.WriteLine($"Yhteensä saatu rahaa: {tulos} €");
            Console.WriteLine($"Pelejä voitettu yhteensä: {voitto} ");
        }

        static List<int> Arvottujalukuja()
        {
            List<int> arvotut = new List<int>();


            Random luku = new Random();

            while (arvotut.Count < 7)
            {

                int uusiLuku = luku.Next(1, 41);

                if (!arvotut.Contains(uusiLuku))
                {
                    arvotut.Add(uusiLuku);
                }
            }

            return arvotut;
        }


        static string Kysymoodi()
        {
            string moodi = "";
            Console.WriteLine("Haluatko pelata:");
            Console.WriteLine("K --- Kiinteä peli. Eli valitset määrä pelejä mitä pelataan");
            Console.WriteLine("J --- Jatkuva peli. Jatkuu niin kauan kunnes painat -x-");

            do
            {
                moodi = Console.ReadLine().Trim().ToUpper();

                if (moodi != "K" && moodi != "J")
                {
                    Console.WriteLine("Kirjoita oikea valinta (K/J)");
                }
            }
            while (moodi != "K" && moodi != "J");

            return moodi;
        }

        static void Ohjeteksti()
        {
            Console.WriteLine("Anna numeroita 7 kpl. Vain 1-40. Muista jakaa ne pilkulla.");
            Console.WriteLine();
            Console.WriteLine("3 oikein = 1 €\r\n\r\n4 oikein = 10 €\r\n\r\n5 oikein = 100 €\r\n\r\n6 oikein = 10 000 €\r\n\r\n7 oikein = 1 000 000 €");
        }

        static int Tarkistaint(string prompt)
        {
            int arvo;

            Console.Write(prompt);
            string teksti = Console.ReadLine() ?? string.Empty;
            bool ok = int.TryParse(teksti, out arvo);

            while (!ok)
            {
                Console.WriteLine("Virhe! Anna kokonaisluku (numero).");
                Console.Write(prompt);
                teksti = Console.ReadLine() ?? string.Empty;
                ok = int.TryParse(teksti, out arvo);
            }

            return arvo;
        }

        static List<int> Tarkistanumerot()
        {
            List<int> totuusnumerot = new List<int>();

            do
            {

                totuusnumerot.Clear();

                string[] osia;
                do
                {
                    string numerot = Console.ReadLine() ?? string.Empty;
                    osia = numerot.Split(',');

                    if (osia.Length != 7)
                    {
                        Console.WriteLine("Anna tasan 7 eri numeroa");
                    }
                }
                while (osia.Length != 7);

                bool kaikkiok = true;
                foreach (string osa in osia)
                {

                    if (int.TryParse(osa.Trim(), out int n))
                    {
                        if (n >= 1 && n <= 40)
                        {
                            if (!totuusnumerot.Contains(n))
                            {
                                totuusnumerot.Add(n);
                            }
                            else
                            {
                                Console.WriteLine($"Numero {n} on jo annettu!");
                                kaikkiok = false;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Numero {n} ei ole välillä 1-40!");
                            kaikkiok = false;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"'{osa}' ei ole kelvollinen numero!");
                        kaikkiok = false;
                        break;
                    }
                }

                if (kaikkiok && totuusnumerot.Count == 7)
                {
                    break;
                }
            }
            while (true);

            return totuusnumerot;
        }

        static int Plussa(int a, int b)
        {
            return a + b;
        }

    }

}


