using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame
{
    class CollidableGameObject : DrawableGameComponent
    {
        public Texture2D Texture { get; protected set; }
        protected string TextureName;
        protected Rectangle boundaries;
        protected SpriteBatch spriteBatch;
        protected float Rotation;
        public Vector2 Position { get; protected set; }
        public Vector2 Direction;
        protected bool canDraw;
        protected static List<CollidableGameObject> CollidableObjects;
        public static ShopKeeper shopkeeper;//NOTE Not the way to do this but I ran out of time
        public CollidableGameObject(Game game) : base(game)
        {
            Rotation = 0;
            if(shopkeeper == null)
            {
                if(this.GetType() == typeof(ShopKeeper))
                {
                    shopkeeper = (ShopKeeper)this;
                }
            }
            if(CollidableGameObject.CollidableObjects == null)
            {
                CollidableObjects = new List<CollidableGameObject>();
            }
            Position = new Vector2(0, 0);
            Direction = new Vector2(0, 0);
            CollidableObjects.Add(this);
        }
        public override void Draw(GameTime gameTime)
        {
            if (shopkeeper != null)
            {
                if (shopkeeper.canDraw)
                {
                    canDraw = true;
                } else
                {
                    canDraw = false;
                }
            }
            spriteBatch.Begin();
            this.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (canDraw)
            {
                spriteBatch.Draw(this.Texture, new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)this.Texture.Width, (int)this.Texture.Height), null, Color.White, MathHelper.ToRadians(Rotation), new Vector2(Texture.Width / 2, Texture.Height / 2), SpriteEffects.None, 0);
            }
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(this.GraphicsDevice);
            if (string.IsNullOrEmpty(TextureName))
                TextureName = "ShopKeeper";
            Texture = Game.Content.Load<Texture2D>(TextureName);
            boundaries.Width = Texture.Width;
            boundaries.Height = Texture.Height;
            Position = new Vector2(this.GraphicsDevice.Viewport.Width / 2, this.GraphicsDevice.Viewport.Height - this.Texture.Height/2);
            base.LoadContent();
        }

        public bool CheckBoundaryCollision(CollidableGameObject CollidingWith)
        {
            //Looking for a better way to do this, however, for a temporary solution
            bool returnValue = ((CollidingWith.Position.X <= this.Position.X + this.Texture.Width 
                && CollidingWith.Position.X >= this.Position.X) 
                || (CollidingWith.Position.X >= this.Position.X
                && CollidingWith.Texture.Width + CollidingWith.Position.X <= CollidingWith.Position.X)//If the collider is within a collidableObject
                );
            return returnValue;
        }
    }
}
