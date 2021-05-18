using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace CSGame1
{
    public class InputManager
    {
        KeyboardState currentkeyState, prevkeyState;

        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputManager();
                return instance;
            }
        }

        public void Update()
        {
            prevkeyState = currentkeyState;
            if (!ScreenManager.Instance.IsTransitioning)
                currentkeyState = Keyboard.GetState();
        }

        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentkeyState.IsKeyDown(key) && prevkeyState.IsKeyUp(key))
                    return true;
            }
            return false;
        }
            public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentkeyState.IsKeyUp(key) && prevkeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentkeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }
    }
}
