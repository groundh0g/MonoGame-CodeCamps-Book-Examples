using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Codetopia.Xna.Lib.Util.Collision
{
	public interface IPixelPerfectSprite
	{
		Texture2D TextureData { get; set; }
		Rectangle TextureRect { get; set; }
		Vector2 Location { get; set; }
		bool[,] OpaqueData { get; set; }
	}
}

