using System;
using System.Collections.Generic;


using System.IO;
using System.Xml.Serialization;


namespace Actividad
{
    class Program
    {
        static List<alumno> listaAlumno = new List<alumno>();
        static valdr validar = new valdr();
        static void Main(string[] args)
        {
            int op;
            String temp;
            bool entVald = false;

            do
            {
                Console.Clear();
                pantalla.pantalla1(118, 23);
                Console.SetCursorPosition(55, 2); Console.WriteLine("--- Plataforma Alumnos ---");
                Console.SetCursorPosition(55, 3); Console.WriteLine("--- Menu Principal ---");
                Console.SetCursorPosition(10, 8); Console.WriteLine("1. Crear estudiante");
                Console.SetCursorPosition(10, 9); Console.WriteLine("2. Listar estudiantes");
                Console.SetCursorPosition(10, 10); Console.WriteLine("3. Buscar estudiante");
                Console.SetCursorPosition(10, 11); Console.WriteLine("5. Guardar archivo");
                Console.SetCursorPosition(10, 12); Console.WriteLine("6. Cargar archivo");
                Console.SetCursorPosition(10, 13); Console.WriteLine("0. Salir");


                do
                {
                    Console.SetCursorPosition(10, 15); Console.Write("Digite una opcion ");
                    temp = Console.ReadLine();
                    if (!validar.vacio(temp))
                        if (validar.tipoNum(temp))
                            entVald = true;
                } while (!entVald);

                op = Convert.ToInt32(temp);

                switch (op)
                {
                    case 1:
                        crearEstudiante();
                        break;
                    case 2:
                        listarEstudiantes();
                        break;
                    case 3:
                        buscarEstudiante();
                        break;
                    case 5:
                        guardarXml();
                        break;
                    case 6:
                        cargarXml();
                        break;
                    case 0:
                        Console.SetCursorPosition(10, 16); Console.WriteLine("Cerrando aplicación...");
                        break;
                    default:
                        Console.SetCursorPosition(10, 16); Console.WriteLine("Opcion no valida");
                        break;
                }
                Console.SetCursorPosition(10, 17); Console.WriteLine("--- presione cualquier tecla para continuar ---");
                Console.ReadKey();
            } while (op > 0);
           
        }

        static void crearEstudiante()
        {
            
            string cod, nom, corr, n1, n2, n3;
            bool codval = false;
            bool nomval = false;
            bool corrval = false;
            bool n1val = false;
            bool n2val = false;
            bool n3val = false;
            double nota1 = 0;
            double nota2 = 0;
            double nota3 = 0;

            Console.Clear();
            pantalla.pantalla1(118, 23);
            Console.SetCursorPosition(55, 3); Console.WriteLine("Crear estudiante...");
            

            do
            {
                Console.SetCursorPosition(10, 7); Console.Write("Digite codigo del estudiante: ");
                cod = Console.ReadLine();
                if (!validar.vacio(cod))
                    if (validar.tipoNum(cod))
                        codval = true;
            } while (!codval);

            if (Existe(Convert.ToInt32(cod)))
                Console.WriteLine($"El codigo {cod} ya existe en el sistema");
            else
            {
                do
                {
                    Console.SetCursorPosition(10, 8); Console.Write("Digite nombre del estudiante: ");
                    nom = Console.ReadLine();
                    if (!validar.vacio(nom))
                        if (validar.tipoText(nom))
                            nomval = true;
                } while (!nomval);

                do
                {
                    Console.SetCursorPosition(10, 9); Console.Write("Digite correo del estudiante: ");
                    corr = Console.ReadLine();
                    if (!validar.vacio(corr))
                        if (validar.tipoMail(corr))
                            corrval = true;
                } while (!corrval);

                do
                {
                    Console.SetCursorPosition(10, 10); Console.Write("Digite la primera nota: ");
                    n1 = Console.ReadLine();
                    if (!validar.vacio(n1))
                        if (validar.tipoNum(n1))
                            n1val = true;
                } while (!n1val);

                do
                {
                    Console.SetCursorPosition(10, 11); Console.Write("Digite la segunda nota: ");
                    n2 = Console.ReadLine();
                    if (!validar.vacio(n2))
                        if (validar.tipoNum(n2))
                            n2val = true;
                } while (!n2val);

                do
                {
                    Console.SetCursorPosition(10, 12); Console.Write("Digite la tercera nota: ");
                    n3 = Console.ReadLine();
                    if (!validar.vacio(n3))
                        if (validar.tipoNum(n3))
                            n3val = true;
                } while (!n3val);
               
                nota1 = Double.Parse(n1) * (0.1);
                nota2 = Double.Parse(n2) * (0.1);
                nota3 = Double.Parse(n3) * (0.1);
               
                alumno snAlumno = new alumno();

                snAlumno.Codigo = Convert.ToInt32(cod);
                snAlumno.Nombre = nom;
                snAlumno.Correo = corr;
                snAlumno.Nota1 = nota1;
                snAlumno.Nota2 = nota2;
                snAlumno.Nota3 = nota3;

                
                
                

                listaAlumno.Add(snAlumno);
            }
        }

