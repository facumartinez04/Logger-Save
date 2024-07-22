using BLL.Exceptions;
using BLL.Implementations;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI__PARCIAL_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {


                Logger logger = new Logger(Logger.Tipo.SQL);

                logger.Write("Este es un nuevo error");

           

                Console.WriteLine("ESTAMOS EN TIPO DE SQL \n");

                foreach (var log in logger.ReadAll())
                {
                    Console.WriteLine($"Id Log: {log.Id} - Mensaje: {log.message}\n");
                }



                Console.WriteLine("ESTAMOS EN TIPO FILE \n");

                Logger logger1 = new Logger(Logger.Tipo.File);

                logger1.Write("Este es un nuevo error");


                foreach (var log in logger1.ReadAll())
                {
                    Console.WriteLine($"Id Log: {log.Id} - Mensaje: {log.message} \n");
                }




                Console.ReadKey();



            }catch (FatalException ex)
            {
                Console.WriteLine($"Surgio un nuevo error fatal : {ex.Message}");
                
            }
            catch (CriticalException ex)
            {
                Console.WriteLine($"Surgio un nuevo error critico : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}
