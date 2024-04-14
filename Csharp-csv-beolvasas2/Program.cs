using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy; // Input Output
                              // File, StreamReader, StreamWriter

namespace Gyakorlas2
{
    class Program
    {
        static readonly string file = "users.csv";

        static void Main()
        {
            List<Felhasznalo> felhasznalok = new List<Felhasznalo>();

            if (!File.Exists(file))
            {
                Console.WriteLine("Nem létezik a file!");
                Console.ReadKey();
                return;
            }

            using (StreamReader sr = new StreamReader(file))
            {
                string data = sr.ReadToEnd();

                foreach (string line in data.Split('\n'))
                {
                    if (line == "" || line == string.Empty)
                        continue;
                    string[] cellak = line.Split(';');
                    Felhasznalo felhasznalo = new Felhasznalo();
                    felhasznalo.id = int.Parse(cellak[0]);
                    felhasznalo.username = cellak[1];
                    felhasznalo.password = cellak[2].Trim();

                    felhasznalok.Add(felhasznalo);
                }
            }

            Console.Write("Írd be a felhasználónevedet: ");
            string inp_usr = Console.ReadLine();
            Console.Write("Írd be a jelszavadat: ");
            string inp_pass = Console.ReadLine();

            bool logged = false;


            foreach (Felhasznalo fel in felhasznalok)
            {
                if (inp_usr == fel.username)
                {
                    if (inp_pass == fel.password)
                    {
                        Console.WriteLine("Sikeres bejelentkezés!");
                        logged = true;
                        break;
                    }
                    Console.WriteLine("Rossz jelszó!");
                }
            }

            if (!logged)
            {
                Console.WriteLine("Sikertelen bejelentkezés!");
            }

            Console.ReadKey();
        }

        struct Felhasznalo
        {
            public int id;
            public string username;
            public string password;
        }
    }
}