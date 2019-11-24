﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crafting;
using CraftingLibrary.Items.Interfaces.Final_Items;
using CraftingLibrary.Recipes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShopGame.GameSceneObjects;
using ShopGameFinalProject.Managers;

namespace ShopGame.Pages
{
    class MonoGamePage : GameScreen
    {
        protected SpriteFont font;
        protected float wordspacing;
        protected float marginx;
        protected float marginy;
        protected bool RenderRecipe;
        protected ScreenManager screen;
        protected ItemsButtons[] items;
        protected Inventory someInventory;
        protected bool CraftablePage;
        protected Button pressedButton;
        protected Recipe recipe;
        public MonoGamePage(Game game, ShopKeeper player) : base(game, player)
        {
            this.CraftablePage = false;
            this.Rotate = 0;
            this.game = game;
            this.Direction = new Vector2(0, 0);
            this.player = player;
            someInventory = player.inventory;

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, new Rectangle((int)this.Location.X, (int)this.Location.Y, (int)this.Texture.Width, (int)this.Texture.Height), null, Color.White, MathHelper.ToRadians(Rotate), new Vector2(0, 0), SpriteEffects.None, 0);
        }

        protected virtual void SetButtons()
        {
            items = new ItemsButtons[someInventory.GetInventory().Count];
        }

        protected virtual void CreateButtons()
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new ItemsButtons(Game, someInventory.GetInventory()[i]);
                items[i].Initialize();
            }
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            this.Draw(sb);
            for (int i = 0; i < items.Length; i++)
            {

                //TODO add recipe for inventory items
                //if (items[i].item.GetType().GetInterface("ICraftable") != null)
                //{
                //    recipe = ((ICraftable)items[i].item).itemRecipe;
                //}//This resets recipe for the crafting menus don't do this.
                items[i].Draw(gameTime, sb, font, items[i].item.Name, new Vector2(marginx, i * items[i].bounds.Height + marginy));//NOTE Since crafted items at the moment are only one object type using [0] should be fine, however, if you can craft multiple things possibly change this
            }
            if (recipe != null)
            {
                DrawRecipe(gameTime, recipe);
            }
            sb.End();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            if (string.IsNullOrEmpty(TextureName))
                TextureName = "CraftingPage";
            Texture = game.Content.Load<Texture2D>(TextureName);
            font = this.Game.Content.Load<SpriteFont>("Recipes");
            wordspacing = 20;
            marginx = Texture.Width / 90;
            marginy = 20;
            CreateButtons();

        }
        protected virtual void NewButton(GameTime gameTime)
        {
        
        }
        protected virtual void DrawRecipe(GameTime gameTime, Recipe recipe)
        {
            if (RenderRecipe)
            {
                foreach (var text in recipe.RecipeItems)
                {
                    int wordCount = 0;

                    string[] words = new string[4];//RGB values + text
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] != ',')
                        {
                            words[wordCount] += text[i];
                        }
                        else
                        {
                            wordCount++;
                        }
                    }

                    Color color = new Color(Convert.ToUInt32(words[0]), Convert.ToUInt32(words[1]), Convert.ToUInt32(words[2]));
                    string ActualText = words[3];
                    sb.DrawString(font, ActualText, new Vector2(500, 100 + recipe.RecipeItems.IndexOf(text) * 15), color);
                }
            }
        }
    }
}

