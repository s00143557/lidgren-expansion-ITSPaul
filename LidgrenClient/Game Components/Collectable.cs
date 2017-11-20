using CameraNS;
using GameData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LidgrenClient.Game_Components
{
    class Collectable : SimpleSprite
    {
        CollectableData collectableData;

        public Collectable(Game game, CollectableData cData, Texture2D spriteImage, Vector2 startPosition) : base (game, spriteImage, startPosition)
        {
            collectableData = cData;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sp = Game.Services.GetService<SpriteBatch>();
            SpriteFont font = Game.Services.GetService<SpriteFont>();
            // Draw the Image First
            base.Draw(gameTime);
            // Now draw the player id using the camera
            sp.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Camera.CurrentCameraTranslation);
            sp.DrawString(font, collectableData.value.ToString(),
                BoundingRect.Center.ToVector2() - font.MeasureString(collectableData.value.ToString()) / 2,
                Color.White);
            sp.End();
            //base.Draw(gameTime);
        }
    }
}
