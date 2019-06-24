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
    public Correo() { }
    #endregion
    #region Metodos
    public void FinEntregas()
    {

    }
    public string MostrarDatos(IMostrar<List<Paquete>> elementos)
    {
      return "";
    }
    #endregion
    #region Sobrecargas
    public static Correo operator +(Correo c, Paquete p)
    {
      return c;
    }
    #endregion
  }
}
