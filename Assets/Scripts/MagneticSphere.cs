// Joe Adams
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagneticSphere : MonoBehaviour {
	
	// The charge for the sphere
	public Charge charge = new Charge(Charge.NEUTRAL, 5);
	
	// Hold game objects that are within their magnetic fields
	public HashSet<GameObject> FocusedFieldObjects;
	public HashSet<GameObject> SphericalFieldObjects;
	
	public Material negativeMaterial;
	public Material neutralMaterial;
	public Material positiveMaterial;
	
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
		FocusedFieldObjects = new HashSet<GameObject>();
		SphericalFieldObjects = new HashSet<GameObject>();
		Invoke("clearFocusedFieldObjects", 0.5F);
		GameObject capsule = transform.Find("Capsule").gameObject;
		capsule.AddComponent(typeof(TriggerParent));
		capsule.SendMessage("changeCollisionEnterFunction", "handleFocusedFieldEnter");
		capsule.SendMessage("changeCollisionExitFunction", "handleFocusedFieldExit");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
			if(magSphere.state == STATES.SPHERICAL_FIELD){
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
	void handleFocusedFieldEnter(Collider other){
		if(FocusedFieldObjects == null){
			return;
		}
		if(other.tag == "Magnet"){
			if(other.gameObject.GetComponent("MagneticSphere")){
				if(!(FocusedFieldObjects.Contains(other.gameObject))){
					FocusedFieldObjects.Add(other.gameObject);
				}
			}
		}
	}
	
	void handleFocusedFieldExit(Collider other){
		if(FocusedFieldObjects == null){
			return;
		}
		if(other.tag == "Magnet"){
			if(other.gameObject.GetComponent("MagneticSphere")){
				if(FocusedFieldObjects.Contains(other.gameObject)){
					FocusedFieldObjects.Remove(other.gameObject);
				}
			}
		}
	}

	// Sphere child collider, keep track of objects in field 
	public void handleSphereEnter(Collider other){
		if(other.gameObject.name == this.gameObject.name || SphericalFieldObjects == null){
			return;
		}
		if(other.tag == "Magnet"){
			if(other.gameObject.GetComponent(typeof(MagneticSphere))){
				if(!(FocusedFieldObjects.Contains(other.gameObject))){
					SphericalFieldObjects.Add(other.gameObject);
				}
			}
		}
	}
	
	public void handleSphereExit(Collider other){
		if(SphericalFieldObjects == null){
			return;
		}
		if(other.tag == "Magnet"){
			if(other.gameObject.GetComponent(typeof(MagneticSphere))){
				SphericalFieldObjects.Remove(other.gameObject);
			}
		}
	}
	
	public void setCharge(int cha){
		charge.Sign = cha;
		if(charge.Sign == Charge.NEGATIVE){
			gameObject.renderer.material = negativeMaterial;
		}
		else if(charge.Sign == Charge.NEUTRAL){
			gameObject.renderer.material = neutralMaterial;
		}
		else{
			gameObject.renderer.material = positiveMaterial;
		}
	}
	
	public void clearFocusedFieldObjects(){
		FocusedFieldObjects.Clear();
	}
	
	public void SwitchCharge(){
		if(charge.Sign == Charge.POSITIVE){
			this.setCharge(Charge.NEGATIVE);
		}
		else{
			setCharge(Charge.POSITIVE);
		}
	}
}
