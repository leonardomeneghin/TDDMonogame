using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameHandlers.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame.testes.Screen
{
    [TestFixture()]
    public class GeneralGameSettingsTest
    {
        [TestCase()]
        public void Is_BackGround_White()
        {
            Assert.That(GeneralAtributes.BackGroundColor(), Is.EqualTo(Color.White));
        }

    }
}
