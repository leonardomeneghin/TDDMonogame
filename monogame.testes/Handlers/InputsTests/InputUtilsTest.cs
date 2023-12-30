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
        private MouseState buttonPressedState;
        private MouseState buttonReleasedState;
        [SetUp] public void TestSetup()
        {
            buttonPressedState = new MouseState(0, 0, 0,
                ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);

            buttonReleasedState = new MouseState(0, 0, 0,
                ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }
        /// <summary>
        /// Determinar aqui qual o cenário de teste está sendo coberto, suas especificações e qual o resultado esperado.
        /// </summary>
        [TestCase()]
        public void Is_Clicked_Should_Return_True_For_Clicked_State()
        {
            Assert.That(GameHandlers.Input.IsMouseClicked(buttonPressedState, buttonReleasedState), Is.True); //Pressiona + Havia soltado (sim click)

        }
        [TestCase()]
        public void Is_Clicked_Should_Return_False_For_UnClicked_State()
        {
            Assert.That(GameHandlers.Input.IsMouseClicked(buttonReleasedState, buttonReleasedState), Is.False); //Não pressiona + Havia soltado (não click)

        }
        [TestCase()]
        public void Is_Clicked_Should_Return_False_For_Released_State()
        {
            Assert.That(GameHandlers.Input.IsMouseClicked(buttonReleasedState, buttonReleasedState), Is.False); //Soltou + havia soltado (não click)

        }
        [TestCase()]
        public void Is_Clicked_Should_Return_False_For_Pressed_State()
        {
            Assert.That(GameHandlers.Input.IsMouseClicked(buttonPressedState, buttonPressedState), Is.False); //Pressionou + havia pressionado (não click)

        }
        
    }
}
