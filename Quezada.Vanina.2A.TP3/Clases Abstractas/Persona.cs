using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;
using Archivos;

namespace EntidadesAbstractas
{

    public abstract class Persona
    {
        protected string apellido;
        protected int dni;
        protected ENacionalidad nacionalidad;
        protected string nombre;

        #region Enum
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Propiedades
        public string Apellido
        {
            set { this.apellido = this.ValidarNombreApellido(value); }
            get { return this.apellido; }
        }
        public int DNI
        {
            set { this.dni = ValidarDNI(this.Nacionalidad, value); }
            get { return this.dni; }
        }
        public ENacionalidad Nacionalidad
        {
            set { this.nacionalidad = value; }
            get { return this.nacionalidad; }
        }
        public string Nombre
        {
            set { this.nombre = this.ValidarNombreApellido(value); }
            get { return this.nombre; }
        }
        public string StringToDNI
        {
            set { this.dni = ValidarDNI(this.Nacionalidad, value); }
        }
        #endregion
        #region Constructores
        public Persona()
        { }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;

        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion
        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.apellido + ", " + this.nombre);
            sb.AppendLine("NACIONALIDAD: " + this.nacionalidad);
            // sb.Append(this._dni);
            return sb.ToString();

        }

        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato >= 89999999) || nacionalidad == ENacionalidad.Extranjero && (dato < 90000000 || dato >= 99999999) )
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");

            else
                return dato;
        }
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            dato = dato.Replace(".", "");

            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());
            int numeroDni;
            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(dato.ToString(), e);
            }

            return this.ValidarDNI(nacionalidad, numeroDni);
        }

        private string ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex(@"[a-zA-Z]*");
            Match match = regex.Match(dato);

            if (match.Success)
                return match.Value;
            else
                return "";

        }

        #endregion
    }
}
