﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

namespace A07dkg3
{
    public class Health : NetworkBehaviour
    {
        // start the characters with a health of 100
        public const int maxHealth = 100;
        public bool destroyOnDeath;

        [SyncVar(hook = "OnChangeHealth")]
        public int currentHealth = maxHealth;

        public RectTransform healthBar;

        private NetworkStartPosition[] spawnPoints;

        void Start()
        {
            if (isLocalPlayer)
            {
                spawnPoints = FindObjectsOfType<NetworkStartPosition>();
            }
        }

        public void TakeDamage(int amount)
        {
            if (!isServer)
                return;
            // take away 10 points of health for every hit
            // and destroy the game object if their health runs out
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                if (destroyOnDeath)
                {
                    Destroy(gameObject);
                }
                else
                {
                    currentHealth = maxHealth;

                    // called on the Server, invoked on the Clients
                    RpcRespawn();
                }
            }
        }

        void OnChangeHealth(int currentHealth)
        {
            // change the healthbar after each hit
            healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
        }

        [ClientRpc]
        void RpcRespawn()
        {
            if (isLocalPlayer)
            {
                // Set the spawn point to origin as a default value
                Vector3 spawnPoint = Vector3.zero;

                // If there is a spawn point array and the array is not empty, pick one at random
                if (spawnPoints != null && spawnPoints.Length > 0)
                {
                    spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
                }

                // Set the player’s position to the chosen spawn point
                transform.position = spawnPoint;
            }
        }
    }
}