using UnityEngine;
using System.Collections;

public class PositiveCharge : MagneticSphere {

	// Use this for initialization
	void Start () {
		charge = new Charge(Charge.POSITIVE, 5);
		State = STATES.SPHERICAL_FIELD;
	}
}
