using GlassesMode.Common.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace GlassesMode.Content.Buffs
{
	public class GlassesModeBuff : ModBuff
	{
		public override void Update(Player player, ref int buffIndex)
		{
			// Use a ModPlayer to keep track of the buff being active
			player.GetModPlayer<GlassesModePlayer>().ActivateBuff();
		}
		public override bool RightClick(int buffIndex)
		{
			Main.LocalPlayer.GetModPlayer<GlassesModePlayer>().ResetEffects();
			return true;
		}
	}

	public class DisableBuffDisplay : GlobalBuff
	{
		public override bool PreDraw(SpriteBatch spriteBatch, int type, int buffIndex, ref BuffDrawParams drawParams)
		{
			GlassesModePlayer player = Main.LocalPlayer.GetModPlayer<GlassesModePlayer>();
			player.GlassesBuffToFront();
			if (player.HasGlassesModeBuff) {
				// only draw the glassesmode buff
				if (type == ModContent.BuffType<GlassesModeBuff>()) {
					player.GlassesBuffParams = drawParams;
					return true;
				}
				// this hides the buff icon, remaining time text and mouse rectangle thus
				// making it so that the buff completely vanishes but still remains active
				drawParams.Position = player.GlassesBuffParams.Position;
				drawParams.MouseRectangle = Rectangle.Empty;
				drawParams.TextPosition = player.GlassesBuffParams.TextPosition;
				drawParams.TextPosition.Y -= Main.screenHeight * 2;
				return false;
			}
			return true;
		}
	}
}
