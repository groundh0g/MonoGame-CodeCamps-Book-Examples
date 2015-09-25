using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Codetopia.Xna.Framework.Input;
using Codetopia.Xna.Framework.Input.Touch;
using Codetopia.Xna.Lib.Graphics;
using Codetopia.Xna.Lib.Util;

namespace Puzzle.Screens
{
	public class SplashScreen : GameScreen
	{
		GameSprite spriteTitle;

		public SplashScreen (Game parent) : base(parent)
		{
			BackgroundColor = Color.White;
			ExitOnBack = true;
		}

		public override void Showing () {
			spriteTitle = new GameSprite(
				Content.Load<Texture2D> ("images/splashScreen"), 
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

			if (nextScreen) {
				ScreenUtil.Show (new TitleScreen (Parent));
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

