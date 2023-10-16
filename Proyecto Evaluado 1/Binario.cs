using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Evaluado_1
{
    public class Binario
    {
        #region Atributos 
        public int[] NB;
        public int Numdec = 0;
        public int tam;
        #endregion

        #region Constructor
        public Binario()
        {
            this.Numdec = 0;
            this.tam = 0;

            Cargar();
            int aux, Cont;
            aux = Numdec;
            Cont = 0;
            if (aux != 1 && aux != 0)
            {
                do
                {
                    aux = aux / 2;
                    Cont++;
                } while (aux != 1);
            }
            tam = Cont + 1;
            NB = new int[tam];
        }
        public Binario(int tamu, int[] rs, int dec)
        {
            tam = tamu;
            NB = rs;
            Numdec = dec;
        }

        #endregion

        #region Cargar
        void Cargar()
        {
            string msj = "";
            bool error;
            //Lo primero a realizar sera hacer la peticion de datos para realizar las operaciones
            //para esto usaremos el try catch para evitar cualquier tipo de error a la hora de cargar los datos
            do
            {
                error = false;
                try
                {
                    Console.Write("Ingrese numero que se desea convertir a binario: ");
                    Numdec = int.Parse(Console.ReadLine());
                }
                catch (Exception Ex)
                {
                    msj = Ex.Message;
                    Numdec = 0;
                    error = true;
                }
                if (Numdec < 0)
                {
                    msj = "El numero que se ingrese debe ser positivo";
                    error = true;
                }
                if (error)
                {
                    Console.WriteLine("ERROR: " + msj);
                }
            } while (error); //con este algoritmo podemos contralar que los datos no se ensucien
        }
        #endregion

        #region Convertir
        //algoritmo para transformar el numero a binario haciendo las respectivas divisiones
        void convertir()
        {
            int[] numtam = new int[tam];
            int i = 0;
            int j = 0;
            int aux = Numdec;
            if (aux == 0 || aux == 1)
            {
                NB[0] = aux;
            }
            else
            {
                do //Conversion de numero a binario
                {
                    numtam[i++] = aux % 2;
                    aux = aux / 2;

                } while (aux != 1);
                numtam[i] = aux;
                for (i = 0, j = tam - 1; i < tam; i++, j--)
                {
                    NB[i] = numtam[j];
                }
            }



        }
        #endregion

        #region Suma
        public void suma(Binario Bin2)
        {//A partir de aca necesitamos que los arreglos tengan el mismo tamaño para que podamos hacer la suma por cada posicion del arreglo
            int tamu;//Tamaño mayor 
            int[] auxbin;//variable auxiliar
            int i = 0;
            int j = 0;
            int acarreo = 0;
            convertir();
            Bin2.convertir();
            if (tam > Bin2.tam)
            {
                auxbin = new int[tam];
                for (i = tam - 1, j = Bin2.tam - 1; i > -1; i--, j--)
                {
                    if (j >= 0)
                    {
                        auxbin[i] = Bin2.NB[j];//Para el caso en que el array 1 sea menor
                    }
                    else
                    {
                        auxbin[i] = 0;
                    }
                }
                tamu = tam;
            }
            else if (tam < Bin2.tam) //para el caso en que el array2 sea menor
            {
                auxbin = new int[Bin2.tam];
                for (i = Bin2.tam - 1, j = tam - 1; i > -1; j--, i--)
                {
                    if (j > -1)
                    {
                        auxbin[i] = NB[j];
                    }
                    else
                    {
                        auxbin[i] = 0;
                    }
                }
                tamu = Bin2.tam;
            }
            else
            {
                auxbin = new int[tam];
                tamu = tam;
                for (i = 0; i < tam; i++)
                {
                    auxbin[i] = Bin2.NB[i];
                }
            }

            tamu = tamu + 1;
            int[] res = new int[tamu];
            int suma;
            for (i = tamu - 1; i > 0; i--)
            {
                suma = 0;
                if (tam >= Bin2.tam)
                {
                    suma = NB[i - 1] + auxbin[i - 1];
                }
                else
                {
                    suma = auxbin[i - 1] + Bin2.NB[i - 1];
                }
                if (suma == 2 && acarreo == 1)
                {
                    res[i] = 1;
                }
                else if (suma == 2)
                {
                    acarreo = 1;
                    res[i] = 0;
                }
                else if (suma == 1 && acarreo == 1)
                {
                    res[i] = 0;
                }
                else if (acarreo == 1)
                {
                    res[i] = 1;
                    acarreo = 0;
                }
                else
                {
                    res[i] = suma;
                }
            }
            if (acarreo == 1)
            {
                res[0] = 1;
            }




            Binario R = new Binario(tamu, res, Numdec + Bin2.Numdec);
            Console.WriteLine(Numdec + " + " + Bin2.Numdec + " = " + R.Numdec);
            Console.WriteLine("");
            for (i = 0; i < tamu - tam; i++)
            {
                Console.Write("0");
            }
            imprimir();
            Console.WriteLine();
            for (i = 0; i < tamu - Bin2.tam; i++)
            {
                Console.Write("0");
            }
            Bin2.imprimir();
            Console.WriteLine("+");
            for (i = 0; i < R.tam; i++) Console.Write("-");
            Console.WriteLine();
            if (R.Numdec == 0) Console.Write("0");
            R.imprimir();
        }
        #endregion

        #region Resta
        public void resta(Binario Bin2)
        {
            int tamu;
            int[] Bn1;
            int[] Bn2;
            int[] result;

            convertir();
            Bin2.convertir();
            Bn1 = new int[tam];
            Bn2 = new int[tam];
            tamu = tam;
            for (int i = tam - 1, j = Bin2.tam - 1; i > -1; i--, j--)
            {
                if (j >= 0)
                {
                    Bn1[i] = Bin2.NB[j];
                }
                else
                {
                    Bn1[i] = 0;
                }

            }
            for (int i = 0; i < tam; i++)
            {
                Bn2[i] = NB[i];
            }
            result = new int[tamu];
            int resta;
            for (int i = tamu - 1; i > -1; i--)
            {
                resta = 0;
                if (tam >= Bin2.tam)
                {
                    resta = Bn2[i] - Bn1[i];
                }
                if (resta == 0 || resta == 1)
                {
                    result[i] = resta;
                }
                else if (resta < 0 && i != 0)
                {
                    result[i] = resta + 2;
                    result[i - 1] = Bn2[i - 1] - 1;
                    Bn2[i - 1] = result[i - 1];
                }

            }




            Binario R = new Binario(tamu, result, Numdec - Bin2.Numdec);
            Console.WriteLine(Numdec + " - " + Bin2.Numdec + " = " + R.Numdec);
            Console.WriteLine("");
            if ((Numdec == 1 || Numdec == 0) && (Bin2.Numdec == 1 || Bin2.Numdec == 0)) Console.Write("0");
            for (int i = 0; i < tamu - tam; i++)
            {
                Console.Write("0");
            }
            imprimir();
            Console.WriteLine();
            if ((Bin2.Numdec == 1 || Bin2.Numdec == 0) && (Numdec == 1 || Numdec == 0)) Console.Write("0");
            for (int i = 0; i < tamu - Bin2.tam; i++)
            {
                Console.Write("0");
            }
            Bin2.imprimir();
            Console.WriteLine("-");
            for (int i = 0; i < R.tam; i++) Console.Write("-");
            Console.WriteLine();
            if (R.Numdec == 1 || R.Numdec == 0) Console.Write("0");
            R.imprimir();

        }
        #endregion
        #region Imprimir
        void imprimir()
        {
            bool imp = false;
            if (Numdec == 0)
            {
                imp = true;
                Console.Write("0");
            }
            else
            {
                for (int i = 0; i < tam; i++)
                {
                    if (NB[i] == 1)
                    {
                        imp = true;
                    }
                    if (imp) Console.Write(NB[i]);
                    else Console.Write("0");
                }
            }
            if (imp == false) Console.Write(NB[tam - 1]);
            Console.Write(" ");
        }
    }
}
#endregion