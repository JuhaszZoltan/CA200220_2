using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CA200220_2
{
    struct Cica
    {
        public string Nev { get; set; }
        public int Kor { get; set; }
        public float Suly { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var cicak = new Cica[]
            {
                new Cica() { Nev = "Lukrécica", Kor = 6, Suly = 90.5F, },
                new Cica() { Nev = "Kevin", Kor = 9, Suly = 4.2F, },
                new Cica() { Nev = "Kornéliusz", Kor = 7, Suly = 16F, },
                new Cica() { Nev = "Edison", Kor = 2, Suly = 4.7F, },
                new Cica() { Nev = "Maricsu", Kor = 9, Suly = 12F, },
            };

            var szamok = new int[] { 2, 3, 5, 3, 5, 10 };

            Console.WriteLine(szamok.Sum());
            Console.WriteLine(szamok.Average());
            Console.WriteLine(szamok.Min());
            Console.WriteLine(szamok.Max());
            Console.WriteLine(szamok.Count());

            int coe1 = cicak.Sum(x => x.Kor);
            int coe2 = (from x in cicak select x.Kor).Sum();

            int lfck1 = cicak.Min(c => c.Kor);
            int lfck2 = (from c in cicak select c.Kor).Min();

            //SELECT TOP 1 nev FROM cicak WHERE kor = min(kor)
            //SELECT nev FROM cicak WHERE kor = min(kor) LIMIT 1

            string lfcn1 = cicak
                .Where(c => c.Kor == cicak.Min(x => x.Kor))
                .Select(c => c.Nev)
                .First();
            Console.WriteLine(lfcn1);

            string lfcn2 = 
                (from c in cicak
                where c.Kor == cicak.Min(x => x.Kor)
                select c.Nev).First();
            Console.WriteLine(lfcn2);

            Cica[] rendezettCicak = 
                cicak.OrderByDescending(c => c.Kor)
                .ToArray();

            string szazHusz = cicak
                .Where(c => c.Suly == 120F)
                .Select(c => c.Nev)
                .FirstOrDefault();

            if (szazHusz is null) Console.WriteLine("Nincs 120 kilós macska");
            else Console.WriteLine($"Van 120 kilós macska, a neve: {szazHusz}");

            Console.WriteLine("5 évesnél idősebb cicák");
            cicak
                .Where(c => c.Kor > 5)
                .Select(c => c.Nev)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            Console.ReadKey();
        }
    }
}
