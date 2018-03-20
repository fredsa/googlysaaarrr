using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnStart : MonoBehaviour {

	void Awake () {
		if (Application.isEditor) {
			return;
		}
		
		Destroy (gameObject);
	}
}