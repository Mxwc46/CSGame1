using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended;
using MonoGame.Extended.Particles;
using MonoGame.Extended.Particles.Modifiers;
using MonoGame.Extended.Particles.Modifiers.Containers;
using MonoGame.Extended.Particles.Modifiers.Interpolators;
using MonoGame.Extended.Particles.Profiles;
using MonoGame.Extended.TextureAtlases;

namespace CSGame1

{


    public class GameplayScreen : GameScreen
    {
        private ParticleEffect _particleEffect;
        private Texture2D _particleTexture;
        //cringe
        Player player;
        public override void LoadContent()
        {
            base.LoadContent();

            XmlManager<Player> playerLoader = new XmlManager<Player>();
            player = playerLoader.Load("Content/Load/Player.xml");
            player.LoadContent();

            _particleTexture = new Texture2D(GraphicsDevice, 1, 1);
            _particleTexture.SetData(new[] { Color.White });

            TextureRegion2D textureRegion = new TextureRegion2D(_particleTexture);
            _particleEffect = new ParticleEffect(autoTrigger: false)
            {
                Position = new Vector2(400, 240),
                Emitters = new List<ParticleEmitter>
    {
        new ParticleEmitter(textureRegion, 500, TimeSpan.FromSeconds(2.5),
            Profile.BoxUniform(100,250))
        {
            Parameters = new ParticleReleaseParameters
            {
                Speed = new Range<float>(0f, 50f),
                Quantity = 3,
                Rotation = new Range<float>(-1f, 1f),
                Scale = new Range<float>(3.0f, 4.0f)
            },
            Modifiers =
            {
                new AgeModifier
                {
                    Interpolators =
                    {
                        new ColorInterpolator
                        {
                            StartValue = new HslColor(0.33f, 0.5f, 0.5f),
                            EndValue = new HslColor(0.5f, 0.9f, 1.0f)
                        }
                    }
                },
                new RotationModifier {RotationRate = -2.1f},
                new RectangleContainerModifier {Width = 800, Height = 480},
                new LinearGravityModifier {Direction = -Vector2.UnitY, Strength = 30f},
            }
        }
    }
            };
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            player.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
