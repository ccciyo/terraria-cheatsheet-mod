using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        if (item.fishingPole > 0)
        {
            item.useTime = 1;
            item.useAnimation = 50;
            item.fishingPole = 100;
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
        int startX = sX - CheatConfig.shovelX;
        int endX = sX + CheatConfig.shovelX;

        int startY = sY - CheatConfig.shovelY;
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

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        foreach (var tooltipLine in tooltips)
        {
            if (tooltipLine.Name.Equals("ItemName"))
            {
                tooltipLine.Text += $"  |  {item.netID}";
            }
        }
    }
}