using MorseCodeLibrary;
using System;
using System.IO;

namespace MorseCodeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithData workWithData = new WorkWithData();
            MorseData morsedata = new MorseData();
            string inputdata = "";
            string outputdata = "";

            #region Übergabeparameter überprüfen
            //Sind genau 2 Argumente als Übergabeparameter gegeben?
            if (args.Length == 2)
            {
                inputdata = args[0];
                outputdata = args[1];
            }
            else
            {
                Console.WriteLine("Programm wird beendet da zu wenige oder zu viele Argumente übergeben wurden...");
                Console.ReadKey();
                Environment.Exit(1);
            }

            //Ist der Übergabeparameter 1 ein gültiges File?
            if (File.Exists(inputdata))
            {
                workWithData.readData(inputdata);
            }
            else
            {
                Console.WriteLine("Programm wird beendet da Argument 1 kein gültiges File ist...");
                Console.ReadKey();
                Environment.Exit(1);
            }

            # endregion

            workWithData.correctData();

            if (workWithData.controlData() == false)
            {
                Console.WriteLine("Programm wird beendet da keine korrekten Daten übergeben wurden...");
                Console.ReadKey();
                Environment.Exit(1);
            }

            //Wörter trennen
            workWithData.organizeInput();

            //Message übersetzen
            morsedata.translateMessage(workWithData.splittedMessage);

            //In File schreiben
            morsedata.putTranslatedDataInFile(outputdata);


            Console.WriteLine("Raw Data:\n" + workWithData.data);
            Console.WriteLine("Translated Data:");
            morsedata.outMessage();

            Console.WriteLine("Press any Key to Exit...");
            Console.ReadKey();
        }
    }
}
