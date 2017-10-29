using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithData workWithData = new WorkWithData();
            MorseData morsedata = new MorseData();

            workWithData.readData();

            workWithData.correctData();

            
            if (workWithData.controlData() == true)
            {
                Console.WriteLine("Programm wird beendet da keine korrekten Daten übergeben wurden...");
                Console.ReadKey();
                Environment.Exit(1);
            }
            //wörter trennen
            workWithData.organizeInput();
            
            //Message übersetzen
            morsedata.translateMessage(workWithData.splittedMessage);
            /*
            foreach(var x in workWithData.splittedMessage)
            {
                Console.WriteLine(x);
            }
            */

            //Console.WriteLine(workWithData.data.Substring(0, 20));
            //Console.WriteLine(workWithData.data.Substring(24, 20));
            //Console.WriteLine(workWithData.data.Substring(48, 20));
            //Console.WriteLine(workWithData.data.Substring(72, 20));


            Console.WriteLine("Raw Data:\n"+workWithData.data);
            Console.WriteLine("Translated Data:\n"+morsedata.encodedMessage);
            Console.WriteLine("Press any Key to Exit...");
            Console.ReadKey();
        }
    }
}
