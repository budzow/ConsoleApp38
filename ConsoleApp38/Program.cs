using System;
using System.Collections.Specialized;
using System.IO;

namespace ConsoleApp38
{
    class Program
    {
        static void GetContentWarningImage(NameValueCollection qs)
        {
            string fileName = "";
            //WarningImageAbsolutePath
            string path = "";

            string fName = qs.GetValues(0)[0];
            if (!string.IsNullOrEmpty(fName))
            {
                //Kill Path Traversal 
                FileInfo fInfo = new FileInfo(fName);
                FileInfo fInfo0 = new FileInfo(fName);
                FileInfo fInfo1 = new FileInfo(fName); //NOSONAR
                FileInfo fInfo2 = new FileInfo(fName);  // NOSONAR
                FileInfo fInfo3 = new FileInfo(fName);  //  NOSONAR
                FileInfo fInfo4 = new FileInfo(fName);  //  --NOSONAR--
                fileName = fInfo.Name;
            }
            string filePath = Path.Combine(path, fileName);
            Stream fileContent = null;
            try
            {
                // Load the image and return the stream:
                //RISK_KEY
                fileContent = File.OpenRead(filePath);
                int bufSize = (int)fileContent.Length;
                byte[] buf = new byte[bufSize];
                int bytesRead = fileContent.Read(buf, 0, bufSize);
            }
            catch (UnauthorizedAccessException exAuth)
            {
            }
            finally
            {
                if (fileContent != null)
                {
                    fileContent.Close();
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetContentWarningImage(new NameValueCollection());


        }


    }


}
