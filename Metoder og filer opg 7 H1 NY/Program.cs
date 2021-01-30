using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Metoder_og_filer_opg_7_H1_NY
{
    class Program
    {
        static void Main(string[] args)
        {
            string svar;
            do
            {
                Console.Clear(); //"Renser" konsollen til næste gang løkken kører.
                GetMenu();
                int caseSwitch = GetAnswer("Choose a number from the menu");//den variabel Switchen skal teste på
                CaseSwitch(caseSwitch);


                Console.WriteLine();
                Console.WriteLine("Back to the menu (y/n)");
                svar = Console.ReadLine().ToLower();//hvis der tastes store bogstaver læses de som små

            } while (svar == "y");//kommer tilbage til menuen dvs do løkken kører så længe der svares j
        }
        //Opretter metode til at udskrive menuen
        public static void GetMenu()
        {
            Console.WriteLine("1. Add file\n2. Delete file\n3. Display files\n4. Add folder\n5. Search for file in folder\n6. Exit\n");
        }
        //Opretter metode til brugerens svar
        public static int GetAnswer(string question)
        {
            Console.WriteLine(question);
            int output;//Erklærer en variabel der skal bruges til at indeholde brugerens svar
            while (!int.TryParse(Console.ReadLine(), out output))/*Brugerens indtastning gemmes i output og 
                                                                 * der testes for om der er indtastet et heltal.
                                                                 * whileløkken kører indtil det er et tal der er indtastet*/
            {
                Console.WriteLine("Invalid input, try again");
            }
            return output;
        }
        //opretter metode til switch
        public static void CaseSwitch(int caseSwitch)
        {
            #region Switch statements
            switch (caseSwitch)
            {
                case 1:
                    AddFileMenu();
                    break;

                case 2:
                    DeleteFileMenu();
                    break;

                case 3:
                    DisplayFilesMenu();
                    break;

                case 4:
                    AddFolderMenu();
                    break;

                case 5:
                    SearchFileMenu();
                    break;

                case 6:
                    Environment.Exit(0);//Stopper konsollen
                    break;

                default:
                    Console.WriteLine("Ugyldig indtastning");
                    break;
            }
            #endregion
        }
        //Opretter metode til Add file
        public static void AddFileMenu()
        {

            int answer = ChooseHow("Choose: \n1 to use the WriteAllText method to write text to a file\n2 to use the stream method to add a " +
                "file and write text to it");
            #region answer 1
            if (answer == 1)
            {
                Console.WriteLine("To add text to a file:");
                Console.WriteLine("\n" + "Syntax");
                Console.Write("\n" + "File.WriteAllText(@\".");
                Console.Write("\\");
                Console.WriteLine("FILENAME.txt\", \"TEXT TO WRITE TO FILE\");");

                //Eksempel:
                Console.WriteLine("\n" + "Please type in filename");
                string filename = Console.ReadLine();
                Console.WriteLine("Please type in text to write to file");
                string text = Console.ReadLine();
                WriteToFile(filename, text);
            }
            #endregion
            #region answer 2
            if (answer == 2)
            {
                Console.WriteLine("The stream method to add a file and one line of text:");

                Console.WriteLine("\n" + "Syntax");
                Console.Write("var file = new FileStream(@\".");
                Console.Write("\\");
                Console.WriteLine("FILENAME.txt\"), FileMode.Create);");
                Console.WriteLine("var writer = new StreamWriter(file)");

                Console.WriteLine("\n" + "Please type in filename");
                string filename = Console.ReadLine();
                Console.WriteLine("Please type in text to write to file");
                string text = Console.ReadLine();
                StreamWriteToFileOneLine(filename, text);

            }
            #endregion
        }
        //Opretter metode til undermenu
        public static int ChooseHow(string question)
        {
            Console.WriteLine(question);
            int output;//Erklærer en variabel der skal bruges til at indeholde brugerens svar
            while (!int.TryParse(Console.ReadLine(), out output))/*Brugerens indtastning gemmes i output og 
                                                                 * der testes for om der er indtastet et heltal.
                                                                 * whileløkken kører indtil det er et tal der er indtastet*/
            {
                Console.WriteLine("Invalid input, try again");
            }
            return output;
        }
        public static void WriteToFile(string filename, string text)
        {
            File.WriteAllText(@".\filename.txt", text);
        }
        //opretter metode til at Skrive en linje til fil
        public static void StreamWriteToFileOneLine(string filename, string text)
        {
            var file = new FileStream(@".\filename.txt", FileMode.Create);
            var writer = new StreamWriter(file);

            writer.WriteLine(text);
            file.Close();
        }

        //Opretter metode til Delete file
        public static void DeleteFileMenu()
        {
            Console.WriteLine("\n" + "Syntax");
            Console.Write("\n" + "File.Delete(@\".");
            Console.Write("\\");
            Console.WriteLine("FILENAME\");");

            //Eksempel:
            Console.WriteLine("\n" + "Please type in filename");
            string filename = Console.ReadLine();
            DeleteFile(filename);
        }
        //Opretter metoden der sletter
        public static void DeleteFile(string filename)
        {
            File.Delete(@".\filename.txt");
        }
        //Opretter metode til Display Files
        public static void DisplayFilesMenu()
        {
            int answer = ChooseHow("Choose: \n1 to use the ReadAllText method to write text to a file\n2 to use the stream method to read a " +
               "file");
            #region answer 1
            if (answer == 1)
            {
                Console.WriteLine("Syntax");
                Console.Write("\n" + "string content = File.ReadAllText(@\".");
                Console.Write("\\");
                Console.WriteLine("FILENAME.TXT\");");
                Console.WriteLine("Console.WriteLine(content);");


                //Eksempel:
                Console.WriteLine("\n" + "Please type in filename");
                string filename = Console.ReadLine();
                ReadFile(filename);
            }
            #endregion
            #region answer 2
            if (answer == 2)
            {
                Console.WriteLine("Syntax");
                Console.Write("\n" + "var file = new FileStream(@\".");
                Console.Write("\\");
                Console.WriteLine("FILENAME.txt\"), FileMode.Open);");
                Console.WriteLine("var reader = new StreamReader(file)");
                Console.WriteLine("string content = reader.ReadToEnd();");

                //Eksempel:
                Console.WriteLine("\n" + "Please type in filename");
                string filename = Console.ReadLine();
                StreamReadFile(filename);
            }

            #endregion

        }
        //Opretter metode til brug i menu 3
        public static void ReadFile(string filename)
        {
            string content = File.ReadAllText(@".\filename.txt");
            Console.WriteLine(content);
        }
        //Opretter metode til brug i menu 3
        public static void StreamReadFile(string filename)
        {
            var file = new FileStream(@".\filename.txt", FileMode.Open);
            var reader = new StreamReader(file);

            while (!reader.EndOfStream)
            {
                string name = reader.ReadLine();//tildeler en linje, ellers skulle man bruge Read.ToEnd();
                Console.WriteLine(name);
            }
            file.Close();//lukker filen for at sparer ressourcer. Kan også lukke selve streamen ved reader.Close();
        }
        //Opretter metode til Add folder
        public static void AddFolderMenu()
        {
            Console.WriteLine("\n" + "Syntax");
            Console.Write("\n" + "Directory.CreateDirectory(@\".");
            Console.Write("\\");
            Console.WriteLine("FOLDERNAME\");");

            //Eksempel:
            Console.WriteLine("\n" + "Please type in foldername");
            string foldername = Console.ReadLine();
            AddFolder(foldername);
        }
        //Opretter metode til at add folder
        public static void AddFolder(string foldername)
        {
            Directory.CreateDirectory(@".\foldername");
        }
        //Opretter metode til Search for file in folder
        public static void SearchFileMenu()
        {
            Console.WriteLine("\n" + "Syntax");
            Console.WriteLine("To search all files in all directories");
            Console.Write("\n" + "string [] arrayName = Directory.GetFiles(@\".");
            Console.Write("\\");
            Console.WriteLine("FOLDERNAME\", \"*\", SearchOption.AllDirectories);");
            Console.WriteLine("foreach (string file in arrayName)");
            Console.WriteLine("{");
            Console.WriteLine("Console.WriteLine(file);");
            Console.WriteLine("}");

            //Eksempel:
            Console.WriteLine("\n" + "Please type in foldername");
            string foldername = Console.ReadLine();
            SearchFiles(foldername);

        }
        //Opretter metode til search file
        public static void SearchFiles(string foldername)
        {
            string[] files = Directory.GetFiles(@".\foldername", "*", SearchOption.AllDirectories);/*Husk at både stjernen (for filerne) og 
                                                                                                * SearchOption.AllDirectories skal med*/
            foreach (string file in files)
            {
                Console.WriteLine(file);//Udskriver hvilke tekstfiler der ligger i mappen Droids og dens undermapper
            }
        }
    }

}



