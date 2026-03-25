namespace FileOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //main file
            string lstrRoot = "D:\\console3\\FileOperations\\FileOperations";
            Loggers.istrErrorLogFilePath = Path.Combine(lstrRoot, "ErroLog.txt");
            var lstrNewDirPath = Path.Combine(lstrRoot, "MyNewFolder");

            if(!Directory.Exists(lstrNewDirPath))
            {
                DirectoryInfo lobjDI = Directory.CreateDirectory(lstrNewDirPath);
                Console.WriteLine(lobjDI.CreationTime.ToString() + "******" + lobjDI.CreationTime.ToString());
            }

            //Searching files
            var larrFiles = Directory.GetFiles(lstrRoot, "t*.txt", SearchOption.AllDirectories);
            foreach(string lstrFile in larrFiles)
            {
                Console.WriteLine(lstrFile);
            }

            //New file
            string lstrFilePath = Path.Combine(lstrRoot, "text.txt");

            if(!File.Exists(lstrFilePath))
            {
                File.WriteAllText(lstrFilePath, string.Empty);
            }
            string lstrFileData = File.ReadAllText(lstrFilePath);
            Console.WriteLine(lstrFilePath);

            try
            {
                Loggers.LogInfo($"Calling File.AppendAllText for {lstrFilePath}");
                File.AppendAllText(lstrFilePath, "\n This is my New text.");
                Loggers.LogInfo($"Copying File.Copy for {lstrFilePath} to D:\\console3\\FileOperations\\FileOperations\\t3.txt");
                File.Copy(lstrFilePath, "D:\\console3\\FileOperations\\FileOperations\\MyNewFolder\\t4.txt",true);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"please provide access to the file{lstrFilePath} or D:\\console3\\FileOperations\\FileOperations");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Loggers.LogError(ex.ToString());
            }
            finally
            {
                Console.WriteLine("This will be executed if there are any exception or no exception.");
            }
        }
    }
}
