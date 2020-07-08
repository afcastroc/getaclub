using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGameManager : MonoBehaviour
{
	public GameType gameType;

	public void Start()
	{
		if (gameType == GameType.timer)
		{

		}
	}
}

public enum GameType
{
	timer,
	vs
}
