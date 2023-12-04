﻿using Microsoft.Xna.Framework;
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
        public Region[] Regions { get; set; }
        public const int BASE_INVERT_AXIS = 100;
        public const int FIRST_POSITION = 195;
        public const int SECOND_POSITION = 295;

        public Board()
        {
            Thickness = 10;
            Length = 300;
            Lines = new Rectangle[4] {
                new Rectangle(FIRST_POSITION, BASE_INVERT_AXIS, Thickness, Length),
                new Rectangle(SECOND_POSITION, BASE_INVERT_AXIS, Thickness, Length),
                new Rectangle(BASE_INVERT_AXIS, FIRST_POSITION, Length, Thickness),
                new Rectangle(BASE_INVERT_AXIS, SECOND_POSITION, Length, Thickness)
            };
            Regions = new Region[9] { 
                new Region(100, 100, 94, 94),
                new Region(206, 100, 88, 94),
                new Region(306, 100, 94, 94),
                new Region(100, 206, 94, 88),
                new Region(206, 206, 88, 88),
                new Region(306, 206, 94, 88),
                new Region(100, 306, 94, 94),
                new Region(206, 306, 88, 94),
                new Region(306, 306, 94, 94)
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