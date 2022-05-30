using UnityEngine;

namespace Kp4wsGames.Default
{
    [CreateAssetMenu(fileName = "Terrain", menuName = "Terrains/Make New Terrain", order = 0)]
    public class TerrainConfig : ScriptableObject
    {
		[field: SerializeField] public int Width { get; set; } = 25;
		[field: SerializeField] public int Height { get; set; } = 25;
		[field: SerializeField] public Vector3 Offset { get; set; }
		[field: SerializeField] public string Seed { get; set; }
		[field: SerializeField] public float Scale { get; set; } = 2f;
		[field: SerializeField] public int Octaves { get; set; } = 8;
		[field: SerializeField] public float Lacunarity { get; set; } = 2;
		[field: SerializeField] public float Persistence { get; set; } = 0.5f;
		[field: SerializeField] public TileModel[] Tiles { get; set; }
		//[field: SerializeField] public float HeightMultiplier { get; set; } = 0;
		//[field: SerializeField] public AnimationCurve HeightCurve { get; set; }
		//[field: SerializeField] public Sprite defaultSprite { get; set; }
		//[field: SerializeField] public Tile TilePrefab { get; set; }

		public TileModel GetTile(float height)
		{
			foreach (TileModel tile in Tiles)
			{
				if (height < tile.Height)
				{
					return tile;
				}
			}
			return Tiles[Tiles.Length - 1];
		}
	}
}
