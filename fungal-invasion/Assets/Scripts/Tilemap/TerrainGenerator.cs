using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Kp4wsGames.Default
{
	[RequireComponent(typeof(Tilemap))]
	public class TerrainGenerator : MonoBehaviour
	{
		[SerializeField] private TerrainConfig terrainConfig;
		private Tilemap tileMap;

        private void Awake()
        {
			tileMap = GetComponent<Tilemap>();
		}

        private void Start()
		{
			GenerateMap();
		}

		private void GenerateMap()
		{
			float[,] heightMap = Noise.GenerateNoiseMap(terrainConfig.Width,
			   terrainConfig.Height, terrainConfig.Offset, terrainConfig.Seed, terrainConfig.Scale, terrainConfig.Octaves, terrainConfig.Lacunarity, terrainConfig.Persistence);

			for (int y = 0; y < terrainConfig.Height; y++)
			{
				for (int x = 0; x < terrainConfig.Width; x++)
				{
					float height = heightMap[x, y];
					var position = new Vector3Int(x, y, 10);
					var tileModel = terrainConfig.GetTile(height);

					//TODO have a slight change in color for more variety
					//TODO For some reason Unity has a bug where you cannot change the tile color. Doing so will cause the entire tile map to disappear
					//tileModel.Tile.color = tileModel.Color;

					tileMap.SetTile(position, tileModel.Tile);
				}
			}

			//TODO: Set wall colliders on the outside of the map
		}
    }
}