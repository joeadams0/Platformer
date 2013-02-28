// Joe Adams
using UnityEngine;
using System.Collections;

public class TriggerParent : MonoBehaviour {
	public string collisionEnterFunction = "handleSphereEnter";
	public string collisionExitFunction = "handleSphereExit";
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Pass them to the parent
	void OnTriggerEnter(Collider other){
		transform.parent.SendMessage(collisionEnterFunction, other);
	}
	
	void OnTriggerExit(Collider other){
		transform.parent.SendMessage(collisionExitFunction, other);
	}
	
	public void changeCollisionEnterFunction(string newName){
		collisionEnterFunction = newName;
	}
	
	public void changeCollisionExitFunction(string newName){
		collisionExitFunction = newName;
	}
}
