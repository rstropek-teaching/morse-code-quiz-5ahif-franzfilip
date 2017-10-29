using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode
{
    class WorkWithData
    {
        //Variablen
        public string data;
        public ArrayList splittedMessage;

        //Konstruktor
        public WorkWithData()
        {
            this.data = "";
            this.splittedMessage = new ArrayList();
        }
        
        #region Methoden
        /// <summary>
        /// Reads the file in small pieces of 1 KB
        /// </summary>
        /// <returns>
        /// String containing the Input Data
        /// </returns>
        public string readData()
        {
            const int chunkSize = 1024; // read the file by chunks of 1KB
            using (var file = File.OpenRead("../../Data.txt"))
            {
                int bytesRead;
                var buffer = new byte[chunkSize];

                while ((bytesRead = file.Read(buffer, 0, buffer.Length)) > 0)
                {
                    UTF8Encoding temp = new UTF8Encoding(true);
                    this.data = this.data + temp.GetString(buffer);
                }
            }
            return data;
        }
        /// <summary>
        /// Converts the Data which was manipulated by the UTF-8 encoding and chunk limited reading
        /// </summary>
        /// <param name="data"></param>
        /// <returns>
        /// String containing the Input Data
        /// </returns>
        public void correctData()
        {
            //Unit Seperator entfernen
            this.data = this.data.Remove(0, 1);
            //data = "                  a                       ";
            //String auf null stellen überprüfen die durch die konvertierung entstanden sind und zu BLANKS machen
            //32 --> " "
            //0 --> null
            char[] arr = this.data.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if ((int)arr[i] == 0)
                {
                    arr[i] = ' ';
                }
            }

            String solution = "";

            //Char Array wieder zu Blank konvertieren
            for (int i = 0; i < arr.Length; i++)
                solution += arr[i];

            //getrimmten String zurückgeben

            //return solution.Trim();
            this.data = solution.Trim();
        }

        public void organizeInput()
        {
            ArrayList whereSplit = new ArrayList();
            ArrayList howlong = new ArrayList();
            if(this.data.Length >= 2)
            {
                int splitter = 0;
                Char[] arr = this.data.ToCharArray();
                String message = "";

                //Überprüfen wann ein Wort zu Ende ist
                for(int i = 0; i < arr.Length; i++)
                {
                    if(arr[i] == ' ')
                    {
                        if(arr[i + 1] == ' ' && arr[i + 2] == ' ' && arr[i + 3] == ' ')
                        {
                            for(int j = splitter; j<i; j++)
                            {
                                message += arr[j];
                            }
                            this.splittedMessage.Add(message.Trim());
                            message = "";

                            i = i + 4;
                            splitter = i;

                            /*
                            var test = arr.Where(index => index != i); //arr.Length
                            foreach (var test2 in test)
                            {
                                Console.Write(test2);
                            }
                            */
                            //Console.WriteLine("SPLIT");
                        }
                    }
                }
                //letzter Teil der Botschaft
                for (int j = splitter; j < arr.Length; j++)
                {
                    message += arr[j];
                }
                this.splittedMessage.Add(message.Trim());
                message = "";
            }
            
            
        }
        /// <summary>
        /// Checks if the given String is a correct Morse-Code
        /// </summary>
        /// <returns>
        /// true if the data is faulty
        /// </returns>
        public Boolean controlData()
        {
            if (this.data.Length >= 2)
            {
                Char[] arr = this.data.ToCharArray();
                
                for (int i = 0; i < arr.Length; i++)
                {
                    //sind nicht erlaubte zeichen im string?
                    if (arr[i] != ' ' && arr[i] != '.' && arr[i] != '-')
                    {
                        return true;
                    }
                    //Char muss entweder - oder . sein
                    if (arr[i] != '-' && arr[i] != '.')
                    {
                        //Char kann aber auch ein Leerzeichen sein --> darf aber nicht länger als 4 Leerzeichen sein
                        if(arr[i] == ' ')
                        {
                            if(arr[i+1] != '.' && arr[i+1] != '-')
                            {
                                //auf richtige Anzahl von leerzeichen überprüfen
                                if ((arr[i + 1] == ' ' && arr[i + 2] != ' ')
                                    || (arr[i + 1] == ' ' && arr[i + 2] == ' ' && arr[i + 3] != ' ')
                                    || (arr[i + 1] == ' ' && arr[i + 2] == ' ' && arr[i + 3] == ' ' && arr[i + 4] == ' ')
                                    )
                                {
                                    return true;
                                }
                                else if (arr[i + 1] == ' ' && arr[i + 2] == ' ' && arr[i + 3] == ' ')
                                {
                                    i = i + 4;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        # endregion
    }
}
