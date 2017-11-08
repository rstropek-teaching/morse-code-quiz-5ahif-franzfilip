using System;
using System.Collections;
using System.IO;
using System.Text;

namespace MorseCodeLibrary
{
    public class WorkWithData
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
        /// </returns>
        public void readData(String filepath)
        {
            const int chunkSize = 1024; // read the file by chunks of 1KB
            using (var file = File.OpenRead(filepath))
            {
                int bytesRead;
                var buffer = new byte[chunkSize];

                while ((bytesRead = file.Read(buffer, 0, buffer.Length)) > 0)
                {
                    UTF8Encoding temp = new UTF8Encoding(true);
                    this.data = this.data + temp.GetString(buffer);
                }
            }
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
            //Unit Seperator entfernen --> wird durch '?' dargestellt und hat den Wert 65279
            int unitseperator = 65279;
            char isunitseperator = this.data[0];

            if(unitseperator == isunitseperator)
                this.data = this.data.Remove(0, 1);

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

            //Abschließend String noch trimmen
            this.data = solution.Trim();
        }

        /// <summary>
        /// Splits the raw Message into an ArrayList
        /// </summary>
        public void organizeInput()
        {
            ArrayList whereSplit = new ArrayList();
            ArrayList howlong = new ArrayList();
            if (this.data.Length >= 2)
            {
                int splitter = 0;
                Char[] arr = this.data.ToCharArray();
                String message = "";

                //Überprüfen wann ein Wort zu Ende ist
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == ' ')
                    {
                        if (arr[i + 1] == ' ' && arr[i + 2] == ' ' && arr[i + 3] == ' ')
                        {
                            for (int j = splitter; j < i; j++)
                            {
                                message += arr[j];
                            }
                            this.splittedMessage.Add(message.Trim());
                            message = "";

                            i = i + 4;
                            splitter = i;
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
        /// false if the data is faulty
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
                        return false;
                    }
                    //Char muss entweder - oder . sein
                    if (arr[i] != '-' && arr[i] != '.')
                    {
                        //Char kann aber auch ein Leerzeichen sein --> darf aber nicht länger als 4 Leerzeichen sein
                        if (arr[i] == ' ')
                        {
                            if (arr[i + 1] != '.' && arr[i + 1] != '-')
                            {
                                //auf richtige Anzahl von leerzeichen überprüfen
                                if ((arr[i + 1] == ' ' && arr[i + 2] != ' ')
                                    || (arr[i + 1] == ' ' && arr[i + 2] == ' ' && arr[i + 3] != ' ')
                                    || (arr[i + 1] == ' ' && arr[i + 2] == ' ' && arr[i + 3] == ' ' && arr[i + 4] == ' ')
                                    )
                                {
                                    return false;
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
            return true;
        }
        # endregion
    }
}
