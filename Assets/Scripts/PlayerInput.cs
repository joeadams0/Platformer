using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	
	// The magnet component
	MagneticSphere magnet;
	
	// Use this for initialization
	void Start () {
		magnet = (MagneticSphere) (gameObject.GetComponent("MagneticSphere"));
	}
	
	// Update is called once per frame
	void Update () {
		// Particle emmision
		if(Input.GetMouseButtonDown(0)){
			magnet.State = MagneticSphere.STATES.FOCUSED_FIELD;
		}
		else if(Input.GetMouseButtonDown(1)){
			magnet.State = MagneticSphere.STATES.SPHERICAL_FIELD;
		}
		
		if(Input.GetMouseButtonUp(0)){
			magnet.State = MagneticSphere.STATES.NONE;
		}
		if(Input.GetMouseButtonUp(1)){
			magnet.State = MagneticSphere.STATES.NONE;
		}
		
		// Transform ball to look at the mouse
		Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
		transform.LookAt(position);
	}
}
