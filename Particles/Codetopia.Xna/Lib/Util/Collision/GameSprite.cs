using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Codetopia.Xna.Lib.Util
{
	public class GameSprite
	{
		public Texture2D TextureData { get; set; }
		public Rectangle TextureRect { get; set; }
		public Vector2 Location { get; set; }
		public bool[,] OpaqueData { get; set; }

		// draw this sprite, using current settings, and specified tint
		public void Draw(SpriteBatch batch, Color color)
		{
			batch.Draw(TextureData, Location, TextureRect, color);
		}
	}
}

