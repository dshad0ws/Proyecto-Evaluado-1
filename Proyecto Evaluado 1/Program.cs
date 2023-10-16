using System;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;


namespace Proyecto_Evaluado_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            menu();
        }
        static void menu() //menu de opciones
        {
            int op = 0;
            bool error;
            string msj = "";
            string sel;
            do
            {//creamos las opciones dentro de un do while para evitar alguna opcion no permitida 
                Console.Clear();
                error = false;
                Console.WriteLine("Menu de opciones");
                Console.WriteLine("<1> Suma De Binarios");
                Console.WriteLine("<2> Resta De Binarios");
                Console.WriteLine("<3> Salir");
                try
                {
                    Console.Write("Opcion: ");
                    op = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    op = -1;
                    msj = ex.Message;
                    error = true;
                }

                if (op == 3)
                {
                    Console.Clear();
                    Console.Write("Hasta la proximaaa");
                    Console.ReadKey();
                }
                else if (op == 1)
                {

                    do
                    {

                        Console.Clear();
                        Binario Bin1 = new Binario();
                        Binario Bin2 = new Binario();
                        Console.Clear();
                        Bin1.suma(Bin2);
                        Console.ReadKey();
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Desea ingresar otra suma? Y/N");
                            Console.Write("Respuesta: ");
                            sel = Console.ReadLine();
                            if (sel != "Y" && sel != "y" && sel != "N" && sel != "n")
                            {
                                Console.Write("Respuesta Invalida");
                                Console.ReadKey();
                            }
                        } while (sel != "Y" && sel != "y" && sel != "N" && sel != "n");
                    } while (sel == "Y" || sel == "y");


                }
                else if (op == 2)
                {
                    do
                    {

                        Console.Clear();
                        Binario Bin1 = new Binario();
                        Binario Bin2 = new Binario();
                        Console.Clear();
                        if (Bin1.Numdec < Bin2.Numdec)
                        {
                            Binario Auxiliar;
                            Auxiliar = Bin1;
                            Bin1 = Bin2;
                            Bin2 = Auxiliar;
                            Console.WriteLine("Los Numeros Se Intercambiaron.");
                        }
                        Bin1.resta(Bin2);
                        Console.ReadKey();
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Desea ingresar otra resta? Y/N");
                            Console.Write("Respuesta: ");
                            sel = Console.ReadLine();
                            if (sel != "Y" && sel != "y" && sel != "N" && sel != "n")
                            {
                                Console.Write("Respuesta Invalida");
                                Console.ReadKey();
                            }
                        } while (sel != "Y" && sel != "y" && sel != "N" && sel != "n");
                    } while (sel == "Y" || sel == "y");

                }
                else if (error == false)
                {
                    msj = "Valor invalido";
                    error = true;
                }
                if (error)
                {
                    Console.WriteLine("Error: " + msj);
                    op = -1;
                    Console.ReadKey();
                }
            } while (op != 3);
        }
    }
}
