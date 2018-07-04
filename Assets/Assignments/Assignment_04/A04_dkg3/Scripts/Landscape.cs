using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A04dkg3
{
    public class Landscape : MonoBehaviour
    {
        // this script is attached to the terrain object to make the terrain

        // got help from this video https://www.youtube.com/watch?v=vFvwyu_ZKfU
        // demensions for the terrain
        public int width = 100;
        public int height = 100;
        public int depth = 5;
        public float scale = 20f;

        // Use this for initialization
        void Start()
        {
            // access the terrain components
            Terrain terrain = GetComponent<Terrain>();
            terrain.terrainData = GenTerrain(terrain.terrainData);
        }

        // Update is called once per frame
        void Update()
        {

        }

        TerrainData GenTerrain (TerrainData terrainData)
        {
            // generate the terrain by calling the methods below
            terrainData.heightmapResolution = width + 1;
            terrainData.size = new Vector3(width, depth, height);
            terrainData.SetHeights(0, 0, GenHeights());
            return terrainData;
        }

        float[,] GenHeights()
        {
            // set the heights of the terrain
            float[,] heights = new float[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    heights[x, y] = CalcHeight(x, y);
                }
            }
            return heights;
        }

        float CalcHeight (int x, int y)
        {
            // use perlin noise to alter the heights and add bumps and ridges to it
            float xCoordinate = (float)x / width * scale;
            float yCoordinate = (float)y / height * scale;
            return Mathf.PerlinNoise(xCoordinate, yCoordinate);
        }
    }
}