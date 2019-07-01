using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public static class GuardaString
  {
    public static bool Guardar(this string texto,string archivo) {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +"\\"+ archivo, true))
                {
                    file.WriteLine(texto);
                }

                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error en al guardar datos", e);
            }
           
    }
  }
}
