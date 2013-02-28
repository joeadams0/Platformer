/* Justin Tout
 * Script handles play button behavior. Because the buttons do such different things, 
 * I scripted them individually to keep everything simple. 
 * */

using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour 
{
	public Color mar = new Color(.47F, .106F, .106F); //color on mouse over
	public Color gre = new Color(.118F, .251F, .07F); //color on start/mouse exit
	public AudioClip clip; //"Play" voice
	private Vector3 o = new Vector3(0,0,0); //for PlayClipAtPoint
	private bool played; //to keep from playing multiple times
	
	void Start()
	{
		renderer.material.color = Color.white; //start the buttons off green
	}
	
	void OnMouseEnter()
	{
		Debug.Log ("Over");
		renderer.material.color = mar; //change color
		//play clip if it hasn't already
		if (!played)
			AudioSource.PlayClipAtPoint (clip, o);
		played = true;
	}
	
	void OnMouseExit()
	{
		//reset everything
		renderer.material.color = Color.white;
		played = false;
	}
	
	void OnMouseDown()
	{
		//Load the next level when clicked. Currently, PlayerPrefs arent set, so it just leads to tut. 
		//it will lead to the next unlocked level once I have PlayerPrefs.
		Application.LoadLevel("Tutorial");
	}
}

