using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballController : MonoBehaviour {

	void Update () {
		transform.LookAt (Camera.allCameras[0].transform);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.GetComponent<EyeballController> () != null) {
			Destroy (other.gameObject);
		}
	}

}