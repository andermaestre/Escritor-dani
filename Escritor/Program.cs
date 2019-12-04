using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Escritor
{
    class Program
    {
        static void Main(string[] args)
        {   Mutex m;
            String pal;
            bool nuevo;
            StreamWriter sw;
            ////Comprobar si hay lectores
            do
            {
                m = new Mutex(false, "MutexLector", out nuevo);
                m.Dispose();
            } while (!nuevo);

            //Crear Mutex escritro
            m = new Mutex(false, "MutexEscritor");
            m.WaitOne();

            sw = new StreamWriter("..\\..\\..\\Fichero.txt", true); //true significa modo concatenación.
            Console.WriteLine("Palabra:");
           
            pal = Console.ReadLine();
            while(pal!="")
            {   
                sw.WriteLine(pal);
                Console.WriteLine("Palabra:");
                pal = Console.ReadLine();
            }
            sw.Close();

           m.ReleaseMutex();
            m.Dispose();
        }
    }
}
