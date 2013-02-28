using UnityEngine;
using System.Collections;

public class ChooseLevel : MonoBehaviour {
	
	private Color mar = new Color(.47F, .106F, .106F);
	private Collider next;
	private Collider last;
	private GameObject main;
	
	void Start()
	{
		next = GameObject.Find ("NEXT").GetComponent<Collider>();
		last = GameObject.Find("LAST").GetComponent<Collider>();
		main = GameObject.FindGameObjectWithTag ("MainCamera");
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
		Debug.Log ("Movin'");
		if (collider == next) //&& main.transform.position.x <= LevelSelector.totlevels - 1 * 30)
			main.transform.Translate(new Vector3(30,0,0));
		if (collider == last)// && main.transform.position.x >= 5)
			main.transform.Translate(new Vector3(-30,0,0));
	}
}
			