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
		Debug.Log ("---------------------------");
		Debug.Log ("touch=" + touch);

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
			Debug.Log ("Frame.Raycast() -> none");
			return;
		}
		Debug.Log ("hitResult=" + hitResult);
		Debug.Log ("hitResult.Pose=" + hitResult.Pose);
		Debug.Log ("hitResult.Trackable=" + hitResult.Trackable);

		Anchor anchor = hitResult.Trackable.CreateAnchor (hitResult.Pose);
		Debug.Log ("anchor=" + anchor);
		Debug.Log ("anchor.transform=" + anchor.transform);
		GameObject eyeball = GameObject.Instantiate (eyeballPrefab);
		Debug.Log ("eyeball=" + eyeball);

		eyeball.transform.SetParent(anchor.transform, false);
	}

}