using Crafting.Recipes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Util;
using ShopGameFinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Crafting_Pages
{
    class MonoGameCrafting : Screen
    {

        protected SpriteFont font;
        protected float wordspacing;
        protected float marginx;
        protected float marginy;
        protected RecipeMenuButton[] Recipes;
        Recipe recipe;
        public MonoGameCrafting(Game game, ShopKeeper player, ScreenManager screen) : base(game,player)
        {
            Rotate = 0;
            this.game = game;
            Direction = new Vector2(0, 0);
            this.player = player;

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, new Rectangle((int)this.Location.X, (int)this.Location.Y, (int)this.Texture.Width, (int)this.Texture.Height), null, Color.White, MathHelper.ToRadians(Rotate), new Vector2(0, 0), SpriteEffects.None, 0);
        }

        protected void CreateButtons()
        {
            for (int i = 0; i < Recipes.Length; i++)
            {
                Recipes[i] = new RecipeMenuButton(Game,new Recipe());
                Recipes[i].Initialize();
            }
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
            base.LoadContent();
            if (string.IsNullOrEmpty(TextureName))
                TextureName = "CraftingPage";
            Texture = game.Content.Load<Texture2D>(TextureName);
            sb = new SpriteBatch(this.GraphicsDevice);
            font = this.Game.Content.Load<SpriteFont>("Recipes");
            wordspacing = 20;
            marginx = Texture.Width / 90;
            marginy = 20;
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            this.Draw(sb);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
