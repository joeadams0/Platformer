// Joe Adams
using UnityEngine;
using System.Collections;

public class MasterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {		
		// Set positive charge to positive
		MagneticSphere pos = GameObject.Find("Player").GetComponent(typeof(MagneticSphere)) as MagneticSphere;
		pos.charge.Sign = Charge.POSITIVE;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
