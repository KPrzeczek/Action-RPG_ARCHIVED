﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPG.Util.Debug
{
	public static class DebugTools
	{
		private static Texture2D _texture;

		private static Texture2D GetTexture(SpriteBatch spriteBatch)
		{
			if(_texture == null)
			{
				_texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
				_texture.SetData(new[] { Color.White });
			}

			return _texture;
		}

		public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color)
		{
			Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, rectangle.Width, rectangle.Height);
			Color[] data = new Color[rectangle.Width * rectangle.Height];
			for(int i = 0; i < data.Length; ++i)
				data[i] = color;
			rect.SetData(data);
			Vector2 coor = new Vector2(rectangle.X, rectangle.Y);
			spriteBatch.Draw(rect, coor, Color.White);
		}

		public static void DrawLine(SpriteBatch spriteBatch, Vector2 point1, Vector2 point2, Color color, float thickness = 1f)
		{
			var distance = Vector2.Distance(point1, point2);
			var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
			DrawLine(spriteBatch, point1, distance, angle, color, thickness);
		}

		public static void DrawLine(SpriteBatch spriteBatch, Vector2 point, float length, float angle, Color color, float thickness = 1f)
		{
			var origin = new Vector2(0f, 0.5f);
			var scale = new Vector2(length, thickness);
			spriteBatch.Draw(GetTexture(spriteBatch), point, null, color, angle, origin, scale, SpriteEffects.None, 1f);
		}
	}
}
