using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public Vector3 launchVelocity;
	public bool inPlay = false;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 ballStartPos;
	private Quaternion ballStartRot;

	// Use this for initialization
	void Start () {
		ballStartPos = transform.position;
		ballStartRot = transform.rotation;
		rigidBody = GetComponent<Rigidbody>();

		rigidBody.useGravity = false;

		//Launch(launchVelocity);
		//TODO remove, this is launch for straight testing
		Launch(new Vector3 (0,0,25f));
	}

	public void Launch(Vector3 velocity) {
		inPlay = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
	}
	
	public void Reset() {
		//Debug.Log("Resetting ball");
		inPlay = false;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		transform.position = ballStartPos;
		transform.rotation = ballStartRot;
	}
}
