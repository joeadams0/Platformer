using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	GameObject[] levels;
	string text;
	public int totlevels; 
	
	void Start()
	{
		levels = GameObject.FindGameObjectsWithTag("Level");
		for (int i = 0; i < totlevels; i++)
		{
			levels[i].GetComponent<TextMesh>().text = levels[i].GetComponent<TextMesh>().text + "\n" + "\tBest: "; //+PlayerPrefs.getFloat("Level" + i + "Best")
		}
	}
}