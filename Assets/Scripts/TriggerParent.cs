// Joe Adams
using UnityEngine;
using System.Collections;

public class TriggerParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Pass them to the parent
	void OnTriggerEnter(Collider other){
		((MagneticSphere)transform.parent.GetComponent("MagneticSphere")).handleSphereEnter(other);
	}
	
	void OnTriggerExit(Collider other){
		((MagneticSphere)transform.parent.GetComponent("MagneticSphere")).handleSphereExit(other);
	}
	
}
