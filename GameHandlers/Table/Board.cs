using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameHandlers.Helper;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace GameHandlers.Table
{
    public class Board
    {
        public Rectangle[] Lines { get; set; }
        public int Thickness{ get; set; }
        public int Length { get; set; }
        public Region[] Regions { get; set; }
        public MouseState Current { get; set; }
        public MouseState Previous { get; set; }
        private SpriteFont _font { get; set; }

        public const int BASE_INVERT_AXIS = 100;
        public const int FIRST_POSITION = 195;
        public const int SECOND_POSITION = 295;

        private StateManager _stateManager; //Dependência forte aqui, pode ser substituida por interface
        private WinStateManager _winStateManager;
        public Board(SpriteFont font)
        {
            _font = font;
            Thickness = 10;
            Length = 300;
            Lines = new Rectangle[4] {
                new Rectangle(FIRST_POSITION, BASE_INVERT_AXIS, Thickness, Length),
                new Rectangle(SECOND_POSITION, BASE_INVERT_AXIS, Thickness, Length),
                new Rectangle(BASE_INVERT_AXIS, FIRST_POSITION, Length, Thickness),
                new Rectangle(BASE_INVERT_AXIS, SECOND_POSITION, Length, Thickness)
            };
            Regions = new Region[9] { 
                new Region(100, 100, 94, 94, font),
                new Region(206, 100, 88, 94, font),
                new Region(306, 100, 94, 94, font),
                new Region(100, 206, 94, 88, font),
                new Region(206, 206, 88, 88, font),
                new Region(306, 206, 94, 88, font),
                new Region(100, 306, 94, 94, font),
                new Region(206, 306, 88, 94, font),
                new Region(306, 306, 94, 94, font)
            };

        }
        public Board(SpriteFont font, StateManager stateManager, WinStateManager winStateManager) : this(font)
        {
            _stateManager = stateManager;
            _winStateManager = winStateManager;
        }
        public void Update(GameTime gameTime)
        {
            if (_winStateManager.CanKeepPlaying)
            {
                UpdateMouse(Mouse.GetState());
                UpdateClicks(_stateManager.ClickedRegion(Regions, Current, Previous));
                _winStateManager.Update(Regions);
            }

        }
        public void UpdateMouse(MouseState internalMouseState)
        {
            Previous = Current;
            Current = internalMouseState;
        }
        public void Draw(SpriteBatch sb)
        {
            
            foreach (Rectangle line in Lines)
            {
                sb.Draw(GeneralAtributes._LineTexture, line, Color.White);
            }
            DrawRegions(sb);
            DrawWinner(sb);
        }
        internal void DrawRegions(SpriteBatch sb) //Interessante usar o Draw de seu proprio objeto passando SpriteBatch, pois assim cada classe
            //Fica responsável por desenhar o que está dentro de si.
        {
            foreach (var region in Regions)
            {
                region.Draw(sb);
            }
        }
        public void DrawWinner(SpriteBatch sb)
        {
            if(!_winStateManager.CanKeepPlaying && !string.IsNullOrEmpty(_winStateManager.PlayerWhoWon))
                sb.DrawString(_font, _winStateManager.PlayerWhoWon, new Vector2(400, 100), Color.White);
        }
        public void UpdateClicks(int idx)
        {
            _stateManager.UpdateClickedRegion(Regions, idx);
        }
    }
}
