using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour 
{
	RaycastHit hitInfo;
	
	void Update()
	{
		if( Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out hitInfo ) )
		{
    		Debug.Log( "mouse is over object " + hitInfo.collider.name );
		} 
	}
}