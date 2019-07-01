using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Entidades
{
  public class Correo: IMostrar <List<Paquete>>
  {
    private List<Thread> mockPaquetes;
    private List<Paquete> paquetes;

    #region Propiedades

    public List<Paquete> Paquetes
    {
      get { return paquetes; }
      set { paquetes = value; }
    }

    #endregion
    #region Constructores
    public Correo() {

            this.mockPaquetes = new List<Thread>();
                this.paquetes = new List<Paquete>();

        }
    #endregion
    #region Metodos
    public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                item.Abort();
            }

    }
    public string MostrarDatos(IMostrar<List<Paquete>> elementos)
    {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete item in ((Correo)elementos).paquetes)
            {
                sb.AppendLine(String.Format("{0} para {1} ({2})", item.TrackingID, item.DireccionEntrega, item.Estado.ToString()));
            }

      return sb.ToString();
    }
    #endregion
    #region Sobrecargas
    public static Correo operator +(Correo c, Paquete p)
    {
            foreach (Paquete item in c.paquetes)
            {
                if(item == p){
                    throw new TrackingIdRepetidoException("El Tracking ID " + item.TrackingID.ToString() + " ya figura en la lista de envios.");
                } 
            }
            c.paquetes.Add(p);
            Thread t = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(t);
            t.Start();
            return c;
    }
    #endregion
  }
}
