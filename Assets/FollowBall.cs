/* Script controls the spotlight following the ball.
 * Justin Tout
 * */
using UnityEngine;
using System.Collections;

public class FollowBall : MonoBehaviour 
{
	public Vector3 target; //drag object onto script to follow

// Rotate the camera every frame so it keeps looking at the target 
void Update() 
	{
			target = GameObject.FindGameObjectWithTag("Player").transform.position;
	   		transform.LookAt(target);
		}
		/* turns light off if not in play */
}