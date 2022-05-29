using Kp4wsGames.Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kp4wsGames.Default
{
	public class LevelManager : MonoBehaviour
	{
        [SerializeField] private int levelSize = 25;
        [SerializeField] private LevelChunk chunkPrefab;

        public const float resolutionY = 1080;
        public const float resolutionX = 1920;

        private List<LevelChunk> levelChunkList;
        private LevelPosition? position;
        
        struct LevelPosition
        {
            public float xPosition;
            public float yPosition;

            public LevelPosition(float xPosition, float yPosition)
            {
                this.xPosition = xPosition;
                this.yPosition = yPosition;
            }
        }

        private void Start()
        {
            levelChunkList = new List<LevelChunk>();
            position = CalculatePosition();
            var collider = GetComponent<PolygonCollider2D>();

            //DO NOT use same calculations. Causes errors
            //Vector2 colliderSize = new Vector2(position.Value.xPosition * levelSize, position.Value.yPosition * levelSize);
            //Vector2 colliderOffset = new Vector2((position.Value.xPosition * (levelSize - 1)) / 2, (position.Value.yPosition * (levelSize - 1)) / 2);
            
            float offsetX = (position.Value.xPosition * (levelSize - 1)) / 2;
            float offsetY = (position.Value.yPosition * (levelSize - 1)) / 2;

            Vector2[] colliderPts = { 
                new Vector2((position.Value.xPosition / 2) * levelSize + offsetX, (position.Value.yPosition / 2) * levelSize + offsetY),
                new Vector2(-(position.Value.xPosition / 2) * levelSize + offsetX, (position.Value.yPosition / 2) * levelSize + offsetY),
                new Vector2(-(position.Value.xPosition / 2) * levelSize + offsetX, -(position.Value.yPosition / 2) * levelSize + offsetY),
                new Vector2((position.Value.xPosition / 2) * levelSize + offsetX, -(position.Value.yPosition / 2) * levelSize + offsetY)
            };
            //collider.offset = colliderOffset;
            collider.points = colliderPts;

            CreateLevel();
        }

        private LevelPosition? CalculatePosition()
        {
            if (position != null)
            {
                Debug.LogError("CalculatePosition should only be called once");
                return position;
            }

            float PPU = resolutionY / (Camera.main.orthographicSize * 2);
            float x = resolutionX / PPU;
            float y = resolutionY / PPU;
            return new LevelPosition(x, y);
        }

        private void CreateLevel()
        {
            for (int y = 0; y < levelSize; y++)
            {
                for (int x = 0; x < levelSize; x++)
                {
                    levelChunkList.Add(createLevelChunk(y, x));
                }
            }
        }

        private LevelChunk createLevelChunk(int y, int x)
        {
            Vector2 spawnPosition = new Vector2(x * position.Value.xPosition, y * position.Value.yPosition);
            var levelChunk = Instantiate(chunkPrefab, spawnPosition, Quaternion.identity);

            //TODO Change levelChunk color/attributes based on the spawn position
            levelChunk.transform.parent = gameObject.transform;
            string name = string.Format("LevelChunk({0},{1})", x, y);
            levelChunk.name = name;
            levelChunk.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            levelChunk.SetManager(this);
            activeChunk = levelChunk;
            return levelChunk;
        }

        private void RedrawLevel()
        {
            foreach (Transform child in transform)
            {
                //If child does not correspond to position
            }
        }

        LevelChunk activeChunk;
        public void SetActiveLevelChunk(LevelChunk chunk)
        {
            activeChunk.GetComponent<SpriteRenderer>().color = Color.black;
            activeChunk = chunk;
            activeChunk.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}