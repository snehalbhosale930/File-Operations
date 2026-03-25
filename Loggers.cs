using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperations
{
    public class Loggers
    {
        public static string istrErrorLogFilePath;
        public static void LogError(string astrError)
        {
            try
            {
                File.AppendAllText(istrErrorLogFilePath, "\nError:" + DateTime.Now.ToString() + "*****\n");
                File.AppendAllText(istrErrorLogFilePath, astrError);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void LogError(String astrError,string astrExtraInfo)
        {
            File.AppendAllText(istrErrorLogFilePath, "\nError:" + DateTime.Now.ToString() + "******\n");
            File.AppendAllText(istrErrorLogFilePath, "Extra Info:" + astrExtraInfo);
            File.AppendAllText(istrErrorLogFilePath, astrError);
        }
        public static void LogInfo(string astrInfo)
        {
            try
            {
                File.AppendAllText(istrErrorLogFilePath, "\n********* Info:" + DateTime.Now.ToString());
                File.AppendAllText(istrErrorLogFilePath, astrInfo);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
