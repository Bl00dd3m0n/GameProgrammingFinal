using Crafting;
using Crafting.Items;
using CraftingLibrary.Items.CraftingMaterials;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.Pages;
using ShopGameFinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.GameSceneObjects
{
    class ShopKeeper : CollidableGameObject
    {
        Texture2D normalTexture;
        Texture2D flippedTexture;
        public Inventory inventory { get; set; }
        protected InputHandler input;
        ScreenManager screen;
        public ScreenManager Screen { get { return screen; } }
        public Vector2 CursorPosition;
        public bool CursorDown;
        public ShopKeeper(Game game) : base(game)
        {
            inventory = new Inventory(50);
            input = new InputHandler(game,this);
            this.screen = new ScreenManager(game, this);
            this.screen.Initialize();
            //game.Components.Add(screen);
            CursorPosition = new Vector2(0, 0);
            CursorDown = false;
            game.Components.Add(input);
            inventory.Add(new Iron_Ore(), 120);
            inventory.Add(new Logs(), 20);
            TextureName = "ShopKeeper";
        }

        public virtual void Draw(SpriteBatch spriteBatch,GameTime gameTime)
        {
            if(Direction.X == -1) Texture = flippedTexture;
            if(Texture == flippedTexture)
            {
                if(Direction.X == 1)
                {
                    Texture = normalTexture;
                }
            }
            screen.Draw(gameTime);
            this.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
        public void OpenScene()
        {
            foreach(var Objects in CollidableGameObject.CollidableObjects)
            {
                if(Objects.GetType().BaseType == typeof(CraftingObjects))//Posibly handle this better
                {
                    if (this.CheckBoundaryCollision(Objects))
                    {
                        screen.ChangeScene(((CraftingObjects)Objects).Page);
                    }
                }
            }
        }

        internal void OpenInventory()
        {
            screen.ScreenState = ScreenStateEnum.Inventory;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            normalTexture = Texture;
            flippedTexture = Util.FlipTexture(Texture,this);
        }
        public override void Update(GameTime gameTime)
        {
            screen.Update(gameTime);
            boundaries.X = (int)Position.X;
            boundaries.Y = (int)Position.Y;
            if(screen.ScreenState != ScreenStateEnum.Game)
            {
                canDraw = false;
            } else
            {
                canDraw = true;
            }
            base.Update(gameTime);
        }
        public virtual void Move(float speed,GameTime gameTime)
        {
            if(Direction != new Vector2(0, 0))
            {
                this.Position += Direction * speed * gameTime.ElapsedGameTime.Milliseconds / 1000;
            }
        }
    }
}
