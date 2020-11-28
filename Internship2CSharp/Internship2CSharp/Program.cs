using System;
using System.Collections.Generic;

namespace Internship2CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            var playList = new Dictionary<int, string>()
            {
                {1,"SWAGUSA"},
                {2,"NE MOZE" },
                {3,"Uptown Funk" },
                {4,"Somebody That I Used To Know" },
                {5,"Old Town Road" },
                {6,"Cesarica" },
                {7,"Counting Stars" },
                {8,"Autotune" }
            };
            bool query = true;
            while (query)
            {
                #region Pocetni ispis
                Console.WriteLine("Odaberite akciju:");
                Console.WriteLine("1 - Ispis cijele liste\n2 - Ispis imena pjesme unosom pripadajućeg rednog broja\n3 - Ispis rednog broja pjesme unosom pripadajućeg imena\n4 - Unos nove pjesme\n5 - Brisanje pjesme po rednom broju\n6 - Brisanje pjesme po imenu\n7 - Brisanje cijele liste\n8 - Uređivanje imena pjesme\n9 - Uređivanje rednog broja pjesme, odnosno premještanje pjesme na novi redni broj u listi\n10 - Shuffle pjesama, odnosno nasumično premještanje elemenata liste\n0 - Izlaz iz aplikacije");
                #endregion
                int unos = int.Parse(Console.ReadLine());
                switch (unos)
                {
                    case 1:
                        for (int i = 1; i < playList.Count+1; i++)
                        {
                            Console.WriteLine(playList[i]);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Napiši redni broj pjesme: ");
                        int brojPjesme = int.Parse(Console.ReadLine());
                        foreach(var pisma in playList)
                            if(pisma.Key==brojPjesme)
                                Console.WriteLine(pisma.Value);
                        break;
                    case 3:
                        Console.WriteLine("Napiši ime pjesme (Case insensitive je): ");
                        string imePjesme = Console.ReadLine();
                        foreach (var pisma in playList)
                            if (pisma.Value.ToUpper() == imePjesme.ToUpper())
                                Console.WriteLine(pisma.Key);
                        break;
                    case 4:
                        Console.WriteLine("Unesi ime nove pjesme: ");
                        string imeNovePjesme = Console.ReadLine();
                        Potvrda();
                        playList.Add(playList.Count+1, imeNovePjesme);
                        break;
                    case 5:
                        Console.WriteLine("Unesi redni broj pjesme koje želis izbrisati: ");
                        int brojPjesmeZaIzbrisati = int.Parse(Console.ReadLine());
                        Potvrda();
                        playList.Remove(brojPjesmeZaIzbrisati);
                        var temp = new Dictionary<int, string>();
                        int brojac = 1;
                        foreach (var pisma in playList)
                        {
                            if (pisma.Key == brojPjesmeZaIzbrisati + brojac)
                            {
                                temp.Add(pisma.Key - 1, pisma.Value);
                                brojac++;
                            }
                            else
                            {
                                temp.Add(pisma.Key, pisma.Value);
                            }
                        }
                        playList = temp;
                        break;
                    case 6:
                        Console.WriteLine("Unesi ime pjesme koje želis izbrisati: ");
                        string imePjesmeZaIzbrisati = Console.ReadLine();
                        Potvrda();
                        int brojac2 = 1;
                        var privremena = new Dictionary<int, string>();
                        foreach (var pisma in playList)
                        {
                            if (pisma.Value.ToUpper() == imePjesmeZaIzbrisati.ToUpper())
                            {
                                int privremeno = pisma.Key;
                                playList.Remove(privremeno);
                                foreach (var item in playList)
                                {
                                    if (item.Key == privremeno + brojac2)
                                    {
                                        privremena.Add(item.Key - 1, item.Value);
                                        brojac2++;
                                    }
                                    else
                                    {
                                        privremena.Add(item.Key, item.Value);
                                    }
                                }
                                
                            }
                        }
                        playList = privremena;
                        break;
                    case 7:
                        Potvrda();
                        playList.Clear();
                        break;
                    case 8:
                        Console.WriteLine("Unesi broj pjesme kojoj želis urediti ime: ");
                        int brojPjesmeZaPromjenu = int.Parse(Console.ReadLine());
                        var temp2 = new Dictionary<int,string>();
                        Console.WriteLine("Unesi novo ime pjesme: ");
                        string novoIme = Console.ReadLine();
                        Potvrda();
                        temp2.Add(brojPjesmeZaPromjenu, novoIme);
                        foreach (var pisma in playList)
                        {
                            if (pisma.Key != brojPjesmeZaPromjenu)
                            {
                                temp2.Add(pisma.Key, pisma.Value);
                            }
                        }
                        playList=temp2;
                        break;
                    case 9:
                        Console.WriteLine("Upisi redni broj pjesme koju zelis premjestiti: ");
                        int brojPjesmeZaPrebacit = int.Parse(Console.ReadLine());
                        Console.WriteLine("Na koje mjesto je zelis prebaciti: ");
                        int mjesto = int.Parse(Console.ReadLine());
                        Potvrda();
                        var premijestenaPlayLista = new Dictionary<int, string>();
                        if (brojPjesmeZaPrebacit > mjesto)
                        {
                            int brojac3 = 0;
                            foreach (var pisma in playList)
                            {
                                if (pisma.Key < mjesto)
                                {
                                    premijestenaPlayLista.Add(pisma.Key, pisma.Value);
                                }
                                else if (pisma.Key == brojPjesmeZaPrebacit)
                                {
                                    premijestenaPlayLista.Add(mjesto, pisma.Value);
                                }
                                else if (pisma.Key == mjesto+brojac3)
                                {
                                    premijestenaPlayLista.Add(pisma.Key+1, pisma.Value);
                                    brojac3++;
                                }
                                else if (pisma.Key > brojPjesmeZaPrebacit)
                                {
                                    premijestenaPlayLista.Add(pisma.Key, pisma.Value);
                                }
                            }
                        }
                        else if (mjesto>brojPjesmeZaPrebacit)
                        {
                            int brojac3 = 0;
                            foreach (var pisma in playList)
                            {
                                if (pisma.Key < brojPjesmeZaPrebacit)
                                {
                                    premijestenaPlayLista.Add(pisma.Key, pisma.Value);
                                }
                                else if (pisma.Key == brojPjesmeZaPrebacit)
                                {
                                    premijestenaPlayLista.Add(mjesto, pisma.Value);
                                }
                                else if (pisma.Key > mjesto)
                                {
                                    premijestenaPlayLista.Add(pisma.Key, pisma.Value);
                                }
                                else if(pisma.Key==brojPjesmeZaPrebacit+brojac3+1)
                                {
                                    premijestenaPlayLista.Add(brojPjesmeZaPrebacit + brojac3,pisma.Value);
                                    brojac3++;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Jednaki su/ERROR");
                        }
                        playList = premijestenaPlayLista;
                        break;
                    case 10:
                        Potvrda();
                        var lista = new List<int>();
                        var randomPlayList = new Dictionary<int, string>();
                        while (lista.Count<playList.Count)
                        {
                            int randomBroj = rnd.Next(1,playList.Count+1 );
                            if (lista.Contains(randomBroj))
                            {
                            }
                            else
                            {
                                lista.Add(randomBroj);
                            }
                        }
                        foreach (var item in playList)
                        {
                                randomPlayList.Add(lista.IndexOf(item.Key) + 1, item.Value);
                        }
                        playList = randomPlayList;
                        break;
                    case 0:
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Krivi unos!");
                        break;
                }

                #region Ponavljanje Query-a
                Console.WriteLine("\nŽelite li izaci na glavni izbornik? Da/Ne (Case Insensitive je)");
                bool tocanOdgovor = false;
                while (!tocanOdgovor) {
                    string odgovor = Console.ReadLine();
                    if (odgovor.ToUpper()=="DA")
                    {
                        query = true;
                        tocanOdgovor = true;
                        Console.WriteLine();
                    }
                    else if (odgovor.ToUpper()=="NE")
                    {
                        query = false;
                        tocanOdgovor = true;
                        Console.WriteLine("Izlaženje iz aplikacije...");
                    }
                    else
                    {
                        Console.WriteLine("Krivi unos, molim vas ponovite!");
                    } }
                #endregion
            }
        }
        static void Potvrda()
        { 
            Console.WriteLine("Jeste li sigurni? DA/NE (Case Insensitive je)");
            bool tocanOdgovor = false;
            while (!tocanOdgovor)
            {
                string potvrda = Console.ReadLine();
                if (potvrda.ToUpper() == "DA")
                {
                    tocanOdgovor = true;
                    Console.WriteLine("Nastavljanje sa akcijom...");
                }
                else if (potvrda.ToUpper() == "NE")
                {
                    tocanOdgovor = true;
                    Console.WriteLine("Vraćanje na početni izbornik...");
                    break;
                }
                else
                {
                    Console.WriteLine("Krivi unos, molim vas ponovite!");
                }
            }
        }
    }
}
