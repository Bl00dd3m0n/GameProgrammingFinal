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
        public ShopKeeper player { get; private set; }
        float speed;
        SpriteBatch spriteBatch;
        WorldManager world;
        public PlayerManager(Game game, WorldManager world) : base(game)
        {
            this.world = world;
            player = new ShopKeeper(Game, world);
        }
        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void LoadContent()
        {
            speed = 500;       
            spriteBatch = new SpriteBatch(this.GraphicsDevice);
            player.Initialize();
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
