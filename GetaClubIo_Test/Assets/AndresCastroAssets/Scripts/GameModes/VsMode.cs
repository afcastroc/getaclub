using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VsMode : Mode
{
	public CalculeLap aiKart;
	public CalculeLap player;

	public override void CheckEndGame()
	{
		if (player.lap > aiKart.lap) GetComponent<AGameManager>().EndGame(true);
		else if(player.lap < aiKart.lap) GetComponent<AGameManager>().EndGame(false);
	}
}
