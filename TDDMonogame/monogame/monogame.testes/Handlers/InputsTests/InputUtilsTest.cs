using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame.testes.Handlers.InputsTests
{
    [TestFixture]
    public class InputUtilsTest
    {
        private MouseState mouse;
        [SetUp] public void TestSetup()
        {
            mouse = new MouseState(0, 0, 0,
                ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }
        [TestCase()]
        public void Is_Clicked_Should_Return_True_For_Clicked_State()
        {
            Assert.That(GameHandlers.Input.IsMouseClicked(mouse), Is.True);




        }
    }
}
