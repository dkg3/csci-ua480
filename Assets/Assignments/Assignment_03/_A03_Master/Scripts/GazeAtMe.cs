using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03Examples
{
   
    public class GazeAtMe : MonoBehaviour
    {
        Rigidbody myRb;
        public Color selectColor = Color.red;
        public float popTime = 2.0f;

        Color initialColor;
        float counter = 0;
        MeshRenderer meshRenderer;
        IEnumerator coroutine;

        void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            initialColor = meshRenderer.material.color;
            myRb = GetComponent<Rigidbody>();

        }

        public void GazeAndPop()
        {
            coroutine = Gaze();
            StartCoroutine(coroutine);
        }

		
		IEnumerator Gaze(){
            counter = 0;
            while (counter < popTime)
            {
                Debug.Log("hi");
                counter += Time.deltaTime;
                meshRenderer.material.color = Color.Lerp(initialColor, selectColor, counter / 1f);
                yield return null;
            }
            myRb.AddForce(Vector3.up * 300 + Random.insideUnitSphere * .25f);
            myRb.AddTorque(Random.insideUnitSphere * 10);
            Reset();
        }

		public void Reset()
		{
            StopCoroutine(coroutine);
            meshRenderer.material.color = initialColor;
            counter = 0;
		}
	}
}
