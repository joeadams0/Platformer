// Joe Adams
using UnityEngine;
using System.Collections;

public class Charge{
	public static int POSITIVE = 1;
	public static int NEGATIVE = -1;
	public static int NEUTRAL = 0;
	
	public int Sign;
	public int Strength;
	
	// Create a neutral charge
	public Charge(){
		Sign = NEUTRAL;
		Strength = 1;
	}
	
	public Charge(int sign, int strength){
		Sign = sign;
		Strength = strength;
	}
	
	public Vector3 getForce(Charge charge, Vector3 pos1, Vector3 pos2){
		Vector3 force = charge.Sign*charge.Strength*Strength*Sign*(pos1-pos2)/(Mathf.Pow ((pos1-pos2).magnitude, 2));
		return force;
	}
}
