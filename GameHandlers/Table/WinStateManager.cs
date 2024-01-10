using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHandlers.Table
{
    public class WinStateManager
    {
        public string PlayerWhoWon { get; set; }
        public bool CanKeepPlaying { get; set; }
        public WinStateManager()
        {
            PlayerWhoWon = string.Empty;
            CanKeepPlaying = true;
        }

        public int WichPlayerWon(Region[] regions)
        {
            //pt-br: N usar variáveis aqui, tipo c1+n => isso cria um b.o. pra outro desenvolvedor ler;
            //en-US: te vira. zuera... : don't use variables like c1+n here, because its hard to developers read it.
            var row1 = HasWon(new Region[] { regions[0], regions[1], regions[2] });
            var row2 = HasWon(new Region[] { regions[3], regions[4], regions[5] });
            var row3 = HasWon(new Region[] { regions[1], regions[4], regions[7] });


            var col1 = HasWon(new Region[] { regions[0], regions[3], regions[6] });
            var col2 = HasWon(new Region[] { regions[1], regions[4], regions[7] });
            var col3 = HasWon(new Region[] { regions[2], regions[5], regions[8] });

            var mainDiagonal = HasWon(new Region[] { regions[0], regions[4], regions[8] });
            var opositeDiagonal = HasWon(new Region[] { regions[2], regions[4], regions[6] });

            return DetermineWinner(new int[] { row1, row2, row3, col1, col2, col3, mainDiagonal , opositeDiagonal });
        }

       public int HasWon( Region[] regions)
        {
            //Human designed
            //return (regions.Where(x => x.State == 1).All(r => r == regions[0] && r == regions[1] && r == regions[2])
            //    || regions.Where(x => x.State == -1).All(r => r == regions[0] && r == regions[1] && r == regions[2])) ? regions[0].State : 0;

            //Monter designed
            return ((regions[0].State == 1 && regions[1].State == 1 && regions[2].State == 1)
                || regions[1].State == -1 && regions[1].State == -1 && regions[2].State == -1
                ) ? regions[0].State : 0;

        }

        public int DetermineWinner(int[] fields)
        {
            foreach (var field in fields)
            {
                if (field != 0)
                    return field;
            }
            return 0;
        }
        public void Update(Region[] regions)
        {
            var won = WichPlayerWon(regions);
            switch (won)
            {
                case 1:
                    CanKeepPlaying = false;
                    PlayerWhoWon = "P1 (X) Won !!!";
                    break;
                case -1:
                    CanKeepPlaying = false;
                    PlayerWhoWon = "P2 (O) Won !!!";
                    break;
                default:
                    break;
            }
        }
    }
}
