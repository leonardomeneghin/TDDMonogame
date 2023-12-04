using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace GameHandlers.Table
{
    public class Region
    {
        public int State { get; set; }
        public Rectangle Area { get; set; }

        public Region()
        {
            State = 0;
        }
        public Region(int x, int y, int width, int height) : this ()
        {
            Area = new Rectangle(x, y, width, height);
        }

        public static bool IsInRegion(MouseState mouse, Rectangle rect)
        {
            if (rect.Contains(mouse.X, mouse.Y))
            {
                return true;
            }
            return false;
        }

        public static bool MouseHasClickedRegion(MouseState currentMouseState, MouseState previousMouseState, Rectangle rect)
        {
            if (IsInRegion(currentMouseState, rect) && (Input.IsMouseClicked(currentMouseState, previousMouseState)))
            {
                return true;
            }
            return false;
        }
        public bool ShouldChangeState()
        {
            if (this.State != 0)
                return false;
            return true;
        }
        public void InteractWithRegionByClick(MouseState currentMouseState, MouseState previousMouseState)
        {
            if (MouseHasClickedRegion(currentMouseState, previousMouseState, this.Area) && ShouldChangeState())
            {
                this.State = 1;
            }
        }
    }
}
