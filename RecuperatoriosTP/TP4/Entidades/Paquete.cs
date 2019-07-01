using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{


    public class Paquete: IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender,EventArgs e);
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
            Entregado
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
        public void MockCicloDeVida() {
            

            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado++;
                this.InformaEstado.Invoke(this.estado, new EventArgs());
            
            }

            PaqueteDao.Insertar(this);


        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }
        public override string ToString()
        {
            return this.MostrarDatos(this);
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
