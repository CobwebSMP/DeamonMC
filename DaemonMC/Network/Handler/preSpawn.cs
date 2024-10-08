﻿using System.Numerics;
using DaemonMC.Network.Bedrock;
using DaemonMC.Network.RakNet;
using DaemonMC.Utils.Text;
using fNbt;

namespace DaemonMC.Network.Handler
{
    public class preSpawn
    {
        public static void execute()
        {
            var session = RakSessionManager.getCurrentSession();

            Player player = new Player();
            player.username = session.username;

            long EntityId = Server.AddPlayer(player);
            session.EntityID = EntityId;

            var pk1 = new StartGamePacket
            {
                EntityId = EntityId,
                gameType = 0,
                GameMode = 2,
                position = new Vector3(0, 1, 0),
                rotation = new Vector2(0, 0),
                spawnBlockX = 0,
                spawnBlockY = 0,
                spawnBlockZ = 0,
                difficulty = 1,
                dimension = 0,
                seed = 9876,
                generator = 9,
            };
            StartGame.Encode(pk1);

            var pk = new CreativeContentPacket
            {

            };
            CreativeContent.Encode(pk);

            var pk2 = new BiomeDefinitionListPacket
            {
                biomeData = new fNbt.NbtCompound("")
                {
                new NbtCompound("plains")
                    {
                        new NbtFloat("downfall", 0.4f),
                        new NbtFloat("temperature", 0.8f),
                    }
                }
            };
            BiomeDefinitionList.Encode(pk2);

            var pk3 = new LevelChunkPacket
            {
                chunkX = 0,
                chunkZ = 0,
                data = ""
            };
            LevelChunk.Encode(pk3);

            var pk4 = new PlayStatusPacket
            {
                status = 3,
            };
            PlayStatus.Encode(pk4);
            Log.info($"{player.username} spawned at X:{pk1.position.X} Y:{pk1.position.Y} Z:{pk1.position.Z}");
        }
    }
}
