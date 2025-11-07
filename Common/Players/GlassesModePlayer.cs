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
		public BuffDrawParams GlassesBuffParams;
		public bool HasGlassesModeBuff { get; private set; }

		public void ResetEffects()
		{
			HasGlassesModeBuff = false;
		}

		public void ActivateBuff()
		{
			HasGlassesModeBuff = true;
			// TODO: make buffs / minimap / hearts / stars / stats (more) transparent
		}

		/// finds the glasses mode buff in the buff list and swaps it to the very beginning of it
		public void GlassesBuffToFront()
		{
			if (!HasGlassesModeBuff) {
				return;
			}
			int b_type = ModContent.BuffType<GlassesModeBuff>();
			int index = 0;
			bool found = false;
			for (index = 0; index < Player.buffType.Length; ++index) {
				if (Player.buffType[index] == b_type) {
					found = true;
					break;
				}
			}
			if (!found || index == 0) {
				return;
			}
			int b_time = Player.buffTime[index];
			int other_b_type = Player.buffType[0];
			int other_b_time = Player.buffTime[0];
			Player.buffType[0] = b_type;
			Player.buffTime[0] = b_time;
			Player.buffType[index] = other_b_type;
			Player.buffTime[index] = other_b_time;
		}

		public override void PreUpdate()
		{
			GlassesBuffToFront();
		}
	}
}
