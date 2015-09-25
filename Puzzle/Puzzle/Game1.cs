#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using Codetopia.Xna.Framework;
using Codetopia.Xna.Framework.Input;
using Codetopia.Xna.Framework.Input.Touch;
using Codetopia.Xna.Lib;
using Codetopia.Xna.Lib.Graphics;
using Codetopia.Xna.Lib.Graphics.Particles;
using Codetopia.Xna.Lib.Util;

using Puzzle.Screens;

#endregion

namespace Puzzle
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = true;
			this.IsMouseVisible = PlatformUtil.IsDesktop;
			GamePadEx.KeyboardPlayerIndexEx = PlayerIndexEx.Auto;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			base.Initialize ();
				
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);

			//TODO: use this.Content to load your game content here
			BitmapFont.LoadedFonts = BitmapFont.LoadFromTextureAtlas (Content, "titleAndFonts");
			ScreenUtil.Show(ScreenUtil.CurrentScreen ?? new SplashScreen(this));
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			// TODO: Add your update logic here			
			base.Update (gameTime);
			GamePadEx.Update (gameTime);
			TouchPanelEx.Update (gameTime);
			ScreenUtil.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			//TODO: Add your drawing code here
			ScreenUtil.Draw(gameTime, spriteBatch);
		}
	}
}

