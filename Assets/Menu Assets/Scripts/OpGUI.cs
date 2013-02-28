using UnityEngine;
using System.Collections;

public class OpGUI : MonoBehaviour {
	
	void Start()
	{
		this.enabled = false;
	}

	void OnGUI  () 
	{
		GUI.Label (new Rect (10, 10, 100, 20), "Hello World!");
	}
}