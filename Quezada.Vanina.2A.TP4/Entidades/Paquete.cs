using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoEstado();
           
    public class Paquete: IMostrar<List<Paquete>>
    {
        public event DelegadoEstado InformaEstado;
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region Propiedades
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        #endregion

        #region Enum
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregaado
        }
        #endregion

        #region Constructores
        public Paquete(string direccionEntrega, string trakingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trakingID;
        }


        #endregion

        #region Metodos
        public void MockCicloDeVida() { }
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            return "";
        }
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
        #region Sobrecargas
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;
        }

        #endregion
    }
}
