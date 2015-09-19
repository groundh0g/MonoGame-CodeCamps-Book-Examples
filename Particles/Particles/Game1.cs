#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;

using Codetopia.Xna.Framework.Input;
using Codetopia.Xna.Framework.Input.Touch;
using Codetopia.Xna.Lib.Graphics.Particles;
using Codetopia.Xna.Lib.Util;

using Codetopia.Xna.Framework;

#endregion

namespace Particles
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Texture2D texParticle;

		Emitter emitter = new Emitter();

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
			texParticle = Content.Load<Texture2D>("images/Particle");

			emitter.Texture = texParticle;
			emitter.ParticlesPerUpdate = 20;
			emitter.ParticleMinAgeToDraw = 0.1f;
			emitter.MaxParticles = 15000;
			emitter.EmitterRect = new Rectangle(200, 200, 0, 0);
			emitter.RangeColor = 
				RangedVector4.FromColors(Color.Orange, Color.Yellow);
			emitter.RangeVelocity = new RangedVector2(
				new Vector2 (-200.0f, -200.0f),
				new Vector2 (200.0f, 200.0f));
			emitter.EmitterBoundsRect = GraphicsDevice.Viewport.Bounds;

			// add a modifier to the emitter
			var modifier = new Modifier();
			modifier.VelocityDelta = new Vector2(80.0f, 200.0f);
			modifier.Enabled = true;
			emitter.Modifiers.Add (modifier);
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__
			if (GamePadEx.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState ().IsKeyDown (Keys.Escape)) {
				Exit ();
			}
			#endif
			// TODO: Add your update logic here			
			base.Update (gameTime);

			var touchState = TouchPanelEx.GetState();
			if (touchState.Count > 0) {
				emitter.Active = 
					touchState [0].State == TouchLocationState.Pressed ||
					touchState [0].State == TouchLocationState.Moved;
				emitter.EmitterRect = new Rectangle (
					(int)Math.Round(touchState [0].Position.X),
					(int)Math.Round(touchState [0].Position.Y),
					emitter.EmitterRect.Width,
					emitter.EmitterRect.Height
				);
			} else {
				emitter.Active = false;
			}

			if (GamePadEx.GetState (PlayerIndex.One).IsButtonDown (Buttons.A)) {
				emitter.Active = true;
			}

			emitter.Update (gameTime.ElapsedGameTime.TotalSeconds);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
		
			//TODO: Add your drawing code here
            
			base.Draw (gameTime);
			spriteBatch.Begin ();
			emitter.Draw (spriteBatch);
			spriteBatch.End ();
		}
	}
}

