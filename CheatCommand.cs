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

            switch (args[0])
            {
                case "stack":
                    ModifyItemStack(Convert.ToInt32(args[1]), player);
                    break;
                case "id":
                    ModifyItemId(Convert.ToInt32(args[1]), player);
                    break;
                case "modifier":
                    ChangeItemModifier(Convert.ToInt32(args[1]), player);
                    break;
                case "modifier-i":
                    ChangeInventoryItemModifier(Convert.ToInt32(args[1]), player);
                    break;
                case "time":
                    ChangeTime(Convert.ToInt32(args[1]), player);
                    break;
                case "spawn":
                    ChangeSpawn(args[1], args[2], player);
                    break;
                case "wall":
                    ChangeShovelCanKillWall(Convert.ToInt32(args[1]), player);
                    break;
            }
        }
        catch
        {
            // ignored
        }
    }

    private void ChangeShovelCanKillWall(int val, Player player)
    {
        CheatConfig.canShovelKillWall = val > 0;
    }

    private void ModifyItemId(int val, Player player)
    {
        if (player.inventory[19] != null && val > 0) player.inventory[19].netID = val;
    }

    private static void ChangeSpawn(string spawnRate, string maxSpawn, Player player)
    {
        CheatConfig.SpawnRateMultiplier = float.Parse(spawnRate);
        CheatConfig.MaxSpawnsMultiplier = float.Parse(maxSpawn);
    }

    private static void ChangeTime(int val, Player player)
    {
        CheatConfig.TimeRate = val;
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