        static void listarEstudiantes()
        {
            Console.Clear();
            pantalla.pantalla1(118, 23);
            int y = 8;
            double nf;
            string resl;

            Console.SetCursorPosition(55, 3); Console.WriteLine("Lista de empleados");
            

            Console.SetCursorPosition(5, y); Console.Write("Codigo");
            Console.SetCursorPosition(15, y); Console.Write("Nombre");
            Console.SetCursorPosition(35, y); Console.Write("Correo");
            Console.SetCursorPosition(50, y); Console.Write("Primera Nota");
            Console.SetCursorPosition(65, y); Console.Write("Segunda Nota");
            Console.SetCursorPosition(80, y); Console.Write("Tercera Nota");
            Console.SetCursorPosition(95, y); Console.Write("Nota final");
            Console.SetCursorPosition(108, y); Console.Write("Resultado");

            Console.Write("\n");


            foreach (alumno itemAlumno in listaAlumno)
            {
                y++;
                
                nf = (itemAlumno.Nota1 + itemAlumno.Nota2 + itemAlumno.Nota3) / 3;
                itemAlumno.notaFinal = nf;

                if (nf >= 3.5)
                {resl = ("Aprobo"); }
                else resl = ("Reprobo");

                Console.SetCursorPosition(5, y); Console.Write(itemAlumno.Codigo);
                Console.SetCursorPosition(15, y); Console.Write(itemAlumno.Nombre);
                Console.SetCursorPosition(35, y); Console.Write(itemAlumno.Correo);
                Console.SetCursorPosition(50, y); Console.Write(itemAlumno.Nota1.ToString("N2"));
                Console.SetCursorPosition(65, y); Console.Write(itemAlumno.Nota2.ToString("N2"));
                Console.SetCursorPosition(80, y); Console.Write(itemAlumno.Nota3.ToString("N2"));
                Console.SetCursorPosition(95, y); Console.Write(nf.ToString("N2"));
                Console.SetCursorPosition(108, y); Console.Write(resl);
            }
            Console.Write("\n");

        }

        static void buscarEstudiante()
        {
            string cod;
            bool CodigoValido = false;

            Console.Clear();
            pantalla.pantalla1(118, 23);
            Console.SetCursorPosition(55, 3); Console.WriteLine("Buscar Estudiante");
            

            do
            {
                Console.SetCursorPosition(10, 8); Console.Write(" Digite Codigo del estudiante que desea buscar: ");
                cod = Console.ReadLine();
                if (!validar.vacio(cod))
                    if (validar.tipoNum(cod))
                        CodigoValido = true;
            } while (!CodigoValido);

            if (Existe(Convert.ToInt32(cod)))
            {
                alumno snAlumno = obtenerData(Convert.ToInt32(cod));
                Console.SetCursorPosition(10, 9); Console.WriteLine($"Codigo: {snAlumno.Codigo} \t Nombre: {snAlumno.Nombre} \t Correo: {snAlumno.Correo} \n \t Primera Nota: {String.Format("{0,0:0}", snAlumno.Nota1)} \t Segunda Nota: {String.Format("{0:0}", snAlumno.Nota2)} \t Tercera nota: {String.Format("{0:0}", snAlumno.Nota3)}");
            }
            else Console.WriteLine($" El Estudiante {cod} NO  existe en el sistema");
            


        }

        static alumno obtenerData(int cod)
        {
            foreach (alumno objetoAlumno in listaAlumno)
            {
                if (objetoAlumno.Codigo == cod)
                    return objetoAlumno;
            }
            return null;
        }

        static bool Existe(int cod)
        {
            bool aux = false;
            foreach (alumno objetoAlumno in listaAlumno)
            {
                if (objetoAlumno.Codigo == cod)
                    aux = true;
            }
            return aux;
        }

        static void guardarXml()
        {
            XmlSerializer codificador = new XmlSerializer(typeof(List<alumno>));
            TextWriter escribirXml = new StreamWriter("D:/datosNet/listaEstudiantes.xml");
            codificador.Serialize(escribirXml, listaAlumno);
            escribirXml.Close();

            Console.WriteLine(" Archivo Guardado ---- ");
        }

        static void cargarXml()
        {
            listaAlumno.Clear();
            if (File.Exists("D:/datosNet/listaEstudiantes.xml"))
            {
                XmlSerializer codificador = new XmlSerializer(typeof(List<alumno>));
                FileStream leerXml = File.OpenRead("D:/datosNet/listaEstudiantes.xml");
                listaAlumno = (List<alumno>)codificador.Deserialize(leerXml);
                leerXml.Close();
            }
            Console.WriteLine(" Archivo Cargado ---- ");
        }
    }
}



