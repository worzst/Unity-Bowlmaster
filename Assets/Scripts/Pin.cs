using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3f;
	//public float distToRaise = 0.5f;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		//print (name + IsStanding());
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//print (name + IsStanding());
	}

	public bool IsStanding() {
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(rotationInEuler.x);
		float tiltInZ = Mathf.Abs(rotationInEuler.z);

		if((tiltInX < standingThreshold || tiltInX > 360f - standingThreshold) && (tiltInZ < standingThreshold || tiltInZ > 360f - standingThreshold)) {
			return true;
		} else {
			return false;
		}
	}

	public void RaiseIfStanding(float distToRaise) {
		//raise standing pins only by distancetoraise
		//Debug.Log("Raising Pins");
		if (IsStanding()) {
			rigidBody.useGravity = false;
			transform.Translate (new Vector3(0, distToRaise,0), Space.World);
			transform.rotation = Quaternion.identity;
		}
	}

	public void Lower(float distToRaise) {
		//Debug.Log("Lowering Pins");
		transform.Translate (new Vector3(0, -distToRaise,0), Space.World);
		rigidBody.useGravity = true;
	}
}
