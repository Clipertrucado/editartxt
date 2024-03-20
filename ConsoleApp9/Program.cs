
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {

            try
            {
                Console.WriteLine("Que archivo desea abrir: ");
                Console.WriteLine("1. archivo1");
                Console.WriteLine("2. archivo2");
                Console.WriteLine("3. archivo3");

                string rutaArchivo = "C:/Users/csi23-salflet/source/repos/ConsoleApp9/archivo" + Console.ReadLine() + ".txt";
                string textoNuevo = "";

                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string line;
                    // Leer y mostrar cada línea del archivo
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("Ingrese la linea que se desea editar");
                int numeroLinea = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("1.modificar una línea específica");
                Console.WriteLine("2.insertar texto en una posición específica de una línea");
                int seleccion = Convert.ToInt32(Console.ReadLine());


                switch (seleccion)
                {

                    case 1:

                        // Leer todas las líneas del archivo
                        string[] lineas = File.ReadAllLines(rutaArchivo);

                        // Verificar si el número de línea deseado está dentro del rango del archivo
                        if (numeroLinea >= 1 && numeroLinea <= lineas.Length)
                        {
                            Console.WriteLine("Contenido:");
                            textoNuevo = Console.ReadLine();

                            // Reemplazar el contenido de la línea específica
                            lineas[numeroLinea - 1] = textoNuevo;

                            // Sobrescribir el archivo con las líneas actualizadas
                            File.WriteAllLines(rutaArchivo, lineas);

                            Console.WriteLine("El texto se ha escrito correctamente en la línea especificada.");
                        }
                        else
                        {
                            Console.WriteLine("El número de línea especificado está fuera del rango del archivo.");
                        }


                        break;

                    case 2:

                        Console.WriteLine("Ingrese la posicion que se desea sobreescribir");
                        int posicion = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Contenido:");
                        textoNuevo = Console.ReadLine();

                        // Leer todas las líneas del archivo
                        lineas = File.ReadAllLines(rutaArchivo);

                        // Verificar si el número de línea deseado está dentro del rango del archivo
                        if (numeroLinea >= 1 && numeroLinea <= lineas.Length)
                        {
                            // Reemplazar el contenido de la línea específica
                            lineas[numeroLinea - 1] = lineas[numeroLinea - 1].Insert(posicion, textoNuevo);

                            // Sobrescribir el archivo con las líneas actualizadas
                            File.WriteAllLines(rutaArchivo, lineas);

                            Console.WriteLine("El texto se ha escrito correctamente en la línea especificada.");
                        }
                        else
                        {
                            Console.WriteLine("El número de línea especificado está fuera del rango del archivo.");
                        }




                        break;



                }

            }
            catch (IOException e)
            {
                Console.WriteLine("Error al leer/escribir el archivo: " + e.Message);
            }

        }
    }

}



