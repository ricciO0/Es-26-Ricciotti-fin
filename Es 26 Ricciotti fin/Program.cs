using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_26_Ricciotti_fin
{
    internal class Program
    {
        static void Main(string[] args)
        {

            listaFigure list = new listaFigure();

            list.Add(new Rombo(10, 10, 5, 4));
            list.Add(new Rombo(3, 3, 2, 7));
            list.Add(new Rombo(7, 7, 8, 2));

            list.Add(new Triangolo(2, 3, 2, 3));
            list.Add(new Triangolo(5, 5, 5, 4));

            list.Add(new Rettangolo(4, 7));
            list.Add(new Rettangolo(11, 6));

            list.Add(new Quadrato(5, 5));
            list.Add(new Quadrato(15, 15));

            list.Add(new Circonferenza(5));
            list.Add(new Circonferenza(20));
            list.Add(new Circonferenza(22));





            Console.WriteLine(list.Stampa());
            Console.WriteLine("\n--------------------------------------------------------------------\n");
            list.Sort();
            Console.WriteLine(list.Stampa());
            Console.WriteLine("\n--------------------------------------------------------------------\n");
            Console.WriteLine(list.Find());
            Console.WriteLine("\n--------------------------------------------------------------------\n");
            list.Remove();
            Console.WriteLine(list.Stampa());
            Console.WriteLine("\n--------------------------------------------------------------------\n");
            list.RemoveAt(1);
            Console.WriteLine(list.Stampa());

            Console.WriteLine(" \n");

            list.AreaMaggior();
            list.PerimetroMinoor();
            Console.WriteLine("\n --------------------------------------------------------------------\n");

            listaFigure areeMaggiori = new listaFigure(list.Aree_maggiori());
            Console.WriteLine(areeMaggiori.Stampa());
            ///////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Prove Equals");

            FiguraGeometrica ret = new Rettangolo(4, 7);

            FiguraGeometrica tri = new Triangolo(2, 3, 2, 3);

            FiguraGeometrica cer = new Circonferenza(3);

            FiguraGeometrica qua = new Quadrato(5, 5);

          //  tri.Equals(ret);

            qua.Equals(cer);

            cer.Equals(tri);

            Console.ReadKey();

        }

        public abstract class FiguraGeometrica : List<FiguraGeometrica>, IComparable<FiguraGeometrica>, ICloneable
        {
            protected string nome;
            protected double area;
            protected double perimetro;

            abstract public string Nome();
            abstract public double Area();
            abstract public double Perimetro();

            public int CompareTo(FiguraGeometrica b)
            {
                if (this.area == b.Area())
                {
                    return 0;
                }
                else if (this.area > b.Area())
                {
                    return 1;
                }

                return -1;
            }


            object ICloneable.Clone()
            {
                return (object)this.Clone();
            }

            abstract public FiguraGeometrica Clone();

            abstract public bool Equals(object other);

            public override string ToString()
            {
                return "" + this.nome + ";    Perimetro = " + this.perimetro + ";       Area = " + this.area;
            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public class Triangolo : FiguraGeometrica
        {
            private double l1;
            private double l2_base;
            private double l3;
            private double altezza;

            public override string Nome() => nome;

            public override double Area() => area;
            public override double Perimetro() => perimetro;

            public Triangolo(double l1, double l2, double l3, double altezza)
            {
                this.nome = "Triangolo";
                this.l1 = l1;
                this.l2_base = l2;
                this.l3 = l3;
                this.altezza = altezza;

                this.area = (l2_base * altezza) / 2;
                this.perimetro = l1 + l2 + l3;
            }

            public override FiguraGeometrica Clone()
            {
                return new Triangolo(l1, l2_base, l3, altezza);
            }

            public override bool Equals(object other)
            {
                FiguraGeometrica n = (FiguraGeometrica)other;

                if(!(n is Triangolo))
                {
                    throw new FiguraErrata("Il parametro inserito è una figura diversa dal " + nome, n);
                }


                if (this.Area() == n.Area() && this.Perimetro() == n.Perimetro())
                {
                    return true;
                }
                

                return false;
            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public class Rettangolo : FiguraGeometrica
        {
            protected double l;
            private double b;

            public override string Nome() => nome;

            public override double Area() => area;

            public override double Perimetro() => perimetro;

            public Rettangolo(double l1, double b1)
            {
                this.nome = "Rettangolo";
                this.l = l1;
                this.b = b1;


                this.area = l * b;
                this.perimetro = (l * 2) + (b * 2);
            }


            public override FiguraGeometrica Clone()
            {
                return new Rettangolo(l, b);
            }

            public override bool Equals(object other)
            {
                FiguraGeometrica n = (FiguraGeometrica)other;

                if(!(n is Rettangolo))
                {
                    throw new FiguraErrata("Il parametro inserito è una figura diversa dal " + nome, n);
                }


                if (this.Area() == n.Area() && this.Perimetro() == n.Perimetro())
                {
                    return true;
                }
                

                return false;
            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public class Quadrato : Rettangolo
        {


            public Quadrato(double l1, double b1) : base(l1, b1)
            {
                this.nome = "Quadrato";
                this.l = l1;


                this.area = l * l;
                this.perimetro = l * 4;
            }

            public override string Nome() => nome;

            public override double Area() => area;

            public override double Perimetro() => perimetro;

            public override FiguraGeometrica Clone()
            {
                return new Quadrato(l, l);
            }

            public override bool Equals(object other)
            {

                Quadrato n;
                try
                {
                     n = (Quadrato)other;
                }
                catch(InvalidCastException ex)
                {
                    Console.WriteLine("Casting non corretto!\n"+ex);
                    return false;
                }

                 n = (Quadrato)other;


                if (this.Area() == n.Area() && this.Perimetro() == n.Perimetro())
                {
                    return true;
                }
                

                return false;
            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public class Circonferenza : FiguraGeometrica
        {
            private double r;

            public override string Nome() => nome;

            public override double Area() => area;
            public override double Perimetro() => perimetro;

            public Circonferenza(double r)
            {
                this.nome = "Circonferenza";
                this.r = r;


                this.area = (r * r) * Math.PI;
                this.perimetro = r * 2 * Math.PI;
            }


            public override FiguraGeometrica Clone()
            {
                return new Circonferenza(r);
            }

            public override bool Equals(object other)
            {
                Circonferenza n;

                try
                {
                    n = (Circonferenza)other;
                }
                catch(InvalidCastException ex)
                {
                    Console.WriteLine("Casting non corretto!\n" + ex);
                    return false;
                }

                n = (Circonferenza)other;


                if (this.Area() == n.Area() && this.Perimetro() == n.Perimetro())
                {
                    return true;
                }
              

                return false;
            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public class Rombo : Quadrato
        {
            private double D;
            private double d;


            public override string Nome() => nome;

            public override double Area() => area;
            public override double Perimetro() => perimetro;

            public Rombo(double l1, double b1, double D, double d) : base(l1, b1)
            {
                this.nome = "Rombo";
                this.D = D;
                this.d = d;
                this.l = l1;


                this.area = (D * d) / 2;
                this.perimetro = l * 4;
            }


            public override FiguraGeometrica Clone()
            {
                return new Rombo(l, l, D, d);
            }

            public override bool Equals(object other)
            {
                FiguraGeometrica n = (FiguraGeometrica)other;
                if(!(n is Rombo))
                {
                    throw new FiguraErrata("Il parametro inserito è una figura diversa dal " + nome, n);
                }

                if (this.Area() == n.Area() && this.Perimetro() == n.Perimetro())
                {
                    return true;
                }
                

                return false;
            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public class listaFigure
        {
            List<FiguraGeometrica> lista;

            public listaFigure()
            {
                lista = new List<FiguraGeometrica>();
            }

            public listaFigure(List<FiguraGeometrica> lista)
            {
                this.lista = lista;
            }

            public int Add(FiguraGeometrica a)
            {
                lista.Add(a);

                return lista.Count - 1;
            }

            public void Sort()
            {
                lista.Sort();// sort utilizza come metodo di comparazione il compareTo della figurageometrica in automatico
            }

            private static bool Find_10(FiguraGeometrica obj)
            {
                return obj.Area() > 10;
            }

            public FiguraGeometrica Find()
            {
                Predicate<FiguraGeometrica> predicate = Find_10; //condicìzione del ritrovamento
                Console.WriteLine("la seguente figura geometrica ha l'area maggiore di 10 ");
                return lista.Find(predicate);
            }

            public void Remove()
            {
                lista.Remove(lista.Last());
            }

            public void RemoveAt(int i)
            {
                lista.RemoveAt(i);

            }


            public double AreaMaggior()
            {
                double conta = 0;
                FiguraGeometrica fin = lista[0];
                foreach (FiguraGeometrica f in lista)
                {
                    if (f.Area() > conta)
                    {
                        fin = f;
                        conta = f.Area();

                    }
                }
                Console.WriteLine("La figura con l'area maggiore è " + fin.Nome());

                return conta;
            }




            public string Stampa()
            {
                string ris = "";

                foreach (FiguraGeometrica n in lista)
                {
                    ris = ris + " \n" + n;
                }
                return ris;
            }

            public double PerimetroMinoor()
            {

                FiguraGeometrica fin = lista[0];
                double conta = -1;
                foreach (FiguraGeometrica f in lista)
                {
                    if (conta == -1)
                    {
                        conta = f.Perimetro();
                    }
                    else if (f.Perimetro() < conta)
                    {
                        fin = f;
                        conta = f.Perimetro();

                    }
                }
                Console.WriteLine("La figura con il perimetro minore è " + fin.Nome());
                return conta;
            }


            public List<FiguraGeometrica> Aree_maggiori()
            {
                List<Type> tipi = new List<Type>();
                List<FiguraGeometrica> a = new List<FiguraGeometrica>();
                double conta = 0;

                foreach (FiguraGeometrica n in lista)
                {
                    if (!tipi.Contains(n.GetType()))
                    {
                        tipi.Add(n.GetType());
                    }

                }


                foreach (Type t in tipi)
                {
                    conta = 0;
                    FiguraGeometrica fin = lista[0];
                    foreach (FiguraGeometrica f in lista)
                    {
                        if (t == f.GetType())
                        {
                            if (f.Area() > conta)
                            {
                                fin = f;
                                conta = f.Area();

                            }
                        }
                    }
                    a.Add(fin);
                }

                return a;

            }

        }

        [Serializable]
        public class FiguraErrata : Exception
        {

            object param;

            public FiguraErrata(string message,object param): base(message)
            {
                this.param = param;
            }

            public override string ToString()
            {
                string ris= base.ToString();
                ris += "Valore parametro: " + this.param;

                return ris;
            }
        }
    }
}
