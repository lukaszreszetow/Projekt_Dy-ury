﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dyżury
{
    class Program
    {
        static void Main(string[] args)
        {
            Miesiac nowyMiesiac = new Miesiac();
            nowyMiesiac.PoczatekProgramu();
            int caseSwitch = 0;
            Boolean stworzonyPlan = false;
            do
            {
                WypisanieMenu();

                try
                {
                    caseSwitch = WyborOpcjiWMenu(nowyMiesiac, ref stworzonyPlan);
                }
                catch (Exception e)
                { }
                finally
                {
                    Console.Clear();
                }
            } while (caseSwitch != 0);
                        
            Console.ReadKey();
            }

        private static int WyborOpcjiWMenu(Miesiac nowyMiesiac, ref bool stworzonyPlan)
        {
            int caseSwitch = int.Parse(Console.ReadLine());

            switch (caseSwitch)
            {
                case 1:
                    Console.Clear();
                    nowyMiesiac.NowyLekarz();
                    break;
                case 2:
                    Console.Clear();
                    nowyMiesiac.WypisanieIstniejacychLekarzy();
                    break;
                case 3:
                    Console.Clear();
                    nowyMiesiac.switcher = 0;
                    nowyMiesiac.ZmianaDanych();
                    break;
                case 4:
                    Console.Clear();
                    try {
                        nowyMiesiac.TworzenieDyzurow();
                        stworzonyPlan = true;
                    }
                    catch(Exception e) {
                        Console.WriteLine("Nie udalo sie stworzyc planu. Może sproboj dodac lekarza?");
                    }                   
                    break;
                case 5:
                    Console.Clear();
                    nowyMiesiac.WypisanieIstniejacegoMiesiaca();
                    break;
                case 6:
                    Console.Clear();
                    if (stworzonyPlan)
                    {
                        nowyMiesiac.ZapisDoNotatnika();
                    }
                    else {
                        Console.Clear();
                        Console.WriteLine("Aby zapisać liste dyzurow musisz ją najpierw stworzyć !");
                        Console.WriteLine("Nacisnij dowolny przycisk aby przejsc dalej.");
                        Console.ReadKey();
                    }
                    break;
                case 0: System.Environment.Exit(0); break;
                default:
                    Console.Clear();
                    break;

            }

            return caseSwitch;
        }

        private static void WypisanieMenu()
        {
            Console.WriteLine("Co chcesz zrobic dalej?\n");
            Console.WriteLine("1) Stworz nowego lekarza.");
            Console.WriteLine("2) Wypisz istniejacych lekarzy.");
            Console.WriteLine("3) Zmien dane lekarza.");
            Console.WriteLine("4) Rozpocznij tworzenie planu dyzurow.");
            Console.WriteLine("5) Pokaz stworzony plan.");
            Console.WriteLine("6) Zapisz stworzony plan do notatnika.");
            Console.WriteLine("0) Wyjscie.");
        }
    }
}
