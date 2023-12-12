using GameHandlers.Table;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogame.testes.Handlers.Table
{
    public class StateManagerTests
    {
        Board _boardGame;
        StateManager _stateManager;
        MouseState _currentMouseState, _previousMouseState;

        [SetUp]
        public void Setup()
        {
            _boardGame = new Board();
            _stateManager = new StateManager();

            _previousMouseState = new MouseState(250, 250, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);



        }
        [Test()]
        public void Has_Mouse_Clicked_Region4()
        {
            _currentMouseState = new MouseState(250, 250, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(_stateManager.ClickedRegion(_boardGame.Regions, _currentMouseState, _previousMouseState), Is.EqualTo(4));
        }
        [Test()]
        public void Has_Mouse_Clicked_SeparatorLine()
        {
            _currentMouseState = new MouseState(196, 101, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(_stateManager.ClickedRegion(_boardGame.Regions, _currentMouseState, _previousMouseState), Is.EqualTo(-1));
        }
        [Test()]
        public void Has_Region_State_Changed_After_Click()
        {
            _currentMouseState = new MouseState(250, 250, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            _stateManager.UpdateClickedRegion(_boardGame.Regions, _currentMouseState, _previousMouseState);
            Assert.That(_boardGame.Regions[4].State, Is.EqualTo(1));
        }
        /// <summary>
        /// Testa se o click vai alternar entre dois estados (-1 e 1) para diferenciar jogadores.
        /// </summary>
        [Test()]
        public void Different_Clicked_Region_Have_Diff_States()
        {
            StateManager.currentPlayer = -1;
            TestContext.Out.WriteLine("Current player from StateManager: " + StateManager.currentPlayer);
            _boardGame.Regions[3].InteractWithRegionByClick();
            Assert.That(_boardGame.Regions[3].State, Is.EqualTo(-1));
            _boardGame.Regions[4].InteractWithRegionByClick();
            Assert.That(_boardGame.Regions[4].State, Is.EqualTo(1));
        }
        [Test()]
        public void Player_State_Has_Updated()
        {
            StateManager.currentPlayer = 1;
            StateManager.UpdatePlayerState();
            Assert.That(StateManager.currentPlayer, Is.EqualTo(-1));
            StateManager.UpdatePlayerState();
            Assert.That(StateManager.currentPlayer, Is.EqualTo(1));
            
        }


    }
}
