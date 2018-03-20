using System.Collections;
using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;

public class GooglyManager : MonoBehaviour {

	public GameObject eyeballPrefab;

	void Update () {
		Touch touch;
		if (Input.touchCount < 1 || (touch = Input.GetTouch (0)).phase != TouchPhase.Began) {
			return;
		}

		// Ray cameraRay = Camera.allCameras[0].ScreenPointToRay (touch.position);
		// RaycastHit hitInfo;
		// if (Physics.Raycast (cameraRay, out hitInfo)) {
		// 	EyeballController controller = hitInfo.transform.gameObject.GetComponent<EyeballController> ();
		// 	if (controller != null) {
		// 		Anchor a = hitInfo.transform.parent.GetComponent<Anchor> ();
		// 		Destroy (a);
		// 		return;
		// 	}
		// }

		TrackableHit hitResult;
		if (!Frame.Raycast (touch.position.x, touch.position.y, TrackableHitFlags.FeaturePointWithSurfaceNormal, out hitResult)) {
			return;
		}

		Anchor anchor = hitResult.Trackable.CreateAnchor (hitResult.Pose);
		GameObject eyeball = GameObject.Instantiate (eyeballPrefab);

		eyeball.transform.SetParent(anchor.transform, false);
	}

}