using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest1
    {

        //Comprueba que el dni del profesor no pueda tener mas de 89999999
        [TestMethod]
        public void DNIInvalidoProfesor()
        {
            // Casi 1 dni largo
            string dniComa = "90000000";
            try
            {
              
                Profesor profesorP = new Profesor(1, "Juan", "Lopez", dniComa, EntidadesAbstractas.Persona.ENacionalidad.Argentino);
               
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniComa);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            // Caso dni con texto
            string dniTexto = "30a00123";
            try
            {
                
                Profesor profesorPrimero = new Profesor(1, "Juan", "Lopez", dniTexto, EntidadesAbstractas.Persona.ENacionalidad.Argentino);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniTexto);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }


        }
        //Dni con ramdom entre rangos validos
        [TestMethod]
        public void DniRandomArgentino()
        {
            // CASO 1 DNI al azar
            string dniMedio = (new Random().Next(1, 89999999)).ToString();

            Profesor personaMedio = new Profesor(1, "Juan", "Lopez", dniMedio, EntidadesAbstractas.Persona.ENacionalidad.Argentino);

            Assert.AreEqual(personaMedio.DNI, Int32.Parse(dniMedio));
           
        }

        //Comprueba que el dni del profesor no pueda se menos de 1
        [TestMethod]
        public void ProfesorDniMenor1()
        {            // CASO  Dni menor 1
            string dniMenor1 = "1";
            Profesor profesorDniMenor = new Profesor(1, "Juan", "Lopez", dniMenor1, EntidadesAbstractas.Persona.ENacionalidad.Argentino);

            Assert.AreEqual(profesorDniMenor.DNI, Int32.Parse(dniMenor1));

        }


        //Comprueba que algun dato del profesor no pueda ser null
        [TestMethod]
        public void ProfesorNoNulo()
        {
            string dni = "456";
            Profesor profesor = new Profesor(1, "Juan", "Lopez", dni, EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Assert.IsNotNull(profesor.DNI);
        }


    }
}
