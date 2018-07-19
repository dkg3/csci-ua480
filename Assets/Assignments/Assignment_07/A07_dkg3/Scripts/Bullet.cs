using UnityEngine;
using System.Collections;

namespace A07dkg3
{
    public class Bullet : MonoBehaviour
    {
        // detect bullet collision with the enemies or players and
        // remove 10 points of health if an enemy or player gets hit
        void OnCollisionEnter(Collision collision)
        {
            var hit = collision.gameObject;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(10);
            }
            // destroy the bullet after a collision
            Destroy(gameObject);
        }
    }
}