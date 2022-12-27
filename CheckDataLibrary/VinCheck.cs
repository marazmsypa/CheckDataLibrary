using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckDataLibrary
{
    public class VinCheck
    {
        
        private readonly Dictionary<int, char> years = new Dictionary<int, char>() {
            { 1980, 'A' }, { 1981, 'B'}, { 1982, 'C' }, { 1983,'D' }, { 1984, 'E'}, { 1985, 'F'}, { 1986, 'G'}, { 1987, 'H'}, { 1988, 'J'}, { 1989, 'K'},
            { 1990, 'L'}, { 1991, 'M'}, { 1992, 'N'}, { 1993, 'P'}, { 1994, 'R'}, { 1995, 'S' }, { 1996, 'T'}, { 1997, 'V' }, { 1998, 'W'}, { 1999, 'X'},
            { 2000, 'Y'}, { 2001, '1'}, { 2002, '2'}, { 2003, '3' }, { 2004, '4'}, { 2005, '5' }, { 2006, '6'}, { 2007, '7'}, { 2008, '8'}, { 2009, '9'},
            { 2010, 'A'}, { 2011, 'B'}, { 2012, 'C'}, { 2013, 'D'}, { 2014, 'E'}, { 2015, 'F'}, { 2016, 'G'}, { 2017, 'H'}, { 2018, 'J'}, { 2019, 'K'},
            {2020, 'L' }, { 2021, 'M'}, { 2022, 'N'}
        };

        private readonly Dictionary<char, int> LettersInInt = new Dictionary<char, int>() {
            {'A', 1},  {'B', 2},  {'C', 3},  {'D', 4},  {'E', 5},  {'F', 6},  {'G', 7},  {'H', 8},  {'J', 1},  {'K', 2},
            {'L', 3},  {'M', 4},  {'N', 5},  {'P', 7},  {'S', 2},  {'T', 3},  {'U', 4},  {'V', 5},  {'W', 6},  {'X', 7},
            {'Y', 8},  {'Z', 9},  {'R', 9}
        };
        /// <summary>
        /// метод, позволяющий определить правильность заполнения вим
        /// </summary>       
        public bool CheckVin(string vin, int year)
        {
            if (vin.Length != 17)
            {
                throw new Exception("Ваш вим код не состоит из 17 символов");
            }
            if (!Regex.IsMatch(vin, @"^[0-9ABCDEFGHJKLMNPRSTUVWXYZ]{17}$"))
            {
                throw new Exception("Ваш вим код содержит неподходящие символы");
            }
            if (year < 1980 || year > 2022)
            {
                throw new Exception("Исходный год не подходит по параметрам");
            }


            char yearVIN = vin[10];

            if (years.ContainsKey(year))
            {
                if (years[year] == yearVIN)
                {
                    string weightVIN = "87654321098765432";
                    string numberEqViM = "";
                    int sum = 0;
                    for (int i = 0; i < 17; i++)
                    {
                        if (!Char.IsDigit(vin[i]))
                        {
                            numberEqViM += LettersInInt[vin[i]];
                        }
                        else
                        {
                            numberEqViM += vin[i];
                        }
                    }

                    for (int i = 0; i < 17; i++)
                    {


                        if (weightVIN[i] == '1')
                        {

                            sum = sum + Convert.ToInt32(numberEqViM[i].ToString()) * 10;
                        }
                        else
                        {

                            sum = sum + Convert.ToInt32(numberEqViM[i].ToString()) * Convert.ToInt32(weightVIN[i].ToString());
                        }
                    }

                    int newSum = sum;
                    while (newSum % 11 != 0)
                    {
                        newSum--;
                    }

                    string correctNumber = "";
                    if (sum - newSum == 10)
                    {

                        correctNumber = "X";
                    }
                    else
                    {
                        correctNumber = (sum - newSum).ToString();
                    }
                    if (correctNumber == vin[8].ToString())
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception("В вашем ВИМ-коде содержится неправильный символ для определения года");
            }


        }
        /// <summary>
        /// метод, позволяющий по вим автомобиля определить страну, в которой находится завод - изготовитель
        /// </summary>
        public string GetVINCountry(string vin) {
            return "";
        }
        /// <summary>
        /// метод, позволяющий определить совпадет ли код изготовления автомобиля с данными вим
        /// </summary>
        
        public bool CorrectYear(string vin, int year) {
            if (vin.Length != 17)
            {
                throw new Exception("Ваш вим код не состоит из 17 символов");
            }
            if (!Regex.IsMatch(vin, @"^[0-9ABCDEFGHJKLMNPRSTUVWXYZ]{17}$"))
            {
                throw new Exception("Ваш вим код содержит неподходящие символы");
            }
            if (year < 1980 || year > 2022)
            {
                throw new Exception("Исходный год не подходит по параметрам");
            }


            char yearVIN = vin[10];

            if (years.ContainsKey(year))
            {
                if (years[year] == yearVIN)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception("В вашем ВИМ-коде содержится неправильный символ для определения года");
            }

           
        }

        
    }
}
