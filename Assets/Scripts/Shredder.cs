using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit (Collider col) {
		if(col.GetComponentInParent<Pin>()){
			//Debug.Log("Destroying " + col.name);
			Destroy(col.transform.parent.gameObject);
		}
	}
}
