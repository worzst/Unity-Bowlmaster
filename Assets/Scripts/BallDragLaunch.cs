using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}

	public void moveStart(float amount) {
		if (!ball.inPlay) {
			float yPos = ball.transform.position.y;
			float zPos = ball.transform.position.z;
			float xPos = Mathf.Clamp(ball.transform.position.x + amount, -.4f, .4f);
			ball.transform.position = new Vector3(xPos, yPos, zPos);
		}
	}

	public void DragStart() {
		if (!ball.inPlay) {
			// Capture time & position of drag start
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}

	public void DragEnd() {
		if (!ball.inPlay) {
			// Launch the ball
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;

			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
			launchVelocity = launchVelocity / 50;
			ball.Launch(launchVelocity);
			//Debug.Log(launchVelocity)
		}
	}
}
