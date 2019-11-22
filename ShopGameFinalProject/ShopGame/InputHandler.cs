using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ShopGameFinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame
{
    class InputHandler : GameComponent
    {
        MouseHandler mouse;
        KeyboardHandler keyboard;
        ScreenManager screen;
        public InputHandler(Game game, ScreenManager screen) : base(game)
        {
            this.keyboard = new KeyboardHandler();
            this.mouse = new MouseHandler();
            this.screen = screen;
        }
        public override void Update(GameTime gameTime)
        {
            mouse.Update();
            keyboard.Update();
            MouseDown();
            base.Update(gameTime);
        }
        public void SwitchScenes()
        {
            if (keyboard.KeyPressed(Keys.Space))
            {
                screen.SetDisplay = false;
                if (screen.GameState != ScreenState.Game)
                {
                    screen.GameState = screen.GameState + 1;
                }
                else
                {
                    screen.GameState = 0;
                }
            }
        }
        public void MouseDown()
        {
            if(mouse.MouseDown())
            {
                screen.CursorPosition = mouse.GetMousePosition();
                screen.CursorDown = true;
            } else
            {
                if(screen.CursorDown)
                {
                    screen.CursorDown = false;
                }
            }
        }
    }
    public class MouseHandler
    {
        private MouseState prevMouseState;
        private MouseState mouseState;
        public MouseHandler()
        {
            prevMouseState = Mouse.GetState();
        }
        public bool MouseDown()
        {
            if (mouseState.LeftButton != prevMouseState.LeftButton)
            {
                return true;
            }
            return false;
        }
        public Vector2 GetMousePosition()
        {
            if(MouseDown())
            {
                return mouseState.Position.ToVector2();
            }
            return new Vector2(-2000,-2000);//Out of screen in theory
        }
        public void Update()
        {
            //set our previous state to our new state
            prevMouseState = mouseState;

            //get our new state
            mouseState = Mouse.GetState();
        }
    }
    public class KeyboardHandler
    {
        private KeyboardState prevKeyboardState;
        private KeyboardState keyboardState;
        public KeyboardHandler()
        {
            prevKeyboardState = Keyboard.GetState();
        }
        public bool KeyPressed(Keys key)
        {
            if (keyboardState.GetPressedKeys().Count() > 0)
            {
                if ((keyboardState.IsKeyDown(key)) != prevKeyboardState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public void Update()
        {
            //set our previous state to our new state
            prevKeyboardState = keyboardState;

            //get our new state
            keyboardState = Keyboard.GetState();
        }
    }
}
