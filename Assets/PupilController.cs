using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupilController : MonoBehaviour {

	Quaternion destRotation;

	void Start() {
		StartCoroutine(ChangeDestRotation());
	}

	IEnumerator ChangeDestRotation () {
		while (true) {
			float destAngle1 = Random.Range (2f, 6f);
			float destAngle2 = Random.Range (0, 360f);
			destRotation = Quaternion.Euler (0f, 0f, destAngle2) * Quaternion.Euler (destAngle1, 0f, 0f);
			yield return new WaitForSeconds (Random.Range (.2f, .8f));
		}
	}

	void Update () {
		transform.localRotation = Quaternion.Lerp (transform.localRotation, destRotation, Time.deltaTime * 10f);
	}
}