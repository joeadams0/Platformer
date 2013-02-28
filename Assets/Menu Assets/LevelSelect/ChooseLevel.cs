/* Justin Tout
 * Handles the selection of levels. */

using UnityEngine;
using System.Collections;

public class ChooseLevel : MonoBehaviour {
	
	//Necessary fields 
	private Color mar = new Color(.47F, .106F, .106F); //for scrollover
	private Collider next; //to move right
	private Collider last; //to move left 
	private GameObject main; //the camera
	public int totlevels;
	
	void Start()
	{
		//find everything on start
		next = GameObject.Find ("NEXT").GetComponent<Collider>();
		last = GameObject.Find("LAST").GetComponent<Collider>();
		main = GameObject.FindGameObjectWithTag ("MainCamera");
	}
		
	void OnMouseOver()
	{
		renderer.material.color = mar; //change color on mouseover 
	}
	
	void OnMouseExit()
	{
		renderer.material.color = Color.white; //change back when necessary
	}
	
	void OnMouseDown()
	{
		//Debug.Log ("Movin'");
		//move right if next is pressed. 
		if (collider == next && main.transform.position.x < (totlevels + 1) * 30) //to only show up to "coming soon" text
			main.transform.Translate(new Vector3(30,0,0));
		//move left is last is pressed and not at tutorial
		if (collider == last && main.transform.position.x > 0)
			main.transform.Translate(new Vector3(-30,0,0));
	}
}
			