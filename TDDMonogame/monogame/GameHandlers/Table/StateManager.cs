﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GameHandlers.Table
{
    public class StateManager
    {
        public int ClickedRegion(Region[] regions, MouseState currentMouseState, MouseState previousMouseState)
        {
            for(int i=0; i<regions.Length; i++)
            {
                if (Region.MouseHasClickedRegion(currentMouseState, previousMouseState, regions[i].Area)) 
                {
                    return i;
                }
            }
            return -1;
        }

        public void UpdateClickedRegion(Region[] regions, MouseState currentMouseState, MouseState previousMouseState)
        {
            var index = ClickedRegion(regions, currentMouseState, previousMouseState);
            if (index !=-1)
            {
               regions[index].InteractWithRegionByClick();
            }
            

        }
    }
}