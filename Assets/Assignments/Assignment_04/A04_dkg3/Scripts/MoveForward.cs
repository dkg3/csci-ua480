using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A04dkg3
{
    public class MoveForward : MonoBehaviour
    {
        // this script is attached to the player to move them throughout the scene

        // create a speed and current speed variable used for acceleration and deceleration
        public float speed;
        private float current_speed = 0.0f;
        // create a ray to use to detect hitting the plane
        RaycastHit hit;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            // check if the trigger is pressed and if the ray is not striking the terrain within 10 meters
            if (Input.GetMouseButton(0) && !(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10)))
            {
                if (current_speed < 20.0f)
                {
                    // accererate to speed of 20
                    current_speed = current_speed + (.01f * speed);
                    Vector3 forward = Camera.main.transform.forward;
                    forward.y = 0;
                    transform.Translate(forward * current_speed * Time.deltaTime);
                }
                else
                {
                    // move at a constant speed of 20
                    Vector3 forward = Camera.main.transform.forward;
                    forward.y = 0;
                    transform.Translate(forward * speed * Time.deltaTime);
                }

            }
            // the trigger is no longer being pushed
            else if (!(Input.GetMouseButton(0)))
            {
                // decelerate to speed of 0
                if (current_speed > 0.0f)
                {
                    current_speed = current_speed - (.01f * speed);
                    Vector3 forward = Camera.main.transform.forward;
                    forward.y = 0;
                    transform.Translate(forward * current_speed * Time.deltaTime);
                }
                // stay still once speed is 0
                else
                {
                    current_speed = 0.0f;
                    Vector3 forward = Camera.main.transform.forward;
                    forward.y = 0;
                    transform.Translate(forward * current_speed * Time.deltaTime);
                }
            }
        }
    }
}