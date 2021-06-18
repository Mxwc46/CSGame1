using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CSGame1
{
    public class Player
    {
        public Image Image;
        public Vector2 Velocity;
        public float MoveSpeed;

        public Player()
        {
            Velocity = Vector2.Zero;
        }

        public void LoadContent()
        {
            Image.LoadContent();
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            Image.IsActive = true;
            //if (Velocity.X == 0)
            if (true)
            {
                if (InputManager.Instance.KeyDown(Keys.S))
                {
                    Velocity.Y = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 0;
                }
                else if (InputManager.Instance.KeyDown(Keys.W))
                {
                    Velocity.Y = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 3;
                }
                else
                    Velocity.Y = 0;
            }
            //if (Velocity.Y == 0)
            if (true)
            {
                if (InputManager.Instance.KeyDown(Keys.D))
                {
                    Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 2;
                }
                else if (InputManager.Instance.KeyDown(Keys.A))
                {
                    Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Image.SpriteSheetEffect.CurrentFrame.Y = 1;
                }
                else
                    Velocity.X = 0;
            }

            if (Velocity.X == 0 && Velocity.Y == 0)
                Image.IsActive = false;

            Image.Update(gameTime);
            Image.Position += Velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }

    }
}
