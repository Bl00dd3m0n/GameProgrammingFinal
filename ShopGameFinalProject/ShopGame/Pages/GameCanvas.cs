using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using ShopGame.GameUI;
using ShopGameFinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Pages
{
    class GameCanvas : Canvas
    {
        Text timer;
        List<Text> ScreenText;
        List<Button> buttons;
        Button.Action ShopButton;
        ShopKeeper player;
        public GameCanvas(Game game, ShopKeeper player) : base(game)
        {
            this.player = player;
            ScreenText = new List<Text>();
            buttons = new List<Button>();
            ShopButton = OpenShop;
        }

        private void OpenShop()
        {
            player.Screen.ScreenState = ScreenStateEnum.Shop;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Text text in ScreenText)
            {
                if (text.text == "Money:") text.SetTextValues(text.text, new Vector2(this.GraphicsDevice.Viewport.Width - text.TextPositions($"{text.text}:${player.wallet.Balance}").X,0),Color.LightGreen);
                if(text.text[0] == '$') text.SetTextValues($"${player.wallet.Balance}", new Vector2(this.GraphicsDevice.Viewport.Width - text.TextPositions($"${player.wallet.Balance}").X, 0), Color.Yellow);
                if(text.text.Substring(0,4) == "Tool") text.SetTextValues($"Tool Tip:{player.Hint} ", new Vector2(this.GraphicsDevice.Viewport.Width - text.TextPositions($"Tool Tip: {player.Hint}").X, 0 + text.TextPositions($"1").Y), Color.LightGreen);
                text.Draw(spriteBatch);
            }
            foreach(Button button in buttons)
            {
                if(player.CursorDown)
                {
                    if (button.Contains(player.CursorPosition.ToPoint()))
                    {
                        ShopButton();
                    }
                }
                button.Draw(spriteBatch);
            }
        }
        public void CreateScreenOverlay()
        {
            Text text = new Text(Game);
            text.SetTextValues("Money:", new Vector2(this.GraphicsDevice.Viewport.Width - text.TextPositions($"Money:${player.wallet.Balance}").X, 0), Color.LightGreen);
            ScreenText.Add(text);

            text = new Text(Game);
            text.SetTextValues($"${player.wallet.Balance}", new Vector2(this.GraphicsDevice.Viewport.Width - text.TextPositions($"${player.wallet.Balance}").X, 0), Color.Yellow);
            ScreenText.Add(text);

            text = new Text(Game);
            text.SetTextValues("Tool Tip: ", new Vector2(this.GraphicsDevice.Viewport.Width - text.TextPositions($"ToolTip: ").X, 0 + text.TextPositions($"1").Y), Color.LightGreen);
            ScreenText.Add(text);

            Button shop = new Button(Game,"Shop");
            shop.CreateButton("Shop", new Vector2(this.GraphicsDevice.Viewport.Width - text.TextPositions($"Shop").X, 0 + text.TextPositions($"1").Y * 2), Color.White, Color.Black);
            buttons.Add(shop);
        }
        protected override void LoadContent()
        {
            CreateScreenOverlay();
            base.LoadContent();
        }
    }
}
