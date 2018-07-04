using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace A04dkg3
{
    [RequireComponent(typeof(Collider))]
    public class MyMovingDestination : MonoBehaviour, IPointerClickHandler
    {
        // this script is attached to the terrain to tell the MyPlayerController script where to move the player
        // when the terrain is clicked
        
        [Tooltip("How long does the player need to get here")]
        public float RequiredMovingTime;

		private void Start()
		{
           
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            // create a ray to use to detect hitting the plane
            RaycastHit hit;
            // if the terrain was hit within 10 meters of the ray origin
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10))
            {
                // move to the position selected instantly
                MyPlayerController.Instance.MoveToPosition(hit.point, RequiredMovingTime);
            }
        }
	}
}
