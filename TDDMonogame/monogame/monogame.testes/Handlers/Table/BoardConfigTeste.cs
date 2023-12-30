using GameHandlers.Table;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace monogame.testes.Handlers.Table
{
    [TestFixture()]
    public class BoardTeste
    {
        private Board _boardGame;
        private SpriteFont _font;
        [SetUp()]
        public void SetUp()
        {
            _font = null;
            _boardGame = new Board(_font);
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
        /// <summary>
        /// Verifica se o board possui sa 9 regiões, 
        /// </summary>
        [TestCase()]
        public void Board_has_9_Regions()
        {
            Assert.That(_boardGame.Regions.Length, Is.EqualTo(9));
        }
        /// <summary>
        /// Verificar se as regiões não estão se sobrepondo.
        /// </summary>
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void Center_Region_Does_Not_Overlap_Lines(int index)
        {
            Assert.That(HasOverLap(_boardGame.Regions[index].Area, _boardGame.Lines, -1), Is.False);
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void Regions_Does_Not_Overlap_Other_Regions(int index)
        {
            Rectangle[] rectangles = new Rectangle[9] {
                new Rectangle(100, 100, 94, 94),
                new Rectangle(206, 100, 88, 94),
                new Rectangle(300, 100, 94, 94),
                new Rectangle(100, 206, 94, 88),
                new Rectangle(206, 206, 88, 88),
                new Rectangle(306, 206, 94, 88),
                new Rectangle(100, 306, 94, 94),
                new Rectangle(206, 306, 88, 94),
                new Rectangle(306, 306, 94, 94)
            };
            Assert.That(HasOverLap(_boardGame.Regions[index].Area, rectangles, index), Is.False);
        }
        
        /// <summary>
        /// Funções de apoio para testes
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        public bool HasOverLap(Rectangle rect, Rectangle[] lines, int index)
        {
            for (int i =0; i < lines.Length; i++)
            {
                if (i != index && rect.Intersects(lines[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
