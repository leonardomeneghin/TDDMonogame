using monogame.Scripts;
using NUnit.Framework;


namespace monogame.teste
{
    [TestFixture()]
    public class UnitTest1
    {
        private Tester tester;
        [SetUp]
        public void TestSetUp()
        {
            tester = new Tester();
        }
        [Test()]
        public void TestCase()
        {
            Assert.That(true, Is.EqualTo(tester.isBool()));
        }
    }
}