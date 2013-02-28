using UnityEngine;
using System.Collections;

public class LevelOver : MonoBehaviour {
	private Color mar = new Color(.47F, .106F, .106F);
	private Collider tut;
	private Collider level1;
	private Collider level2;
	
	void Start()
	{
		tut = GameObject.Find ("Tutorial").GetComponent<Collider>();
		level1 = GameObject.Find ("Level 1").GetComponent<Collider>();
		level2 = GameObject.Find ("Level 2").GetComponent<Collider>();
	}

	void OnMouseOver()
	{
		renderer.material.color = mar;
	}
	
	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
	
	void OnMouseDown()
	{
		if(collider == tut)
			Application.LoadLevel ("Tutorial");
		if(collider == level1)
			Application.LoadLevel ("Level 1");
		if(collider == level2)
			Application.LoadLevel ("Level 2");
	}
}
