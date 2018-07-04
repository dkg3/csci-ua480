using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A04dkg3
{
    public class PopulateTrees : MonoBehaviour
    {
        // this script is attached to the terrain object to fill the terrain with trees, rocks, bushes, and snow

        // create game objects for all the elements that will be in the scene
        public GameObject trees;
        public GameObject balls;
        public GameObject bushes;
        public GameObject snowfall;
        GameObject tree;
        GameObject ball;
        GameObject bush;
        GameObject snow;
        public float perlinNoise;

        // Use this for initialization
        void Start()
        {
            // populate 50 randomly placed trees
            for (int i = 0; i < 50; i++)
            {
                // place at the top of the terrain
                Vector3 pos = transform.position;
                pos.y = Terrain.activeTerrain.SampleHeight(transform.position);
                // instantiate the tree prefabs
                tree = Instantiate(trees);
                // place them at random x and z coordinates
                tree.transform.position = new Vector3(Random.Range(-125f, 125f), pos.y+.3f, Random.Range(-125f, 125f));
                // scale the y axis of the object using perlin noise
                perlinNoise = Mathf.PerlinNoise(tree.transform.position.x, tree.transform.position.y);
                tree.transform.localScale = new Vector3(1, perlinNoise*4f, 1);
            }

            // populate 15 randomly placed rocks
            for (int i = 0; i < 15; i++)
            {
                // place at the top of the terrain
                Vector3 pos = transform.position;
                pos.y = Terrain.activeTerrain.SampleHeight(transform.position);
                // instantiate the rock prefabs
                ball = Instantiate(balls);
                // place them at random x and z coordinates
                ball.transform.position = new Vector3(Random.Range(-125f, 125f), pos.y+5f, Random.Range(-125f, 125f));
                // scale the y axis of the object using perlin noise
                perlinNoise = Mathf.PerlinNoise(ball.transform.position.x, ball.transform.position.z);
                ball.transform.localScale = new Vector3(perlinNoise * 10, perlinNoise * 10, perlinNoise * 10);
            }

            // populate 35 randomly placed bushes
            for (int i = 0; i < 35; i++)
            {
                // place at the top of the terrain
                Vector3 pos = transform.position;
                pos.y = Terrain.activeTerrain.SampleHeight(transform.position);
                // instantiate the bush prefabs
                bush = Instantiate(bushes);
                // place them at random x and z coordinates
                bush.transform.position = new Vector3(Random.Range(-125f, 125f), pos.y+5f, Random.Range(-125f, 125f));
                // scale the y axis of the object using perlin noise
                perlinNoise = Mathf.PerlinNoise(bush.transform.position.x, bush.transform.position.z);
                bush.transform.localScale = new Vector3(perlinNoise * Random.Range(6, 8), perlinNoise * Random.Range(6, 8), perlinNoise * Random.Range(6, 8));
            }

            // populate 75 randomly placed snow particle systems
            for (int i = 0; i < 75; i++)
            {
                // instantiate the snow prefabs
                snow = Instantiate(snowfall);
                // place them at random x and z coordinates
                snow.transform.position = new Vector3(Random.Range(-125f, 125f), 125, Random.Range(-125f, 125f));
                // scale the y axis of the object using perlin noise
                perlinNoise = Mathf.PerlinNoise(snow.transform.position.x, snow.transform.position.z);
                snow.transform.localScale = new Vector3(perlinNoise * Random.Range(6, 8), perlinNoise * Random.Range(6, 8), perlinNoise * Random.Range(6, 8));
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}