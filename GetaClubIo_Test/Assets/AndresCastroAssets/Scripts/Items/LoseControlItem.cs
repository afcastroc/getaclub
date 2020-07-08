using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseControlItem : Item
{
	//Check if collide with player and active the lose control
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == GameConst.PLAYER_TAG)
		{
			ArcadeKart kart = other.GetComponentInParent<ArcadeKart>();
			kart.enabled = false;
			StartCoroutine(EffectDuration(kart));
		}
	}

	//Duration of the effect
	IEnumerator EffectDuration(ArcadeKart kart)
	{
		yield return new WaitForSeconds(durationTime);
		kart.enabled = true;
	}
}
