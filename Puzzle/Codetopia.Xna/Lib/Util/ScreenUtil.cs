﻿using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Codetopia.Xna.Framework.Input;
using Codetopia.Xna.Lib.Graphics;

namespace Codetopia.Xna.Lib.Util
{
	public static class ScreenUtil
	{
		public static GameScreen CurrentScreen { get; private set; }

		public static void Show(GameScreen screen) {
			GamePadEx.ResetWasPressed ();
			if (CurrentScreen != screen) {
				if (CurrentScreen != null) {
					CurrentScreen.Hiding ();
				}
				CurrentScreen = screen;
			}
			if (CurrentScreen != null) {
				CurrentScreen.Showing ();
			}
		}

		public static void Update (GameTime gameTime) {
			if (CurrentScreen != null)
				CurrentScreen.Update (gameTime);
		}

		public static void Draw (GameTime gameTime, SpriteBatch spriteBatch) {
			if (CurrentScreen != null)
				CurrentScreen.Draw (gameTime, spriteBatch);
		}

		public static void Exit() {
			if (CurrentScreen != null) {
				CurrentScreen.Hiding ();
				CurrentScreen.Parent.Exit ();
			}
		}
	}
}

