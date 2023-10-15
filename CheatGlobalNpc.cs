using Terraria;
using Terraria.ModLoader;

namespace CheatSheet;

public class CheatGlobalNpc : GlobalNPC
{
    public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
    {
        spawnRate = (int)(spawnRate * CheatConfig.SpawnRateMultiplier);
        maxSpawns = (int)(maxSpawns * CheatConfig.MaxSpawnsMultiplier);
    }
}