using Crafting;
using Crafting.Items;
using CraftingLibrary.Final_Items.Items;
using CraftingLibrary.Items.CraftingMaterials;
using CraftingLibrary.Items.Final_Items;
using EconomyLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.Managers;
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

        public string Hint { get; internal set; }
        public Inventory PurchaseableItems { get; internal set; }

        public Vector2 CursorPosition;
        public bool CursorDown;
        public Wallet wallet;
        int timer;
        int NewItemTimer;
        public ShopKeeper(Game game, WorldManager world) : base(game, world)
        {
            timer = 0;
            NewItemTimer = 10000;// 10 seconds
            inventory = new Inventory(300);
            input = new InputHandler(game,this);
            this.screen = new ScreenManager(game, this);
            this.screen.Initialize();
            PurchaseableItems = new Inventory(0);
            //game.Components.Add(screen);
            CursorPosition = new Vector2(0, 0);
            CursorDown = false;
            game.Components.Add(input);
            wallet = new Wallet(300);
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
            CollidableGameObject collider = world.ColliderCheck(this);
            if (collider != null && collider.GetType().BaseType == typeof(CraftingObjects))
            {
                screen.ScreenState = ((CraftingObjects)collider).Page;
            }
        }

        internal void CloseScene()
        {
            screen.ScreenState = ScreenStateEnum.Game;
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
            timer += gameTime.ElapsedGameTime.Milliseconds;
            if(timer >= NewItemTimer)
            {
                timer = 0;
                Random ran = new Random();
                int num = ran.Next(1,3);
                switch(num)
                {
                    case 1:
                        PurchaseableItems.Add(new Sword());
                        break;
                    case 2:
                        PurchaseableItems.Add(new Bow());
                        break;
                }
                
            }
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
                if(world.ColliderCheck(this) is CraftingObjects)
                {
                    Hint = "Press F to open crafting object";
                } else
                {
                    Hint = "";
                }
            }
        }
    }
}
