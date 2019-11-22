using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Crafting_Pages
{
    class Screen : DrawableGameComponent
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

        public Screen(Game game, ShopKeeper player) : base(game)
        {
            Rotate = 0;
            this.game = game;
            Direction = new Vector2(0, 0);
            this.player = player;
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
