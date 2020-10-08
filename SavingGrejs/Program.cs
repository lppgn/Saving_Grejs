using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SavingGrejs
{
    class Program
    {
        static void Main(string[] args)
        {
            Operator operater1 = new Operator();
            System.Console.WriteLine("What is your operators name?");
            operater1.name = Console.ReadLine();
            while(operater1.name.Length == 0){
                System.Console.WriteLine("No text was written");
                operater1.name = Console.ReadLine();
                Console.Clear();
            }
            Console.Clear();
            System.Console.WriteLine("what is your weapons name?");
            operater1.weaponName = Console.ReadLine();
            while(operater1.weaponName.Length == 0){
                System.Console.WriteLine("No text was written");
                operater1.weaponName = Console.ReadLine();
                Console.Clear();
            }
            Console.Clear();
            int skillPoints = 50;
            int yCoordinate = 0;
            bool loopChecker = false;
            Stat[] statArray = {operater1.operatorSpeed, operater1.weaponAmmo, operater1.weaponDamage, operater1.granades};
            System.Console.WriteLine(statArray[0].value);
            var textString = new List<string>(){"much speed", "much ammo", "much damage", "many granades"};
            while(skillPoints != 0 || loopChecker == false)
            {
                graphicProcessing(yCoordinate, statArray, textString, skillPoints);
                statSheet(ref skillPoints, ref yCoordinate, ref loopChecker, statArray);
            }
            XmlSerializer OperatorSerializer = new XmlSerializer(typeof(Operator));
            FileStream file = File.Open(@"Operator.xml", FileMode.OpenOrCreate);
            OperatorSerializer.Serialize(file, operater1);
            file.Close();
        }

        private static void graphicProcessing(int yCoordinate, Stat[] statArray, List<string> textString, int skillPoints)
        {
            Console.Clear();
            System.Console.WriteLine(statArray[0].value);
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("You have 50 points to put into your characters skills");
            if(skillPoints == 0){
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("no points left");
            }
            Console.ResetColor();
            for (int i = 0; i < textString.Count; i++)
            {
                if (i == yCoordinate)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    System.Console.WriteLine("how " + textString[i] + " do you have? " + "<" + statArray[i].value + ">");
                    Console.ResetColor();
                }
                else
                {
                    System.Console.WriteLine("how " + textString[i] + " do you have? " + "<" + statArray[i].value + ">");
                }
            }
        }

        private static void statSheet(ref int skillPoints, ref int yCoordinate, ref bool loopChecker, Stat[] statArray)
        {
            ConsoleKeyInfo validKeys = Console.ReadKey(true);
            if (skillPoints == 0 && validKeys.Key == ConsoleKey.RightArrow)
            {
            }
            else if (validKeys.Key == ConsoleKey.DownArrow)
            {
                if (yCoordinate < statArray.Length - 1)
                {
                    yCoordinate++;
                }
                else
                {
                    yCoordinate = 0;
                }
            }
            else if (validKeys.Key == ConsoleKey.UpArrow)
            {
                if (yCoordinate > 0)
                {
                    yCoordinate--;
                }
                else
                {
                    yCoordinate = statArray.Length - 1;
                }
            }
            else if (validKeys.Key == ConsoleKey.RightArrow)
            {
                statArray[yCoordinate].value++;
                skillPoints--;
            }
            else if (validKeys.Key == ConsoleKey.LeftArrow && statArray[yCoordinate].value > 0)
            {
                statArray[yCoordinate].value--;
                skillPoints++;
            }
            else if (validKeys.Key == ConsoleKey.Enter && skillPoints == 0)
            {
                loopChecker = true;
            }
        }
    }
}

