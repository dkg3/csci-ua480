using UnityEngine;
using System.Collections;

namespace A07dkg3
{
    public class Billboard : MonoBehaviour
    {
        void Update()
        {
            // keep the healthbar canvas looking at the camera at all times
            transform.LookAt(Camera.main.transform);
        }
    }
}