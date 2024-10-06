using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GlassesMode.Content.Items.Consumables
{
	public class GlassesModePotion : ModItem
	{
		public string Description;
		public static int buffTime { get; private set; }
		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.buyPrice(silver: 8);
			Item.buffType = ModContent.BuffType<Buffs.GlassesModeBuff>();
			// 3 min duration
			buffTime = Item.buffTime = 3 * 60 * 60;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater, 1)
				.AddIngredient(ItemID.Goggles, 1)
				.AddTile(TileID.Bottles)
				.Register();
		}
	}
}
