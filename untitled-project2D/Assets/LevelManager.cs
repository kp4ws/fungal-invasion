using System;
using UnityEngine;

namespace Kp4wsGames.Default
{
	public class LevelManager : MonoBehaviour
	{
        [SerializeField] private GameObject levelObject;

        private int levelSize = 3;
        public const float resolutionY = 1080;
        public const float resolutionX = 1920;

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
            position = CalculatePosition();
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
                    GameObject levelChunk = createLevelChunk(y, x);
                }
            }
        }

        private GameObject createLevelChunk(int y, int x)
        {
            Vector2 spawnPosition = new Vector2(x * position.Value.xPosition, y * position.Value.yPosition);
            var levelChunk = Instantiate(levelObject, spawnPosition, Quaternion.identity);

            //TODO Change levelChunk color/attributes based on the spawn position
            levelChunk.transform.parent = gameObject.transform;
            string name = string.Format("LevelChunk({0},{1})", x, y);
            levelChunk.name = name;
            levelChunk.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);

            return levelChunk;
        }

        private void Update()
        {
            //If player off center
            RedrawLevel();
        }

        private void RedrawLevel()
        {
            foreach (Transform child in transform)
            {
                //If child does not correspond to position
            }
        }
    }
}