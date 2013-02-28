using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
	public GameObject mainCamera;
	public GameObject player;
	// Use this for initialization
	void Start () {
	}
	
	
	// Update is called once per frame
	void Update () {
		if(player != null){
			Vector3 pos = mainCamera.transform.position;
			pos.x = player.transform.position.x;
			pos.y = player.transform.position.y;
			mainCamera.transform.position = pos;
		}
	}
	
	public void startCamera(GameObject obj){
		player = obj;
	}
}
