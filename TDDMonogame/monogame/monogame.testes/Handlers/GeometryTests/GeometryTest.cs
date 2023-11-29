using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame.testes.Handlers.GeometryTests
{
    [TestFixture()]
    public class GeometryTest
    {
        private MouseState correctMouseStateRegion;
        private MouseState smallerThanRegion;
        private MouseState greaterThanRegion;
        private Rectangle rect;
        [SetUp]
        public void SetUp()
        {
            correctMouseStateRegion = new MouseState(50, 80, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            smallerThanRegion = new MouseState(10, 10, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            greaterThanRegion = new MouseState(1000, 1000, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            rect = new Rectangle(30, 60, 40, 40);
        }
        /// <summary>
        /// Caso de teste: Testar se mouse está em uma região do retângulo onde se posicionaria X e O.
        //InputsTests: Mouse
        //OutputsTests: True se estiver na região, false se não estiver.
        /// </summary>
        [TestCase()]
        public void Is_Mouse_Position_Inside_Region()
        {
            Assert.That(GameHandlers.Table.Region.IsInRegion(correctMouseStateRegion, rect), Is.True);
        }
        [TestCase()]
        public void State_Position_Is_Out_Of_Region()
        {
            MouseState outOfRegionState = new MouseState(10, 10, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(GameHandlers.Table.Region.IsInRegion(outOfRegionState, rect), Is.False);
        }
        [TestCase()]
        public void State_Position_Greater_Than_Region()
        {
            MouseState outOfRegionState = new MouseState(1000, 1000, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(GameHandlers.Table.Region.IsInRegion(outOfRegionState, rect), Is.False);
        }
    }
}
