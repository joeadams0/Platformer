// Joe Adams
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagneticSphere : MonoBehaviour {
	
	// The charge for the sphere
	public Charge charge = new Charge(Charge.NEUTRAL, 5);
	
	// Hold game objects that are within their magnetic fields
	private HashSet<GameObject> FocusedFieldObjects = new HashSet<GameObject>();
	private HashSet<GameObject> SphericalFieldObjects = new HashSet<GameObject>();
	
	// States
	public enum STATES{
		NONE = 0,
		SPHERICAL_FIELD = 1,
		FOCUSED_FIELD = 2
	};
	
	// The state of the magnetic field
	public STATES State {
		get{
			return state;
		}
		set{
			state = value;
			if(state == STATES.SPHERICAL_FIELD){
				gameObject.particleSystem.Stop();
				gameObject.particleEmitter.emit = true;
			}
			else if(state == STATES.FOCUSED_FIELD){
				gameObject.particleEmitter.emit = false;
				gameObject.particleSystem.Play();
			}
			else{
				gameObject.particleEmitter.emit = false;
				gameObject.particleSystem.Stop();
			}
		}
	}
	private STATES state = STATES.NONE;
	
	// Use this for initialization
	void Start () {
		// Stop particle system and emitters
		gameObject.particleSystem.Stop();
		gameObject.particleEmitter.emit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(state == STATES.NONE){
			return;
		}
		// Find objects in range, act force on them
		HashSet<GameObject> magneticObjects = getMagneticObjects();
		if(magneticObjects == null){
			return;
		}
		foreach(GameObject obj in magneticObjects){
			MagneticSphere magSphere = (MagneticSphere)obj.GetComponent("MagneticSphere");
			if(magSphere.state != STATES.NONE){
				Vector3 force = charge.getForce(magSphere.charge, transform.position,  obj.transform.position);
				rigidbody.AddForce(force);
			}
		}
	}
	
	// Returns all magnetic objects
	private HashSet<GameObject> getMagneticObjects(){
		if(state == STATES.FOCUSED_FIELD){
			return FocusedFieldObjects;
		}
		else{
			return SphericalFieldObjects;
		}
	}
 
	// Box collider, keep track of objects in field 
	void OnTriggerEnter(Collider other){
		if(other.GetType() == typeof(SphereCollider)){
			if(other.gameObject.GetComponent("MagneticSphere")){
				if(!(FocusedFieldObjects.Contains(other.gameObject))){
					FocusedFieldObjects.Add(other.gameObject);
				}
			}
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.GetType() == typeof(SphereCollider)){
			if(other.gameObject.GetComponent("MagneticSphere")){
				if(FocusedFieldObjects.Contains(other.gameObject)){
					FocusedFieldObjects.Remove(other.gameObject);
				}
			}
		}
	}

	// Sphere child collider, keep track of objects in field 
	public void handleSphereEnter(Collider other){
		if(other.gameObject.name == this.gameObject.name){
			return;
		}
		if(other.name != "SphericalMagneticShell"){
			if(other.gameObject.GetComponent(typeof(MagneticSphere))){
				if(!(FocusedFieldObjects.Contains(other.gameObject))){
					SphericalFieldObjects.Add(other.gameObject);
				}
			}
		}
	}
	
	public void handleSphereExit(Collider other){
		if(other.name != "SphericalMagneticShell"){
			if(other.gameObject.GetComponent(typeof(MagneticSphere))){
				SphericalFieldObjects.Remove(other.gameObject);
			}
		}
	}
}
