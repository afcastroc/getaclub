using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using KartGame.UI;

public class LapDetector : MonoBehaviour
{
	[Header("Settings")]
	public int totalLaps = 0;
	public int currentLap = 0;
	public float timeToBackMenu = 0f;

	[Header("UI")]
	public TextMeshProUGUI finalText;

	//Verify if collide with player
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == GameConst.PLAYER_TAG)
		{
			if (other.GetComponentInParent<CalculeLap>().canFinishLap)
			{
				currentLap++;
				if (currentLap >= totalLaps)
				{
					FindObjectOfType<Mode>().CheckEndGame();
				}
				else other.GetComponentInParent<CalculeLap>().ResetToNewLap();
			}
		}
	}
}
