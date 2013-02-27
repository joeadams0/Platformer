// Joe Adams
using UnityEngine;
using System.Collections;

public class MasterScript : MonoBehaviour {
	
	public string playerFile = "Player";
	GameObject player;
	// Use this for initialization
	void Start () {		
		if(player == null){
			player = (GameObject)Instantiate(Resources.Load(playerFile));
			MagneticSphere sph = (MagneticSphere)player.GetComponent(typeof(MagneticSphere));
			sph.setCharge(Charge.POSITIVE);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
