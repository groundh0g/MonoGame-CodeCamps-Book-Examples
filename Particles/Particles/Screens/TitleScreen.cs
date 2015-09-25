using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using Codetopia.Xna.Framework.Input;
using Codetopia.Xna.Framework.Input.Touch;
using Codetopia.Xna.Lib;
using Codetopia.Xna.Lib.Graphics;
using Codetopia.Xna.Lib.Graphics.Particles;
using Codetopia.Xna.Lib.Util;

namespace Particles.Screens
{
	public class TitleScreen : GameScreen
	{
		GameSprite spriteTitle;

		public TitleScreen (Game game) : base(game) {
			BackgroundColor = Color.White;
		}

		public override void Showing () {
			spriteTitle = new GameSprite(
				Content.Load<Texture2D> ("images/ParticlesTitle"), 
				new Rectangle(0,0,1024,512)
			);
		}

		public override void Hiding () {
		}

		public override void Update (GameTime gameTime)
		{
			base.Update (gameTime);

			var nextScreen = 
				GamePadEx.WasJustPressed (PlayerIndex.One, Buttons.A) ||
				GamePadEx.WasJustPressed (PlayerIndex.One, Buttons.Start) ||
				TouchPanelEx.WasJustPressed();
			var prevScreen = 
				GamePadEx.WasJustPressed (PlayerIndex.One, Buttons.Back);

			if (nextScreen) {
				ScreenUtil.Show (new MainScreen (Parent));
			} else if (prevScreen) {
				ScreenUtil.Show (new SplashScreen (Parent));
			}
		}

		public override void Draw (GameTime gameTime, SpriteBatch spriteBatch)
		{
			base.Draw (gameTime, spriteBatch);
			spriteBatch.Begin ();
			SpriteUtil.DrawInRect (spriteBatch, spriteTitle, GraphicsDevice.Viewport.Bounds);
			spriteBatch.End ();
		}
	}
}

