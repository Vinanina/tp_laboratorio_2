using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{

    public abstract class Universitario :Persona
    {
        private int legajo;

        #region Constructores
        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;

        }
        #endregion
        #region Metodos
        public override bool Equals(object obj)
        {
            bool same = false;
            if (this.GetType().Equals(obj.GetType()))
            {
                same = true;
            }
            return same;
        }
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append("LEGAJO NÚMERO: " + this.legajo);
         
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return ((pg1.Equals(pg2) && (pg1.DNI == pg2.DNI)) || (pg1.Equals(pg2) && (pg1.legajo == pg2.legajo)));
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

    }
}
