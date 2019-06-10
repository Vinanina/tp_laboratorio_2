using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        
        #region Enum
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
        #region Propiedades
            public List<Alumno> Alumnos
            {
                get { return this.alumnos; }
                set { this.alumnos = value; }
            }

            public List<Profesor> Instructores
        {
                get { return this.profesores; }

            }

            public List<Jornada> Jornada
            {
                get { return this.jornada; }
            }

            public Jornada this[int index]
            {
                get
                {
                    if (index < this.jornada.Count || index > this.jornada.Count)
                        return this.jornada[index];
                    else
                        return null;
                }
            }

        #endregion
        #region Constructores
            public Universidad()
            {
                this.alumnos = new List<Alumno>();
                this.profesores = new List<Profesor>();
                this.jornada = new List<Jornada>();
            }
        #endregion
        #region Metodos
        public static bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> guardar = new Xml<Universidad>();

                string archivo = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\universidad.xml";

                return guardar.Guardar(archivo, uni);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);

            }
        }
        public static bool Leer()
        {
            try
            {
                Xml<Universidad> leer = new Xml<Universidad>();
                string archivo = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\universidad.xml";
                Universidad datos;
                bool s = leer.Leer(archivo, out datos);
                Console.WriteLine(datos);
                return s;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);

            }
        }
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada j in uni.Jornada)
            {
                sb.Append(j.ToString());
                sb.AppendLine("<-------------------------------------------->");
            }

            return sb.ToString();

        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        //        Clase Universidad:
        // Atributos Alumnos(lista de inscriptos), Profesores(lista de quienes pueden dar clases) y Jornadas.
        // Se accederá a una Jornada específica a través de un indexador.
        // Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        // Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        // Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman(todos los que coincidan en su campo ClaseQueToma).
        // Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        #region Sobrecargas

        public static bool operator ==(Universidad u, Alumno a)
        {
            foreach (Alumno alumno in u.alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor i in u.profesores)
            {
                if (i == clase)
                    return i;
            }
            throw new Excepciones.SinProfesorException();

        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {


            return u == clase;


        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor inst in g.profesores)
            {
                if (inst == i)
                    return true;
            }
            return false;

        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u== a)
                throw new AlumnoRepetidoException();
            else
                u.alumnos.Add(a);

            return u;

        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);

            foreach (Alumno a in g.alumnos)
            {
                if (a == clase)
                    j += a;
            }
            g.jornada.Add(j);
            return g;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u.profesores == null || u != i)
                u.profesores.Add(i);
            return u;
        }

        #endregion
    }
}
