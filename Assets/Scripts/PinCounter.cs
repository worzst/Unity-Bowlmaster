using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
	public Text standingPinDisplay;

	private GameManager gameManager;
	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private int lastSettledCount = 10;
	private float lastChangeTime;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		standingPinDisplay.text = CountStanding().ToString();

		if (ballOutOfPlay) {
			standingPinDisplay.color = Color.red;
			UpdateStandingCountAndSettle();
		}
	}

	void UpdateStandingCountAndSettle() {
		// Update the lastStandingCount
		// Call PinsHaveSettled() when they have

		int currentStanding = CountStanding();
		if (lastStandingCount != currentStanding) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f; // How long to wait to consider pins settled
		if ((Time.time - lastChangeTime) > settleTime) {
			PinsHaveSettled();
		}
	}

	void PinsHaveSettled() {
		int standing = CountStanding();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		gameManager.Bowl(pinFall);

		lastStandingCount = -1; // Indicates pins have settled
		ballOutOfPlay = false;
		standingPinDisplay.color = Color.green;
	}

	public int CountStanding() {
		int standingPins = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding()) {
				standingPins++;
			}
		}
		return standingPins;
	}

	public void Reset () {
		lastSettledCount = 10;
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.GetComponent<Ball>()) {
			ballOutOfPlay = true;
		}
	}
}
