using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using GlassesMode.Content.Items.Consumables;
using GlassesMode.Content.Buffs;

namespace GlassesMode.Common.Players
{
	// This class showcases things you can do with fishing
	public class GlassesModePlayer : ModPlayer
	{
		public bool hasGlassesModeBuff { get; private set; }

		public void ResetEffects()
		{
			hasGlassesModeBuff = false;
		}
		public void ActivateBuff()
		{
			hasGlassesModeBuff = true;
			// TODO: make buffs / minimap / hearts / stars / stats (more) transparent
		}
		public override void PreUpdate()
		{
			if (!hasGlassesModeBuff) {
				return;
			}
			int b_type = ModContent.BuffType<GlassesModeBuff>();
			ModPlayer mp = (ModPlayer) this;
			int index = 0;
			bool found = false;
			for (index = 0; index < mp.Player.buffType.Length; ++index) {
				if (mp.Player.buffType[index] == b_type) {
					found = true;
					break;
				}
			}
			if (!found || index == 0) {
				return;
			}
			//  b_type = mp.Player.buffType[index];
			int b_time = mp.Player.buffTime[index];
			int other_b_type = mp.Player.buffType[0];
			int other_b_time = mp.Player.buffTime[0];
			mp.Player.buffType[0] = b_type;
			mp.Player.buffTime[0] = b_time;
			mp.Player.buffType[index] = other_b_type;
			mp.Player.buffTime[index] = other_b_time;
		}
	}
}
