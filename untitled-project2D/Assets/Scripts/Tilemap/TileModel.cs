using UnityEngine;
using UnityEngine.Tilemaps;

namespace Kp4wsGames.Default
{
    [System.Serializable]
	public class TileModel
	{
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public float Height { get; set; }
        [field: SerializeField] public Tile Tile { get; set; }
        //[field: SerializeField] public Color Color { get; set; } = Color.white;
    }
}
