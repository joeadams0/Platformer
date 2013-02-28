using UnityEngine;
using System.Collections;

public class OptionButton : MonoBehaviour 
{
	private Color mar = new Color(.47F, .106F, .106F);
	private Color gre = new Color(.118F, .251F, .07F);
	private bool optionsopen = false;
	private float bslider = 0.25f;
	private float vslider = 0.75f;
//	private bool music = true;
	
	void Start()
	{
		renderer.material.color = gre;
	}
	
	void Update()
	{
		RenderSettings.ambientLight = new Color(bslider, bslider, bslider, 1.0f);
	}
	
	void OnMouseOver()
	{
		renderer.material.color = mar;
		//play sound
	}
	
	void OnMouseExit()
	{
		renderer.material.color = gre;
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
			if(GUI.Button(new Rect(0, 200, 50, 50), "Close"))
				optionsopen = !optionsopen;
		}
	}

}
//hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0.0F, 10.0F);