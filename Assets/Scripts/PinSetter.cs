using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public float distanceToRaise = 0.5f;
	public GameObject pinSet;

	private PinCounter pinCounter;
	private Animator animator;

	// Use this for initialization
	void Start () {
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public void RaisePins() {
		//raise standing pins only by distancetoraise
		//Debug.Log("Raising Pins");
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.RaiseIfStanding(distanceToRaise);
		}
	}

	public void LowerPins() {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Lower(distanceToRaise);
		}
	}

	public void RenewPins() {
		//Debug.Log("Renewing Pins");
		GameObject pins = Instantiate(pinSet, new Vector3(0, distanceToRaise, 18.29f), Quaternion.identity) as GameObject;
		foreach (Transform child in pins.transform) {
			child.GetComponent<Rigidbody>().useGravity = false;
		}
		//pins.GetComponentInChildren<Rigidbody>().useGravity = false;
	}

	public void PerformAction(ActionMaster.Action action) {
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger("tidyTrigger");
		} else if (action == ActionMaster.Action.Reset || action == ActionMaster.Action.EndTurn) {
			pinCounter.Reset();
			animator.SetTrigger("resetTrigger");
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Don't know how to handle Endgame yet");
		} 
	}
}
