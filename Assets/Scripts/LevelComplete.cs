using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col){
		Debug.Log("Level Complete");
	}
}
