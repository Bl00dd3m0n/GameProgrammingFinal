using Crafting.CraftingSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using ShopGame;
using ShopGame.Crafting_Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGameFinalProject.Managers
{
    public enum ScreenState { Smelting, Woodcutting, Crafting, Game}
    
    class ScreenManager : DrawableGameComponent
    {
        ScreenState gameState;
        const int width = 1920;
        const int height = 1080;
        public Screen screen;
        public Vector2 CursorPosition;
        public bool CursorDown;
        SpriteBatch spriteBatch;
        public ScreenState GameState { get { return gameState; } set { gameState = value; } }
        GraphicsDeviceManager graphics;
        ShopKeeper player;
        public ScreenManager(Game game, GraphicsDeviceManager graphics, ShopKeeper player) : base(game)
        {
            this.graphics = graphics;
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            gameState = ScreenState.Crafting;
            this.player = player;
        }
        public bool SetDisplay;
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (!SetDisplay)
            {
                screen = new Screen(Game, player);

                if (gameState == ScreenState.Game)
                {
                    screen.ChangeTexture("Background");
                }
                else
                {
                    if (gameState == ScreenState.Crafting)
                    {
                        screen = new MonogameCraftingTable(Game, player, spriteBatch,this);
                    }
                    else if (gameState == ScreenState.Woodcutting)
                    {
                    }
                    else if (gameState == ScreenState.Woodcutting)
                    {

                    }
                    else if (gameState == ScreenState.Smelting)
                    {

                    }
                    screen.ChangeTexture("CraftingPage");
                }
                SetDisplay = true;
            }
            screen.Initialize();
            screen.Draw(gameTime);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(this.GraphicsDevice);
            screen = new MonoGameCrafting(this.Game,player,this);
            screen.Initialize();
            screen.Location = new Vector2(0, 0);

            base.LoadContent();
        }
    }
}
