using UnityEngine;
using UnityEngine.Networking;

namespace A07dkg3
{
    public class PlayerController : NetworkBehaviour
    {
        // declare variables to be used to create and spawn bullets
        public GameObject bulletPrefab;
        public Transform bulletSpawn;

		void Update()
        {
            // check to make sure the player is local
            if (!isLocalPlayer)
            {
                return;
            }

            // position the camera just above the first person player
            Camera.main.transform.parent.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            // allow the player to rotate left and right based on head movement
            transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
            // have the player moving forward at a constant slow speed so all they have to worry about is shooting
            transform.position += transform.forward * 2f * Time.deltaTime;

            // fire the bullet when the trigger is pressed
            if (Input.GetMouseButtonDown(0))
            {
                CmdFire();
            }
        }

        // This [Command] code is called on the Client …
        // … but it is run on the Server!
        [Command]
        void CmdFire()
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

        public override void OnStartLocalPlayer()
        {
            // position the camera just above the first person player
            Camera.main.transform.parent.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            // allow the player to rotate left and right based on head movement
            transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
            // make the local player blue
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}