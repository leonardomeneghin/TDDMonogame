using GameHandlers.Table;
using Microsoft.Xna.Framework.Graphics;
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
        MouseState _currentMouseState, _previousMouseState, _newMouseState;
        SpriteFont _font;
        [SetUp]
        public void Setup()
        {

            _stateManager = new StateManager();
            _boardGame = new Board(_font, _stateManager, null);
            _previousMouseState = new MouseState(250, 250, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);



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


        [Test()]
        public void Update_Board_When_Mouse_State()
        {
            _currentMouseState = new MouseState(250, 250, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            _newMouseState = new MouseState(666, 666, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            _boardGame.Previous = _previousMouseState;
            _boardGame.Current = _currentMouseState;

            _boardGame.UpdateMouse(_newMouseState);
            Assert.That(_boardGame.Previous, Is.EqualTo(_currentMouseState));
            Assert.That(_boardGame.Current, Is.EqualTo(_newMouseState));

        }
        [Test()]
        public void Has_Mouse_Clicked_Region4()
        {
            _currentMouseState = new MouseState(250, 250, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(_stateManager.ClickedRegion(_boardGame.Regions, _currentMouseState, _previousMouseState), Is.EqualTo(4));
        }
        [Test()]
        public void Has_Mouse_Clicked_Region0()
        {
            _currentMouseState = new MouseState(105, 105, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(_stateManager.ClickedRegion(_boardGame.Regions, _currentMouseState, _previousMouseState), Is.EqualTo(0));
        }
        [Test()]
        public void When_Click_OutsideRegion_Retuns_negativeOne()
        {
            _currentMouseState = new MouseState(50, 50, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(_stateManager.ClickedRegion(_boardGame.Regions, _currentMouseState, _previousMouseState), Is.EqualTo(-1));
        }
        [Test()]
        public void When_Click_In_SeparatorLine_Returns_NegativeOne()
        {
            _currentMouseState = new MouseState(196, 101, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(_stateManager.ClickedRegion(_boardGame.Regions, _currentMouseState, _previousMouseState), Is.EqualTo(-1));
        }
        [Test()]
        public void When_Click_Region_Returns_RegionInternalState_Changed_To_Player_Identificator()
        {
            _currentMouseState = new MouseState(260, 260, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);

            var num = _stateManager.ClickedRegion(_boardGame.Regions, _currentMouseState, _previousMouseState);
            _stateManager.UpdateClickedRegion(_boardGame.Regions, num);
            Assert.That(_boardGame.Regions[num].State, Is.EqualTo(1));
        }
        /// <summary>
        /// Testa se a região está com o estado correto do player que interagiu.
        /// </summary>
        [Test()]
        public void When_Region_Clicked_By_Correct_Player_Returns_Player()
        {
            Assert.That(_boardGame.Regions[0].State, Is.EqualTo(0));
            Assert.That(_boardGame.Regions[1].State, Is.EqualTo(0));

            _boardGame.UpdateClicks(0);
            _boardGame.UpdateClicks(1);

            Assert.That(_boardGame.Regions[0].State, Is.EqualTo(1));
            Assert.That(_boardGame.Regions[1].State, Is.EqualTo(-1));

        }

    }
}
