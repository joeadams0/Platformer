using UnityEngine;
using System.Collections;

public class PositiveMagneticSphere : MagneticSphere {

	// Use this for initialization
	void Start () {
		charge = new Charge(Charge.POSITIVE, 5);
		State = STATES.SPHERICAL_FIELD;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
