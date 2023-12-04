﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using GameHandlers.Table;
namespace monogame.testes.Handlers.GeometryTests
{
    [TestFixture()]
    public class RegionTest
    {
        private MouseState correctMouseStateRegion;
        private MouseState unclickedMouseStateRegion;
        private MouseState smallerThanRegion;
        private MouseState greaterThanRegion;
        private MouseState currentMouseState;
        private MouseState previousMouseState;

        private Rectangle rect;

        private Region fieldRegion;
        private Region fieldRegionForClick;
        [SetUp]
        public void SetUp()
        {
            correctMouseStateRegion = new MouseState(50, 80, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released); //Inside and click
            unclickedMouseStateRegion = new MouseState(50, 80, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released); //INsinde and dont click
            smallerThanRegion = new MouseState(10, 10, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released); //Smaller and dont click
            greaterThanRegion = new MouseState(1000, 1000, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released); //Greater and click
            rect = new Rectangle(30, 60, 40, 40);

            //SetUp to testing field that has Rectangle denomination inside Region.
            fieldRegion = new Region(10, 15, 20, 35);

            fieldRegionForClick = new Region(10, 15, 20, 35);
            currentMouseState = new MouseState(20, 40, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released); //Inside and click
            previousMouseState = new MouseState(20, 40, 0, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released); //Inside and click
        }
        /// <summary>
        /// Caso de teste: Testar se mouse está em uma região do retângulo onde se posicionaria X e O.
        //InputsTests: Mouse
        //OutputsTests: True se estiver na região, false se não estiver.
        /// </summary>
        [TestCase()]
        public void Is_Mouse_Position_Inside_Region()
        {
            Assert.That(GameHandlers.Table.Region.IsInRegion(correctMouseStateRegion, rect), Is.True);
        }
        [TestCase()]
        public void State_Position_Is_Out_Of_Region()
        {
            MouseState outOfRegionState = new MouseState(10, 10, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(GameHandlers.Table.Region.IsInRegion(outOfRegionState, rect), Is.False);
        }
        [TestCase()]
        public void State_Position_Greater_Than_Region()
        {
            MouseState outOfRegionState = new MouseState(1000, 1000, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(GameHandlers.Table.Region.IsInRegion(outOfRegionState, rect), Is.False);
        }
        /// <summary>
        /// Espera-se que quando o mouse clique na região, o retorno seja verdadeiro.
        /// </summary>
        [TestCase()]
        public void Mouse_Has_CLicked_Region()
        {
            Assert.That(GameHandlers.Table.Region.MouseHasClickedRegion(correctMouseStateRegion, unclickedMouseStateRegion, rect), Is.True);
        }
        /// <summary>
        /// Espera-se que quando o mouse não clicou na região, o retorno seja falso.
        /// </summary>
        [TestCase()]
        public void Mouse_Hasnt_Clicked_Region()
        {
            Assert.That(GameHandlers.Table.Region.MouseHasClickedRegion(unclickedMouseStateRegion, unclickedMouseStateRegion, rect), Is.False);
        }
        /// <summary>
        /// Testa a região do tabuleiro, que pode assumir -1, 0 e 1, onde -1 : 'X'; 0 = vazio; 1 = 'O'; na criação inicial, o estado deve ser 0 (vazio).
        /// </summary>
        [TestCase()]
        public void Region_Creation_State_Has_No_X_or_O()
        {
            Assert.That(fieldRegion.State, Is.EqualTo(0));
        }
        /// <summary>
        /// Testa se o campo do tabuleiro é igual a um Retângulo definido, onde a propriedade Area encapsula o retangulo que receberá (X, O)
        /// </summary>
        [TestCase()]
        public void Initial_Area_Should_Be_Equal_Rectangle()
        {
            Assert.That(fieldRegion.Area, Is.EqualTo(new Rectangle(10, 15, 20, 35)));
        }

        /// <summary>
        /// Testcase: "Testar se o estado da região mudou"
        /// Verificar se ao clicar, o estado da região muda para 1.
        /// </summary>
        [TestCase()]
        public void Region_State_Changes_To_1_When_click()
        {
            fieldRegionForClick.InteractWithRegionByClick(currentMouseState, previousMouseState);
            Assert.That(fieldRegionForClick.State, Is.EqualTo(1));
        }
        /// <summary>
        /// Testcase: "Testar se o estado da região NÃO mudou para clickes fora da área"
        /// </summary>
        [TestCase()]
        public void Region_State_Does_Not_Change_After_Click()
        {
            fieldRegionForClick.State = 0;
            MouseState auxMouseStateOutOfField = new(1000, 40, 0, ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            fieldRegionForClick.InteractWithRegionByClick(auxMouseStateOutOfField, previousMouseState);
            Assert.That(fieldRegionForClick.State, Is.EqualTo(0));
        }
        /// <summary>
        /// Testcase ""Testar se o estado da região NÃO muda caso já tenha sofrido mudança para -1 ou 1;
        /// </summary>
        [TestCase()]
        public void Region_State_Does_Not_Change_If_Already_changed()
        {
            fieldRegionForClick.State = -1;
            fieldRegionForClick.InteractWithRegionByClick(currentMouseState, previousMouseState);
            Assert.That(fieldRegionForClick.State, Is.EqualTo(-1));
        }

    }
}