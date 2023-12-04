using GameHandlers.Table;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame.testes.Handlers.Table
{
    [TestFixture()]
    public class BoardTeste
    {
        private Board _boardGame;
        [SetUp()]
        public void SetUp()
        {
            _boardGame = new Board();
        }
        /// <summary>
        /// Verifica se o board possui 4 linhas.
        /// </summary>
        [TestCase()]
        public void Lines_Of_Board_Should_Be_Equal_Four()
        {
            Assert.That(_boardGame.Lines.Length, Is.EqualTo(4));
        }
        /// <summary>
        /// Verifica se no array indicado, os objetos são instâncias de Retângulo.
        /// </summary>
        [TestCase()]
        public void Lines_Are_Rectangles()
        {
            foreach (var line in _boardGame.Lines)
            {
                Assert.That(line, Is.InstanceOf<Rectangle>());
            }
        }
        /// <summary>
        /// Verifica Dimensões do board
        /// </summary>
        [TestCase()]
        public void Thickness_and_Length_of_Board()
        {
            
            Assert.That(_boardGame.Length, Is.EqualTo(300));
            Assert.That(_boardGame.Thickness, Is.EqualTo(10));
        }
        /// <summary>
        /// Verifica se o Tamanho do retangulo é correto
        /// Input: 
        ///     index (indice do array - int), 
        ///     X (position - int), 
        ///     Y (Position - int), 
        ///     width (largura - int), 
        ///     height (tamanho - int)
        /// </summary>
        [TestCase(0, 195, 100, 10, 300)]
        [TestCase(1, 295, 100, 10, 300)]
        [TestCase(2, 100, 195, 300, 10)]
        [TestCase(3, 100, 295, 300, 10)]
        public void Check_Rectangles_Size_Are_Correct(int index, int X, int Y, int width, int height)
        {
            Assert.That(_boardGame.Lines[index], Is.EqualTo(new Rectangle(X, Y, width, height)));
        }
    }
}
