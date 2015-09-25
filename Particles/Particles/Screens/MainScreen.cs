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
	public class MainScreen : GameScreen
	{
		Texture2D texParticle;
		Emitter emitter = new Emitter();

		public MainScreen (Game game) : base(game) {
		}

		public override void Showing ()
		{
			texParticle = Content.Load<Texture2D>("images/Particle");

			emitter.Enabled = true;
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

		public override void Hiding ()
		{
			emitter.Active = false;
			emitter.Enabled = false;
		}

		public override void Update (GameTime gameTime)
		{
			base.Update (gameTime);
			var gamepad1 = GamePadEx.GetState (PlayerIndex.One);

			if (gamepad1.Buttons.Back == ButtonState.Pressed) {
				ScreenUtil.Show (new TitleScreen (Parent));
			}

			// === TouchPanel or Mouse ===
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
			// ===

			// === Controller or Keyboard ===
			if (gamepad1.IsButtonDown (Buttons.A)) {
				emitter.Active = true;
			}

			if (gamepad1.DPad.Up == ButtonState.Pressed) {
				emitter.EmitterRect = new Rectangle (
					emitter.EmitterRect.X,
					emitter.EmitterRect.Y - 5,
					emitter.EmitterRect.Width,
					emitter.EmitterRect.Height);
			} else if (gamepad1.DPad.Down == ButtonState.Pressed) {
				emitter.EmitterRect = new Rectangle (
					emitter.EmitterRect.X,
					emitter.EmitterRect.Y + 5,
					emitter.EmitterRect.Width,
					emitter.EmitterRect.Height);
			}

			if (gamepad1.DPad.Left == ButtonState.Pressed) {
				emitter.EmitterRect = new Rectangle (
					emitter.EmitterRect.X - 5,
					emitter.EmitterRect.Y,
					emitter.EmitterRect.Width,
					emitter.EmitterRect.Height);
			} else if (gamepad1.DPad.Right == ButtonState.Pressed) {
				emitter.EmitterRect = new Rectangle (
					emitter.EmitterRect.X + 5,
					emitter.EmitterRect.Y,
					emitter.EmitterRect.Width,
					emitter.EmitterRect.Height);
			}
			// ===

			emitter.Update (gameTime.ElapsedGameTime.TotalSeconds);
		}

		public override void Draw (GameTime gameTime, SpriteBatch spriteBatch)
		{
			base.Draw (gameTime, spriteBatch);
			spriteBatch.Begin ();
			emitter.Draw (spriteBatch);
			spriteBatch.End ();
		}
	}
}

