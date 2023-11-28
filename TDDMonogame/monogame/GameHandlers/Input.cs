using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHandlers
{
    public class Input
    {
        public static bool IsMouseClicked(MouseState mouseState, MouseState mousePreviousState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && mousePreviousState.LeftButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }
    }
}
