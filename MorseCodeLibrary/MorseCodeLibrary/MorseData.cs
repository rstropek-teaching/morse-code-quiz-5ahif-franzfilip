using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorseCodeLibrary
{
    public class MorseData
    {
        //Variablen
        public Dictionary<string, string> morsecodes;
        public ArrayList encodedMessage;

        public MorseData()
        {
            this.setMorseCodes();
            this.encodedMessage = new ArrayList();
        }

        public void setMorseCodes()
        {
            this.morsecodes = new Dictionary<string, string>();

            this.morsecodes.Add("A", ".-");
            this.morsecodes.Add("B", "-...");
            this.morsecodes.Add("C", "-.-.");
            this.morsecodes.Add("D", "-..");
            this.morsecodes.Add("E", ".");
            this.morsecodes.Add("F", "..-.");
            this.morsecodes.Add("G", "--.");
            this.morsecodes.Add("H", "....");
            this.morsecodes.Add("I", "..");
            this.morsecodes.Add("J", ".---");
            this.morsecodes.Add("K", "-.-");
            this.morsecodes.Add("L", ".-..");
            this.morsecodes.Add("M", "--");
            this.morsecodes.Add("N", "-.");
            this.morsecodes.Add("O", "---");
            this.morsecodes.Add("P", ".--.");
            this.morsecodes.Add("Q", "--.-");
            this.morsecodes.Add("R", ".-.");
            this.morsecodes.Add("S", "...");
            this.morsecodes.Add("T", "-");
            this.morsecodes.Add("U", "..-");
            this.morsecodes.Add("V", "...-");
            this.morsecodes.Add("W", ".--");
            this.morsecodes.Add("X", "-..-");
            this.morsecodes.Add("Y", "-.--");
            this.morsecodes.Add("Z", "--..");

            this.morsecodes.Add("0", "-----");
            this.morsecodes.Add("1", ".----");
            this.morsecodes.Add("2", "..---");
            this.morsecodes.Add("3", "...--");
            this.morsecodes.Add("4", "....-");
            this.morsecodes.Add("5", ".....");
            this.morsecodes.Add("6", "-....");
            this.morsecodes.Add("7", "--...");
            this.morsecodes.Add("8", "---..");
            this.morsecodes.Add("9", "----.");

        }
        /// <summary>
        /// Converts the MorseCode into readable Text
        /// </summary>
        /// <returns>
        /// ArrayList containing the raw message splitted in words
        /// </returns>
        public void translateMessage(ArrayList convertedMessage)
        {
            String addMessage = "";
            foreach (string rawMessage in convertedMessage)
            {
                string[] arr = rawMessage.Split(' ');
                for (int i = 0; i < arr.Length; i++)
                {
                    addMessage += this.morsecodes.FirstOrDefault(x => x.Value == arr[i]).Key;
                }
                this.encodedMessage.Add(addMessage);
                addMessage = "";
            }
        }
        /// <summary>
        /// Puts the translated Message into a File
        /// </summary>
        /// <param name="path">Path to file which should be generated (name of the file at the end)</param>
        public void putTranslatedDataInFile(string path)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@path))
            {
                for(int i = 0; i < encodedMessage.Count; i++)
                {
                    file.Write(encodedMessage[i]);
                    if (i != encodedMessage.Count - 1)
                    {
                        file.Write(" ");
                    }
                }
            }
        }
        /// <summary>
        /// Prints the Message
        /// </summary>
        public void outMessage()
        {
            for (int i = 0; i < encodedMessage.Count; i++)
            {
                Console.Write(encodedMessage[i]);
                if (i != encodedMessage.Count - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}
