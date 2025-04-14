using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprawnosc_Nawiasy
{
    public static class TesterNawiasow
    {

        // ((<[]>{})<>) <- DOBRE            ((<[>]{})<>) <- ZŁE

        /// <summary>
        /// Funkcja sprawdza czy w danym ciągu znaków są odpowiednio umieszone nawiasy. Nie wskazuje ona jednak miejsca w którym wystąpił błąd.
        /// </summary>
        /// <param name="wartosc">Jako parametr przyjmuje stringa, którego ma sprawdzić</param>
        public static bool sprawdzNawiasyBezWskazywania(string wartosc)  //     ( okragly )      [ kwadratowy ]      { wywijany }      < ostry >       
        {
            if (wartosc.Length == 0) return true;
            wartosc = konwerter(wartosc);
            int okragly = 0, kwadratowy = 0, wywijany = 0, ostry = 0;
            bool okraglyOtwBool = false, kwadratowyOtwBool = false, wywijanyOtwBool = false, ostryOtwBool = false; //Booleany sprawdzające ostatnio otwarte nawiasy

            Action otwBoolOff = () => { okraglyOtwBool = false; kwadratowyOtwBool = false; wywijanyOtwBool = false; ostryOtwBool = false; }; //Wyłącza booleany "z otwarcia"

            Action<int> wypiszSprawdzane = (int x) => { //Wypisuje nawiasy wraz ze sprawdzanym miejscem
                for (int i = 0; i < wartosc.Length; i++)
                {
                    if (i == x || i == x + 1) Console.ForegroundColor = ConsoleColor.Red; else Console.ForegroundColor = ConsoleColor.White;   //Ustawiam kolor napisów w konsoli
                    Console.Write(wartosc[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            };

            for (int i = 0; i < wartosc.Length; i++)
            {
                //Sprawdzam otwarte nawiasy
                if (wartosc[i] == '(') { okragly++; otwBoolOff(); okraglyOtwBool = true; }
                else if (wartosc[i] == '[') { kwadratowy++; otwBoolOff(); kwadratowyOtwBool = true; }
                else if (wartosc[i] == '{') { wywijany++; otwBoolOff(); wywijanyOtwBool = true; }
                else if (wartosc[i] == '<') { ostry++; otwBoolOff(); ostryOtwBool = true; }

                //Sprawdzam zamknięte nawiasy
                else if (wartosc[i] == ')')
                {
                    wypiszSprawdzane(i - 1);
                    if (!okraglyOtwBool) return false;
                    wartosc = wartosc.Remove(i - 1, 2);
                    return sprawdzNawiasyBezWskazywania(wartosc);
                }
                else if (wartosc[i] == ']')
                {
                    wypiszSprawdzane(i - 1);
                    if (!kwadratowyOtwBool) return false;
                    wartosc = wartosc.Remove(i - 1, 2);
                    return sprawdzNawiasyBezWskazywania(wartosc);
                }
                else if (wartosc[i] == '}')
                {
                    wypiszSprawdzane(i - 1);
                    if (!wywijanyOtwBool) return false;
                    wartosc = wartosc.Remove(i - 1, 2);
                    return sprawdzNawiasyBezWskazywania(wartosc);
                }
                else if (wartosc[i] == '>')
                {
                    wypiszSprawdzane(i - 1);
                    if (!ostryOtwBool) return false;
                    wartosc = wartosc.Remove(i - 1, 2);
                    return sprawdzNawiasyBezWskazywania(wartosc);
                }
                //Console.WriteLine(wartosc);
            }

            if (okragly == 0 && kwadratowy == 0 && wywijany == 0 && ostry == 0) return true; else return false;
        }

        /// <summary>
        /// Zwraca z dostarczonego tekstu stringa z samymi nawiasami
        /// </summary>
        /// <param name="wartosc">String do konwertowania</param>
        /// <returns>Nawiasy z dostarczonego tekstu</returns>
        public static string konwerter(string wartosc)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in wartosc)
            {
                if(item == '(' || item == ')' || item == '[' || item == ']' || item == '{' || item == '}' || item == '<' || item == '>') sb.Append(item);
            }

            return sb.ToString();
        }
        
    }

}

