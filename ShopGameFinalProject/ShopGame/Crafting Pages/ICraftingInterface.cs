using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame.Crafting_Pages
{
    interface ICraftingInterface
    {
        Texture2D Texture { get; }
        string TextureName { get; set; }
        void Draw();
    }
}
