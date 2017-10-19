using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace historicalData
{
    class readFile
    {
        public string filePath = @"C:/Users/SeanCui/Documents/stock_ticker.txt";
       
        public readFile()
        {
            Read();
        }

 

        public void Read()
        {
            string line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filePath);

                //first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //ckAdd.ForAdd(line.ToUpper());
                    //string ticker = line.ToUpper();
                    new getApiCall(line.ToUpper());
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                writeToFile(filePath);
                Console.WriteLine("Finished reading Ticker File");

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }

        public void writeToFile(string fileName)
        {
            string line = "";
            File.WriteAllText(fileName, line);
        }
    }
}
