using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpItem : Item
{
	public float jumpPower = 0f;

	//Check if collide with player and active the boost
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == GameConst.PLAYER_TAG)
		{
			Rigidbody kart = other.GetComponentInParent<Rigidbody>();
			kart.AddRelativeForce(new Vector3(0,jumpPower,0));
		}
	}
}
