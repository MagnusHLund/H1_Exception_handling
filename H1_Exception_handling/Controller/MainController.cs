using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Exception_handling.Controller
{
    internal class MainController
    {
        string fileLocation = Environment.CurrentDirectory + @"\test.txt";

        Model.Model model = new Model.Model();
        View.View view = new View.View();

        /// <summary>
        /// Entry point for the controller.
        /// This creates a file and the same file, by calling 2 methods.
        /// </summary>
        internal void Main()
        {
            CreateFile();
            ReadFile();
        }

        /// <summary>
        /// This method creates a file with the location and file name, inside the fileLocation string.
        /// Writes data into the file.
        /// </summary>
        private void CreateFile()
        {
            File.Create(fileLocation).Close();

            // Writes 2 lines into the file.
            using (StreamWriter sw = new StreamWriter(fileLocation))
            {
                sw.WriteLine("Cool");
                sw.WriteLine("file");
            }
        }

        /// <summary>
        /// Reads the file, with exception handling.
        /// It writes a custom message, if the exceptions are either 'FileNotFound', 'IOException' or 'FormatException'.
        /// If its not any of those exceptions, then it writes a default message for the exception.
        /// </summary>
        private void ReadFile()
        {
            // declares a string variable called log and assigns an empty string.
            string log = "";

            // Uses exception handling to catch exceptions, when reading the file.
            try
            {
                // Reads the file, using StreamReader.
                using (StreamReader sr = new StreamReader(fileLocation))
                {
                    // Declares and assigns a new variable, which gets the entire file as a string.
                    string content = sr.ReadToEnd();

                    // If the file is empty, then an exception is thrown, saying that its an empty file.
                    if (content == "")
                    {
                        throw new Exception("The file is empty!");
                    }

                    // Outputs the contents of the file and assigns the log variable with a string, indiciating that the 'Try' worked fine.
                    view.Message(content);
                    log = "Program worked";
                }
            }
            // 3 catches that output a custom message, if its any of those exceptions.
            // If its not one of the 3 defined catches, then the last catch can output any exception.
            catch (FileNotFoundException)
            {
                log = "Ohhh nooooo. The file can not be found.";
                view.Message(log);
            }
            catch (IOException)
            {
                log = "The program might not have read access!";
                view.Message(log);
            }
            catch (FormatException)
            {
                log = "Error formatting string";
                view.Message(log);
            }
            catch (Exception e)
            {
                log = e.ToString();
                view.Message(log);
            }
            finally // The log value then gets added to a list.
            {
                model.logs.Add(log);
            }

        }
    }
}
