using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerItem : MonoBehaviour
{
	[SerializeField] private float timerToAdd = 0f;

	//If collide with player add time
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == GameConst.PLAYER_TAG)
		{
			FindObjectOfType<TimerMode>().AddTime(timerToAdd);
			Destroy(gameObject);
		}
	}
}
