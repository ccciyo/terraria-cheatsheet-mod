using Terraria;
using Terraria.ModLoader;

namespace CheatSheet;

public class CheatGlobalNpc : GlobalNPC
{
    public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
    {
        spawnRate = CheatConfig.SpawnRate;
        maxSpawns = CheatConfig.MaxSpawns;
    }
}