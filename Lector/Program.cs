using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lector
{
    class Program
    {
        static void Main(string[] args)
        {   
            StreamReader sr;

            Mutex m;
            bool nuevo;
          do
            {
                m = new Mutex(false, "MutexEscritor", out nuevo);
                m.Dispose();
            } while (!nuevo);
            m = new Mutex(false, "MutexLector");
            sr = new StreamReader("..\\..\\..\\Fichero.txt");
            String pal = sr.ReadLine();
            while(pal!=null)
            {
                Console.WriteLine(pal);
                Thread.Sleep(1000);
                pal = sr.ReadLine();
            }
            sr.Close();
           m.Dispose();
        }
    }
}
