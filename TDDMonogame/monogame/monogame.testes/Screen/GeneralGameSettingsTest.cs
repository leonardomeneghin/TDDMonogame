using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monogame.GameScene;
namespace monogame.testes.Screen
{
    [TestFixture()]
    public class GeneralGameSettingsTest
    {
        [TestCase()]
        public void Is_BackGround_White()
        {
            Assert.That(GameGeneralConfig.GetBackGroundColor(), Is.EqualTo(Color.White));
        }

    }
}
