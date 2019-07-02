using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Unitarios2
{
    [TestClass]
    public class TestTP4
    {
        [TestMethod]
        public void ValidaListaPaquetesInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);

        }
        [TestMethod]
        public void ValidaTrackingIdDuplicado()
        {

            string track = "456-789-789";
            try
            {

                Correo correo = new Correo();
                Paquete p = new Paquete(track, "d");
                Paquete p2 = new Paquete(track, "d");


                     correo += p;
                    correo += p2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
