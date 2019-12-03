using Crafting.CraftingSystem;
using CraftingLibrary.Recipes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame;
using ShopGame.Pages;
using ShopGame.GameSceneObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopGame.GameUI;
using ShopGame.Pages.Crafting_Pages;

namespace ShopGameFinalProject.Managers
{
    public enum ScreenStateEnum { Smelting, Woodcutting, Crafting, Game, Inventory,
        Shop
    }
    
    class ScreenManager : DrawableGameComponent
    {
        ScreenStateEnum screenState;
        ScreenStateEnum prevScreenState;
        public GameScreen screen;
        

        SpriteBatch spriteBatch;
        public ScreenStateEnum ScreenState { get { return screenState; } set { screenState = value; } }
        ShopKeeper player;
        Button exitButton;
        Button.Action exit;
        SpriteFont font;
        public ScreenManager(Game game, ShopKeeper player) : base(game)
        {
            screenState = ScreenStateEnum.Game;
            this.player = player;
            exitButton = new Button(Game,"exit");
            exit = ExitScreen;
        }
        bool ShowExit;//These should be unique to Draw
        /// <summary>
        /// Draws the menu
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (prevScreenState != screenState)
            {
                screen = new GameScreen(Game, player);

                if (screenState == ScreenStateEnum.Game)
                {
                    screen = new GameScreen(Game, player);
                    ShowExit = false;
                }
                else
                {
                    ShowExit = true;
                    if(screenState == ScreenStateEnum.Inventory)
                    {
                        screen = new MonoGameInventory(Game, player, this);
                    }
                    if (screenState == ScreenStateEnum.Crafting)
                    {
                        screen = new MonogameCraftingTable(Game, player, spriteBatch);
                    }
                    else if (screenState == ScreenStateEnum.Woodcutting)
                    {
                        screen = new MonoGameCarpentryStation(Game, player, spriteBatch);
                    }
                    else if (screenState == ScreenStateEnum.Smelting)
                    {
                        screen = new MonoGameFurnace(Game, player, spriteBatch);
                    } else if(screenState == ScreenStateEnum.Shop)
                    {
                        screen = new StorePage(Game,player);
                    }
                    screen.ChangeTexture("CraftingPage");
                }
                prevScreenState = screenState;
            }
            screen.Initialize();
            screen.Draw(gameTime);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        internal void ChangeScene(ScreenStateEnum screen)
        {
            this.screenState = screen;
        }

        void ExitScreen() 
        {
            screenState = ScreenStateEnum.Game;
        }
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if(player.CursorDown && exitButton.Contains(player.CursorPosition.ToPoint()))
            {
                screenState = ScreenStateEnum.Game;
            }
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(this.GraphicsDevice);
            font = this.Game.Content.Load<SpriteFont>("Recipes");
            base.LoadContent();
        }
    }
}
