using System;
using Terraria;
using Terraria.ModLoader;

namespace CheatSheet;

public class CheatCommand : ModCommand
{
    public override string Command => "cheat";
    public override CommandType Type => CommandType.Chat;

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        if (args.Length < 2) return;
        try
        {
            var player = caller.Player;
            var val = Convert.ToInt32(args[1]);
            switch (args[0])
            {
                case "stack":
                    ModifyItemStack(val, player);
                    break;
                case "modifier":
                    ChangeItemModifier(val, player);
                    break;
                case "modifier-i":
                    ChangeInventoryItemModifier(val, player);
                    break;
                case "time":
                    ChangeTime(val, player);
                    break;
            }
        }
        catch
        {
            // ignored
        }
    }

    private void ChangeTime(int val, Player player)
    {
        CheatConfig.timeRate = val;
    }

    private static void ChangeInventoryItemModifier(int val, Player player)
    {
        if (player.inventory[19] != null && val > 0) player.inventory[19].prefix = val;
    }

    private static void ChangeItemModifier(int val, Player player)
    {
        var armors = player.armor;
        for (var i = 3; i < 15; i++)
            if (armors[i] != null)
                armors[i].prefix = val;
    }

    private static void ModifyItemStack(int val, Player player)
    {
        if (player.inventory[19] != null && val > 0) player.inventory[19].stack = val;
    }
}