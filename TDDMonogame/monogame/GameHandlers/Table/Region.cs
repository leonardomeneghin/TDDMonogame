﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
        /// <summary>
        /// Identifica se o Estado da região está em uso por um jogador (estado -1 ou 1)
        /// Para um estado não ativo, campo é diferente de (-1 ou 1)
        /// </summary>
        /// <returns>boolean</returns>
        public bool IsActive()
        {
            if (State == 1 || State == -1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Interage com a região modificando o estado e também o player atual caso região esteja inativa (state =0)
        /// Modifica State para (-1 ou 1) e alterna entre os players usando currentPlayer de StateManager.
        /// </summary>
        public void InteractWithRegionByClick()
        {
            if (!IsActive())
            {
                State = StateManager.currentPlayer;
                StateManager.UpdatePlayerState();
            }
        }
        /// <summary>
        /// Retorna um UPPER do simbolo de player (X para 1) e (O para -1)
        /// </summary>
        /// <returns></returns>
        public string GetSymbol()
        {
            switch (State)
            {
                case 1: return "X";
                case -1: return "O";
                default: return "";
            }
        }
    }
}
