using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    public class GeneralAtributes
    {
        public static Texture2D _LineTexture { get; set; }
        public static Color BackGroundColor { get; set; }
        public void GenerateTextures(GraphicsDevice graphics)
        {
            _LineTexture = new Texture2D(graphics, 1, 1, false, SurfaceFormat.Color);
            Color[] colorData = { Color.White, };
            _LineTexture.SetData<Color>(colorData);
            BackGroundColor = Color.White;

        }
        public static Color GetBackGroundColor()
        {
            return BackGroundColor;
        }
    }
}
