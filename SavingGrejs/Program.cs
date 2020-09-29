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
            System.Console.WriteLine("what is your weapons name?");
            operater1.weaponName = Console.ReadLine();
            System.Console.WriteLine("you have 50 points to put into your characters skills");
            Console.ReadLine();
            int skillPoints = 50;
            int yCoordinate = 0;
            int[] statArray = {operater1.operatorSpeed, operater1.weaponAmmo, operater1.weaponDamage, operater1.granades};
            var textString = new List<string>(){"much speed", "much ammo", "much damage", "many granades"};
            while(skillPoints != 0){
                Console.Clear();
                for (int i = 0; i < textString.Count; i++)
                {
                    if(i == yCoordinate){
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        System.Console.WriteLine("how " + textString[i] + " do you have? " + "<" + statArray[i] + ">");
                        Console.ResetColor();
                    }
                    else{
                        System.Console.WriteLine("how " + textString[i] + " do you have? " + "<" + statArray[i] + ">");
                    }
                }

                ConsoleKeyInfo validKeys = Console.ReadKey(true);
                if(skillPoints == 0){
                    System.Console.WriteLine("no points left");
                }
                else if(validKeys.Key == ConsoleKey.DownArrow){
                    if(yCoordinate<statArray.Length-1){
                        yCoordinate++;
                    }
                    else{
                        yCoordinate=0;
                    }
                }
                else if(validKeys.Key == ConsoleKey.UpArrow){
                    if(yCoordinate>0){
                        yCoordinate--;
                    }
                    else{
                        yCoordinate=statArray.Length-1;
                    }
                }
                else if(validKeys.Key == ConsoleKey.RightArrow){
                    statArray[yCoordinate]++;
                    skillPoints--;
                }
                else if(validKeys.Key == ConsoleKey.LeftArrow){
                    if(statArray[yCoordinate]>0){
                        statArray[yCoordinate]--;
                        skillPoints++;
                    }
                    
                }
            }
        }
    }
}

