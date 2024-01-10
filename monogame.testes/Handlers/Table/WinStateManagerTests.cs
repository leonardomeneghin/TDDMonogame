using GameHandlers.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame.testes.Handlers.Table
{
    [TestFixture()]
    public class WinStateManagerTests
    {
        Region[] _regions;
        WinStateManager _winStateManager;
        [SetUp]
        public void SetUp()
        {
            _regions  = new Region[9] {
                new Region(100, 100, 94, 94, null),
                new Region(206, 100, 88, 94, null),
                new Region(306, 100, 94, 94, null),
                new Region(100, 206, 94, 88, null),
                new Region(206, 206, 88, 88, null),
                new Region(306, 206, 94, 88, null),
                new Region(100, 306, 94, 94, null),
                new Region(206, 306, 88, 94, null),
                new Region(306, 306, 94, 94, null)
            };
            _winStateManager = new WinStateManager();
        }
        [Test()]
        public void When_have_rows_with_0_state_dont_win()
        {
            Assert.That(_winStateManager.WichPlayerWon(_regions), Is.EqualTo(0));
        }

        [Test()]
        public void When_Row1_Has_State_1_P1_Won()
        {
            _regions[0].State = 1;
            _regions[1].State = 1;
            _regions[2].State = 1;
            Assert.That(_winStateManager.WichPlayerWon(_regions), Is.EqualTo(1));
        }
        [Test()]
        public void When_Row_2_Has_State_Negative1_P2_Won()
        {
            _regions[3].State = -1;
            _regions[4].State = -1;
            _regions[5].State = -1;
            Assert.That(_winStateManager.WichPlayerWon(_regions), Is.EqualTo(-1));
        }
        [Test()]
        public void When_Col1_Has_State_NegativeOne_P2_Won()
        {
            _regions[1].State = -1;
            _regions[4].State = -1;
            _regions[7].State = -1;
            Assert.That(_winStateManager.WichPlayerWon(_regions), Is.EqualTo(-1));
        }
        [Test()]
        public void When_Col1_Doest_Have_All_Internal_State_NegativeOne_NoOneWinsYet()
        {
            _regions[1].State = -1;
            _regions[4].State = 1;
            _regions[7].State = -1;
            Assert.That(_winStateManager.WichPlayerWon(_regions), Is.EqualTo(0));
        }
        [Test()]
        public void When_Main_Diagonal_Has_State_1_P1_Won()
        {
            _regions[0].State = 1;
            _regions[4].State = 1;
            _regions[8].State = 1;
            Assert.That(_winStateManager.WichPlayerWon(_regions), Is.EqualTo(1));
        }
        [Test()]
        public void When_Main_OpositeDiagonal_Has_State_NegativeOne_P2_Won()
        {
            _regions[2].State = -1;
            _regions[4].State = -1;
            _regions[6].State = -1;
            Assert.That(_winStateManager.WichPlayerWon(_regions), Is.EqualTo(-1));
        }
        [Test()]
        public void When_No_Player_Has_Won()
        {
            SetUp();
            Assert.That(_winStateManager.PlayerWhoWon, Is.EqualTo(string.Empty));
        }
        [TestCase(1)]
        [TestCase(1)]
        public void When_SomeOne_Wins_Game_Stop(int x)
        {
            _regions[2].State = x;
            _regions[4].State = x;
            _regions[6].State = x;
            _winStateManager.Update(_regions);
            Assert.That(_winStateManager.CanKeepPlaying, Is.EqualTo(false));
        }
    }
}
