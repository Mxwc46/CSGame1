using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace CSGame1
{
    public class ImageEffect
    {
        protected Image image;
        public bool IsActive;
        public ImageEffect()
        {
            IsActive = false;
        }

        public virtual void LoadContent(ref Image image)
        {
            this.image = image;
        }

        public virtual void UnloadContent()
        { 
        }

        public virtual void Update(GameTime gameTime)
        { 
        }

    }
}
