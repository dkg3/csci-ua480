using UnityEngine;
using UnityEngine.Networking;

namespace A07dkg3
{
    public class EnemySpawner : NetworkBehaviour
    {
        // declare varibles for the enemy prefab and the number of enemies to create
        public GameObject enemyPrefab;
        public int numberOfEnemies;

        public override void OnStartServer()
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                // spawn all the enemies in random positions and rotations within the following ranges
                var spawnPosition = new Vector3(
                    Random.Range(-8.0f, 8.0f),
                    0.0f,
                    Random.Range(-8.0f, 8.0f));

                var spawnRotation = Quaternion.Euler(
                    0.0f,
                    Random.Range(0, 180),
                    0.0f);
                // instantiate the enemies using the enemy prefab and the random
                // positions and rotations that were just collected
                var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
                NetworkServer.Spawn(enemy);
            }
        }
    }
}
