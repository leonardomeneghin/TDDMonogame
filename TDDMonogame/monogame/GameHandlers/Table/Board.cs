using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHandlers.Table
{
    public class Board
    {
        public Rectangle[] Lines { get; set; }
        public int Thickness{ get; set; }
        public int Length { get; set; }
        
        public Board()
        {
            Thickness = 10;
            Length = 300;
            Lines = new Rectangle[4] {
                new Rectangle(195, 100, Thickness, Length),
                new Rectangle(295, 100, Thickness, Length),
                new Rectangle(100, 195, Length, Thickness),
                new Rectangle(100, 295, Length, Thickness)
            };
        }
        public void Draw(SpriteBatch sb)
        {
            
            foreach (Rectangle line in Lines)
            {
                sb.Draw(GenerateTexturesHelper._LineTexture, line, Color.White);
            }
        }
    }
}
