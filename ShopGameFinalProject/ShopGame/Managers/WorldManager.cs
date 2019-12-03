using Microsoft.Xna.Framework;
using ShopGame.GameSceneObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Managers
{
    class WorldManager : DrawableGameComponent
    {
        List<CollidableGameObject> collidables;
        public WorldManager(Game game) : base(game)//Manages the world but not any graphics
        {
            collidables = new List<CollidableGameObject>();
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
            AddObjects();
        }
        public void AddObjects()
        {
            if (collidables.Count <= 0)
            {
                PlayerManager player = new PlayerManager(Game, this);
                Game.Components.Add(player);
                collidables = new List<CollidableGameObject>()
                {
                    new FurnaceObject(Game,this),
                    new CraftingTableObject(Game,this),
                    new WoodCuttingObject(Game,this),
                    player.player,
                 };
                foreach (var collidable in collidables)
                {
                    if(collidable != player.player)
                    Game.Components.Add(collidable);
                }
            }
        }
        public CollidableGameObject ColliderCheck(CollidableGameObject movingObject)
        {
            CollidableGameObject collider = null;
            bool canMove = false;
            foreach (var collidercheck in collidables)
            {
                collidercheck.UpdateBoundariesPos();
                movingObject.UpdateBoundariesPos();
                if (collidercheck != movingObject)
                {
                    canMove = movingObject.CheckBoundaryCollision(collidercheck);
                    if (canMove)//This should be true if it collides
                    {
                        collider = collidercheck;
                        break;
                    }
                }
            }
            return collider;
        }
    }
}
