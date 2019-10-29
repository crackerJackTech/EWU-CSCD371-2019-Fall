using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        private string FilePath { get; }

        public FileConfig(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }
        
        public bool GetConfigValue(string name, out string? value)
        {
            
            if(File.Exists(FilePath))
            {
                using(var streamReader = new StreamReader(FilePath))
                {
                    string[] linesInFile = File.ReadAllLines(FilePath);
                    foreach (string str in linesInFile)
                    {
                        string[] parsedLine = str.Split("=");
                        if (parsedLine[0].Equals(name))
                        {
                            value = parsedLine[1];
                            streamReader.Close();
                            return true;
                        }
                    }

                    streamReader.Close();
                }
                
                
            }

            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
             
            string newEntry = $"{name}={value}";
            
            if(File.Exists(FilePath))
            {
                string[] linesInFile = File.ReadAllLines(FilePath);
                bool valueFound = false;

                for(int i = 0; i < linesInFile.Length; i++)
                {
                    string[] parsedLine = linesInFile[i].Split("=");
                    if(parsedLine[0].Equals(name))
                    {
                        linesInFile[i] = newEntry;
                        valueFound = true;
                    }
                    
                }

                File.WriteAllLines(FilePath, linesInFile);

                using(var streamWriter = new StreamWriter(FilePath))
                {
                    foreach(string lines in linesInFile)
                    {
                        streamWriter.WriteLine(lines);
                    }

                    if(!valueFound)
                    {
                        streamWriter.WriteLine(newEntry);
                    }

                    streamWriter.Close();
                }

                return true;
            }


            return false;
        }
    }


}
