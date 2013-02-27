/* Script controls the spotlight following the ball.
 * Justin Tout
 * */
using UnityEngine;
using System.Collections;

public class FollowBall : MonoBehaviour 
{
	public GameObject player; //drag object onto script to follow
	private Vector3 target;
	
// Rotate the camera every frame so it keeps looking at the target 
	void Update() 
		{
		target = player.transform.position;
	   	transform.LookAt(target);
		}
}

