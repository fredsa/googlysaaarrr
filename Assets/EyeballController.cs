using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballController : MonoBehaviour {

	void Update () {
		transform.LookAt(Camera.allCameras[0].transform);		
	}
	
}
