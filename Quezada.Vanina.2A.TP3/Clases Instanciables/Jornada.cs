using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{


    public class Jornada
    {

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get { return clase; }
            set { clase = value; }
        }
        public Profesor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }


        #endregion
        #region Constructores
        public Jornada()
        {
            alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion
        #region Metodos
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                Texto t = new Archivos.Texto();

                return t.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Jornada.txt", jornada.ToString());
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);

            }
        }
        public static bool Leer(Jornada jornada)
        {
            try
            {
                Texto t = new Archivos.Texto();
                string datos;
                string archivo = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Jornada.txt";
                bool s = t.Leer(archivo, out datos); ;
                Console.WriteLine(datos);
                return s;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);

            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASE DE " + this.clase.ToString() + " POR " + this.instructor.ToString());
            //sb.AppendLine(.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());

            }
            return sb.ToString();
        }
        #endregion
        #region Sobrecargas
      
        public static bool operator ==(Jornada j, Alumno a)
            {

                if (j.alumnos != null)
                {
                    foreach (Alumno item in j.alumnos)
                    {
                        if (item == a)
                            return true;
                    }
                }
                return false;
            }

            public static bool operator !=(Jornada j, Alumno a)
            {
                return !(j == a);
            }

            public static Jornada operator +(Jornada j, Alumno a)
            {
                if (j != a)
                {
                        j.alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }

                return j;
            }
        #endregion
    }
}
