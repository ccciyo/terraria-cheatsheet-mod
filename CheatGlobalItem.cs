using Terraria;
using Terraria.ModLoader;

namespace CheatSheet;

public class CheatGlobalItem : GlobalItem
{
    public override void SetDefaults(Item entity)
    {
        if (entity.axe > 0 || entity.pick > 0 || entity.hammer > 0 || entity.createTile > 0 ||
            entity.createWall > 0)
            entity.useTime = 1;
    }
}