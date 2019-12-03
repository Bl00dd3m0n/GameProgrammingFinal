using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ShopGame.GameSceneObjects;
using ShopGame.Managers;
using ShopGameFinalProject.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGame
{
    interface IInputHandler
    {
        void ChangeScreenScene();
        void GetPlayerMovement();
    }
    class InputHandler : GameComponent, IInputHandler
    {
        MouseHandler mouse;
        KeyboardHandler keyboard;
        ShopKeeper player;
        internal bool SwitchScenes;
        internal Vector2 Direction;
        internal bool CloseScene;
        internal bool OpenInventory { get;  set; }

        public InputHandler(Game game, ShopKeeper player) : base(game)
        {
            this.keyboard = new KeyboardHandler(this);
            this.mouse = new MouseHandler();
            this.player = player;
            this.Direction = new Vector2(0, 0);
        }
        public override void Update(GameTime gameTime)
        {
            mouse.Update();
            keyboard.Update();
            MouseDown();
            GetPlayerMovement();
            ChangeScreenScene();
            base.Update(gameTime);
        }
        public void GetPlayerMovement()
        {
            player.Direction = Direction;
        }

        public void MouseDown()
        {
            if(mouse.MouseDown())
            {
                player.CursorPosition = mouse.GetMousePosition();
                player.CursorDown = true;
            } else
            {
                if(player.CursorDown)
                {
                    player.CursorDown = false;
                }
            }
        }

        public void ChangeScreenScene()
        {
            if (SwitchScenes) player.OpenScene();
            if(OpenInventory) player.OpenInventory();
            if (CloseScene) player.CloseScene();
        }
    }
    class MouseHandler
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
    class KeyboardHandler : IInputHandler
    {
        private KeyboardState prevKeyboardState;
        private KeyboardState keyboardState;
        InputHandler handler;
        List<Keys> Up;
        List<Keys> Down;
        List<Keys> Left;
        List<Keys> Right;
        List<Keys> OpenScreen;
        List<Keys> OpenInventory;
        List<Keys> CloseScreen;
        public KeyboardHandler(InputHandler handler)
        {
            Up = new List<Keys>();
            Down = new List<Keys>();
            Left = new List<Keys>();
            Right = new List<Keys>();
            OpenScreen = new List<Keys>();
            OpenInventory = new List<Keys>();
            CloseScreen = new List<Keys>();
            this.handler = handler;
            prevKeyboardState = Keyboard.GetState();
            SetKeys();
        }
        public void SetKeys()
        {
            Up.Add(Keys.Up);
            Down.Add(Keys.Down);
            Left.Add(Keys.Left);
            Right.Add(Keys.Right);
            OpenScreen.Add(Keys.F);
            OpenInventory.Add(Keys.B);
            CloseScreen.Add(Keys.Escape);
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
        public bool KeyDown(Keys key)
        {
            if (keyboardState.GetPressedKeys().Count() > 0)
            {
                if (keyboardState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool KeyDown(List<Keys> keys)
        {
            foreach (Keys key in keys)
            {
                if (KeyDown(key)) return true;
            }
            return false;
        }

        public bool KeyPressed(List<Keys> keys)
        {
            foreach(Keys key in keys)
            {
                if (KeyPressed(key)) return true;
            }
            return false;
        }
        public void ChangeScreenScene()
        {
            handler.OpenInventory = KeyPressed(OpenInventory);
            handler.SwitchScenes = KeyPressed(OpenScreen);
            handler.CloseScene = KeyPressed(CloseScreen);
        }
        public void Update()
        {
            //set our previous state to our new state
            prevKeyboardState = keyboardState;

            //get our new state
            keyboardState = Keyboard.GetState();
            ChangeScreenScene();
            GetPlayerMovement();
        }

        public void GetPlayerMovement()
        {
            handler.Direction = new Vector2(0, 0);
            if (KeyDown(Left))
            {
                handler.Direction.X -= 1;
            }
            if (KeyDown(Right))
            {
                handler.Direction.X += 1;
            }
            if(handler.Direction.X == 1 && handler.Direction.Y == 1)
            {
                handler.Direction.Normalize();
            }
        }
    }
}
