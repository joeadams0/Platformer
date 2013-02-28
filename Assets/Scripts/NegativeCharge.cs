using UnityEngine;
using System.Collections;

public class NegativeCharge: MagneticSphere {
	
	// Use this for initialization
	void Start () {
		charge = new Charge(Charge.NEGATIVE, 4);
		State = STATES.SPHERICAL_FIELD;
	}
}
