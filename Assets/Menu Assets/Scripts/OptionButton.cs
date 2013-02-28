/* Justin Tout
 * Handles Option button behavior. Scripted seperately from each other button for simplicity.
 * */

using UnityEngine;
using System.Collections;

public class OptionButton : MonoBehaviour 
{
	//necessary fields 
	public Color mar = new Color(.47F, .106F, .106F);
	public Color gre = new Color(.118F, .251F, .07F);
	public AudioClip clip;
	public bool played;
	private Vector3 o = new Vector3(0,0,0);
	
	//fields for options GUI
	private bool optionsopen = false;
	public float bslider = 0.25f;
	public float vslider = 0.75f;
	public static bool music;
	
	void Start()
	{
		renderer.material.color = gre;
		music = true; //default to music
	}
	
	void Update()
	{
		RenderSettings.ambientLight = new Color(bslider, bslider, bslider, 1.0f);
	}
	
	void OnMouseOver()
	{
		renderer.material.color = mar;
		if (!played)
		AudioSource.PlayClipAtPoint (clip, o);
		played = true;
	}
	
	void OnMouseExit()
	{
		renderer.material.color = gre;
		played = false;
	}
	
	void OnMouseDown()
	{
		optionsopen = !optionsopen;
	}
	
	void OnGUI()
	{
		if (optionsopen)
		{
			GUI.Label (new Rect(0, 0, 100, 100), "Options");
			GUI.Label (new Rect(0,25,75,75),"Brightness");
			bslider = GUI.HorizontalSlider(new Rect(80, 25, 200, 20), bslider, 0.0f, 2.0f);
			GUI.Label (new Rect(0,50, 75, 75), "Volume");
			vslider = GUI.HorizontalSlider (new Rect(80, 50, 200, 20), vslider, 0.0f, 1.0f);
			if(GUI.Button (new Rect(0, 75, 50, 50), "Music"))
			{
				//PlayerPref to play music?
				music = !music;
				Debug.Log ("Music " + music);
			}
			if(GUI.Button(new Rect(0, 200, 50, 50), "Close"))
				optionsopen = !optionsopen;
		}
	}

}
//hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0.0F, 10.0F);