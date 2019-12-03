using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Pages
{
    class GameScreen : DrawableGameComponent
    {
        public Texture2D Texture { get; protected set; }
        public Vector2 Location;
        protected SpriteBatch sb;
        public string TextureName { get; set; }
        public float Rotate;
        protected Game game;
        public Vector2 Direction;
        public Rectangle Boundaries;
        protected ShopKeeper player;
        GameCanvas canvas;
        public GameScreen(Game game, ShopKeeper player) : base(game)
        {
            Rotate = 0;
            this.game = game;
            Direction = new Vector2(0, 0);
            this.player = player;
            canvas = new GameCanvas(game, player);
            canvas.Initialize();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(this.Texture, new Rectangle((int)this.Location.X, (int)this.Location.Y, (int)this.Texture.Width, (int)this.Texture.Height), null, Color.White, MathHelper.ToRadians(Rotate), new Vector2(0, 0), SpriteEffects.None, 0);
            canvas.Draw(spriteBatch);
        }
        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            this.Draw(sb);
            sb.End();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            if (string.IsNullOrEmpty(TextureName))
                TextureName = "Background";
            Texture = game.Content.Load<Texture2D>(TextureName);
            sb = new SpriteBatch(this.GraphicsDevice);

        }

        public virtual void ChangeTexture(string texture)
        {
            TextureName = texture;
        }

        public void UpdateBoundaries()
        {
            Boundaries = new Rectangle(this.Location.ToPoint(), new Vector2(this.Texture.Width, this.Texture.Height).ToPoint());
        }
    }
}
