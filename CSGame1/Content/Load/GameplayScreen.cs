using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace CSGame1

{
    public class GameplayScreen : GameScreen
    {
        Player player;
        Map map;
        public override void LoadContent()
        {
            base.LoadContent();

            XmlManager<Player> playerLoader = new XmlManager<Player>();
            XmlManager<Map> mapLoader = new XmlManager<Map>();
            player = playerLoader.Load("Content/Load/Player.xml");
            map = mapLoader.Load("Content/Load/Map1.xml");
            player.LoadContent();
            map.LoadContent();

        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
            map.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            player.Update(gameTime);
            map.Update(gameTime, ref player);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
