using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatSheet;

public class CheatGlobalItem : GlobalItem
{
    public override void SetDefaults(Item item)
    {
        if (item.axe > 0 || item.pick > 0 || item.hammer > 0 || item.createTile >= TileID.Dirt || item.createWall > 0)
        {
            if (item.type == 4711)
            {
                return;
            }

            item.useTime = 1;
        }
    }

    public override bool? UseItem(Item item, Player player)
    {
        if (item.type == 4711)
        {
            UseShovel(item, player);
            return true;
        }

        return null;
    }


    private static void UseShovel(Item item, Player player)
    {
        int sX = Player.tileTargetX;
        int sY = Player.tileTargetY;
        int startX = sX - 5;
        int endX = sX + 5;

        int startY = sY - 9;
        int endY = sY + 1;
        for (int x = startX; x <= endX; ++x)
        {
            for (int y = startY; y <= endY; ++y)
            {
                if (x == startX || x == endX || y == startY || y == endY)
                {
                    if (CheatConfig.canShovelKillWall)
                    {
                        WorldGen.KillWall(x, y);
                    }

                    continue;
                }

                WorldGen.KillTile(x, y);

                if (CheatConfig.canShovelKillWall)
                {
                    WorldGen.KillWall(x, y);
                }
            }
        }
    }
}