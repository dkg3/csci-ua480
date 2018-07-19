using UnityEngine;
using UnityEngine.Networking;

namespace A07dkg3
{
    public class EnemyMoveAndShoot : NetworkBehaviour
    {
        // declare variables to be used to create and spawn bullets
        public GameObject bulletPrefab;
        public Transform bulletSpawn;
        // declare a vector3 for velocity and a float for speed to move the enemy objects
        Vector3 velocity;
        float speed = 3f;

        void Start()
        {
            // give it a starting velocity vector
            velocity = new Vector3(1.0f, 0.0f, 1.0f);
            // call these methods every 2 and 5 seconds
            InvokeRepeating("RandomRotateAndMove", 0, 2);
            InvokeRepeating("CmdShoot", 0, 5);
        }

        void Update()
        {
            // the following conditional statements are to make sure the enemies stay in a
            // reasonable area (between -25 and 25 on the x axis and -25 and 25 on z axis
            if (transform.position.x < -25)
            {
                velocity = new Vector3(Random.Range(0.0f, 1.0f), 0.0f, 0.0f);
            }
            if (transform.position.x > 25)
            {
                velocity = new Vector3(Random.Range(-1.0f, 0.0f), 0.0f, 0.0f);
            }
            if (transform.position.z < -25)
            {
                velocity = new Vector3(0.0f, 0.0f, Random.Range(0.0f, 1.0f));
            }
            if (transform.position.z > 25)
            {
                velocity = new Vector3(0.0f, 0.0f, Random.Range(-1.0f, 0.0f));
            }
            // move the enemies in the random direction at a constant speed
            transform.position += velocity * Time.deltaTime * speed;
        }

        void RandomRotateAndMove()
        {
            // get a random velocity vector
            velocity = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));
            // get a random rotation point along the y axis so the enemies rotate left and right
            transform.Rotate(0, Random.Range(-180.0f, 180.0f), 0.0f);
        }

        // This [Command] code is called on the Client …
        // … but it is run on the Server!
        [Command]
        void CmdShoot()
        {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

            // Spawn the bullet on the Clients
            NetworkServer.Spawn(bullet);

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);
        }
    }
}