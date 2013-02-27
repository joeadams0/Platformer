using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {
	GameObject[] highscores;
	string text;
	public int totlevels; 
	
	void Start()
	{
		highscores = GameObject.FindGameObjectsWithTag("Best");
		for (int i = 0; i < totlevels; i++)
		{
			//highscores[i].GetComponent<TextMesh>().text = PlayerPrefs.getFloat("Level" + i + "Best");
		}
	}
}