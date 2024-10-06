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
	public class __DisableBuffDisplay : GlobalBuff
	{
		/** 
		 * if player is using the GlassesModeBuff, hide all other buffs
		 *
		 * @param type 
		 * @param drawParams 
		 *
		 */
		public override bool PreDraw(SpriteBatch spriteBatch, int type, int buffIndex, ref BuffDrawParams drawParams)
		{
			GlassesModePlayer player = Main.LocalPlayer.GetModPlayer<GlassesModePlayer>();
			if (player.hasGlassesModeBuff) {
				if (type == ModContent.BuffType<GlassesModeBuff>()) {
					return true;
				}
				return false;
			}
			return base.PreDraw(spriteBatch, type, buffIndex, ref drawParams);
		}
	}
}
