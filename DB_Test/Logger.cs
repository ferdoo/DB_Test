using System;
using System.IO;

namespace DB_Test
{
    class Logger
    {
        public static void Log(string message, Exception obj)
        {
            int line = 0;
            
            try
            {
                StreamReader sr = new StreamReader(@"D:\VS repos\DB_Test\DB_Test\Errorlog.txt", System.Text.Encoding.ASCII);

                do
                {
                    sr.ReadLine();
                    line++;

                } while (!sr.EndOfStream);

                sr.Dispose();

            }
            catch (Exception)
            {
            }


            try
            {
                using (StreamWriter sw = new System.IO.StreamWriter(@"D:\VS repos\DB_Test\DB_Test\Errorlog.txt", true, System.Text.Encoding.ASCII))
                {
                    sw.WriteLine("{0}. --- {1} {2} {3}", (line + 1).ToString(), System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss:fff"), obj.Message, message);
                    sw.Flush();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}