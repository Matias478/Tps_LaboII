using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

namespace UnitTesting
{
    [TestClass]
    public class UnitTestExtension
    {
        [TestMethod]
        public void TestMethod_ExtensionJson()
        {
            //Assert
            string expected = ".json";

            //Act
            ExtJson<Cliente> ext = new ExtJson<Cliente>();
            string actual = ext.Extension;

            //Arrange
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestMethod_ExtensionXml()
        {
            //Assert
            string expected = ".xml";

            //Act
            ExtXml<Cliente> ext = new ExtXml<Cliente>();
            string actual = ext.Extension;

            //Arrange
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestMethod_TestInsertar()
        {
            Assert.IsTrue(SQLManagment.Insertar(new(100,"asd","dsa",43234323,1123233223,EClases.KickBoxing,EHorarios.TurnoMañana))==true);
        }

        [ExpectedException(typeof(DatosNoValidosException))]
        [TestMethod]
        public void TestMethod_TestVerficarDatos()
        {
            //Assert
            bool expected = true;
            //Act
            bool actual = Negocio.VerificarDatos(4324332, 123433443);// tira la excepcion que se expecta

            //Arrange
            Assert.AreEqual(expected , actual);
        }

    }
}
