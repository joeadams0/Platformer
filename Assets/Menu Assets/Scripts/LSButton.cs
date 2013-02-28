/* Justin Tout
 * Handles level-select button behavior. Scripted sepearately for simplicity.
 * */

using UnityEngine;
using System.Collections;

public class LSButton : MonoBehaviour 
{
	//Necessary fields
	public AudioClip clip;
	public Color mar = new Color(.47F, .106F, .106F);
	public Color gre = new Color(.118F, .251F, .07F);
	private Vector3 o = new Vector3(0,0,0);
	private bool played;
	
	void Start()
	{
		renderer.material.color = gre; //start the button green
	}
	
	void OnMouseOver()
	{
		renderer.material.color = mar; //change on mouseover
		//play clip once
		if (!played)
			AudioSource.PlayClipAtPoint (clip, o);
		played = true;
	}
	
	void OnMouseExit()
	{
		//reset values
		renderer.material.color = gre;
		played = false;
	}
	
	void OnMouseDown()
	{
		Application.LoadLevel("LevelSelect"); //go to the level selector when clicked
	}
}