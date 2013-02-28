using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {
	GameObject[] highscores;
	GameObject[] levels;
	string text;
	public int totlevels; 
	
	void Start()
	{
		highscores = GameObject.FindGameObjectsWithTag("Best");
		for (int i = 0; i < totlevels; i++)
		{
			//if (Control.isUnlocked(i) == false)
				highscores[i].GetComponent<TextMesh>().text = "LOCKED";
			//else
			//highscores[i].GetComponent<TextMesh>().text = PlayerPrefs.getFloat("Level" + i + "Best");
		}
	}
}