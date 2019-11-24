using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using ShopGameFinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Managers
{
    class PlayerManager : DrawableGameComponent
    {
        ShopKeeper player;
        float speed;
        SpriteBatch spriteBatch;
        public PlayerManager(Game game) : base(game)
        {

        }
        public override void Update(GameTime gameTime)
        {

            player.Update(gameTime);

            base.Update(gameTime);
        }
        protected override void LoadContent()
        {
            speed = 500;       
            player = new ShopKeeper(Game);
            player.Initialize();
            spriteBatch = new SpriteBatch(this.GraphicsDevice);

            base.LoadContent();
        }
        public void MovePlayer(GameTime gameTime,ShopKeeper player)
        {
                player.Move(speed,gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            MovePlayer(gameTime, player);
            player.Draw(spriteBatch,gameTime);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
