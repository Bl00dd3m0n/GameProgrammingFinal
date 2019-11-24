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
    static class Util
    {
        /// <summary>
        /// Flips the player on the x-axis
        /// Can't rotate because it would put it upside down
        /// </summary>
        /// <param name="textureToFlip"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        /// <seealso cref="http://www.riemers.net/eng/Tutorials/XNA/Csharp/Series2D/Texture_to_Colors.php"/>
        /// <seealso cref="https://gamedev.stackexchange.com/questions/89567/texture2d-setdata-method-overload"/>
        /// <seealso cref="https://www.khanacademy.org/math/linear-algebra/matrix-transformations/lin-trans-examples/v/linear-transformation-examples-scaling-and-reflections"/>
        public static Texture2D FlipTexture(Texture2D textureToFlip, ShopKeeper player)
        {
            int width = textureToFlip.Width;
            int height = textureToFlip.Height;
            Color[] colors1D = new Color[textureToFlip.Width * textureToFlip.Height];
            Color[] flipped = new Color[(textureToFlip.Width) * textureToFlip.Height];
            textureToFlip.GetData(colors1D);
            float[,] reflectionMatrix = GenerateReflectionMatrix(3);
            for(float y = 0; y < textureToFlip.Height; y++)
            {
                for(float x = 0; x < textureToFlip.Width;x++)
                {
                    float point = (x) + (textureToFlip.Width) * y;
                    Vector2 newPos = calculateNewPos(x,y,reflectionMatrix,textureToFlip.Width);
                    //flipped[Convert.ToInt32(point)] = colors1D[Convert.ToInt32(point)];
                    if ((int)newPos.Y != 0)
                    {
                        if ((int)newPos.X * (int)newPos.Y != 0)
                        {
                            float reflectedpoint = (newPos.X) + (textureToFlip.Width) * newPos.Y;
                            flipped[Convert.ToInt32(point)] = colors1D[Convert.ToInt32(reflectedpoint)-1];
                        }
                    }
                }
                }
            Texture2D newTexture = new Texture2D(textureToFlip.GraphicsDevice, textureToFlip.Width, textureToFlip.Height);
            newTexture.SetData(0, new Rectangle(0, 0, width, height), flipped, 0, textureToFlip.Width*textureToFlip.Height);
            return newTexture;
        }

        private static Vector2 calculateNewPos(float x, float y, float[,] reflectionMatrix, int length)
        {
            for(int matrixY = 0; matrixY < reflectionMatrix.Length/3; matrixY++)//Should always be 3
            {
                for (int matrixX = 0; matrixX < reflectionMatrix.Length / 3; matrixX++)//Should always be 3
                {
                    if (matrixY == 0 && reflectionMatrix[matrixX, matrixY] != 0)
                        x *= reflectionMatrix[matrixX, matrixY];
                    if (matrixY == 1 && reflectionMatrix[matrixX, matrixY] != 0)
                        y *= reflectionMatrix[matrixX, matrixY];
                }
            }
            return new Vector2(x + length, y);
        }
        private static float[,] GenerateReflectionMatrix(int size)
        {
            float[,] ReflectionMatrix = new float[size,size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        ReflectionMatrix[i, j] = -1;
                    }
                    else if (i == j)
                    {
                        ReflectionMatrix[i, j] = 1;
                    } else
                    {
                        ReflectionMatrix[i, j] = 0;
                    }
                }
            }
            return ReflectionMatrix;
        }
       
    }
}
