using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using GlassesMode.Content.Items.Consumables;
using GlassesMode.Content.Buffs;

namespace GlassesMode.Common.Players
{
	public class GlassesModePlayer : ModPlayer
	{
		public BuffDrawParams GlassesBuffParams;
		public bool hasGlassesBuff { get; private set; }

		public override void ResetEffects()
		{
			hasGlassesBuff = false;
		}

		public void ActivateEffects()
		{
			hasGlassesBuff = true;
		}

		/// finds the glasses mode buff in the buff list and swaps it to the very beginning of it
		public void GlassesBuffToFront()
		{
			int buffType = ModContent.BuffType<GlassesModeBuff>();
			int index = 0;
			for (; index < Player.buffType.Length; ++index) {
				if (Player.buffType[index] == buffType) {
					if (index == 0) {
						return;
					}
					break;
				}
			}
			if (Player.buffType.Length <= index) {
				return;
			}
			int buffTime = Player.buffTime[index];
			int otherBuffType = Player.buffType[0];
			int otherBuffTime = Player.buffTime[0];
			Player.buffType[0] = buffType;
			Player.buffTime[0] = buffTime;
			Player.buffType[index] = otherBuffType;
			Player.buffTime[index] = otherBuffTime;
		}
	}
}
