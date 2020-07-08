using KartGame.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AGameManager : MonoBehaviour
{
	public GameType gameType;

	[Header("TimerModeSettings")]
	public float gameTimer = 0f;

	[Header("SceneSettings")]
	public float timeToBackMenu = 0f;
	private LoadSceneButton exit;

	[Header("UISettings")]
	public TextMeshProUGUI gameResult;

	//Check Game type and Setup mode
	public void Start()
	{
		if (gameType == GameType.timer)
		{
			gameObject.AddComponent<TimerMode>();
			GetComponent<TimerMode>().SetupMode(gameTimer);
			FindObjectOfType<LapDetector>().totalLaps = 1;
		}
		exit = GetComponent<LoadSceneButton>();
	}

	//Show the end game result
	public void EndGame(bool success)
	{
		if (success) gameResult.text = GameConst.PLAYER_WIN;
		else gameResult.text = GameConst.PLAYER_LOSE;
		exit.SceneName = GameConst.MAIN_SCENE;
		gameResult.enabled = true;
		StartCoroutine(BackToMenu());
	}

	//Delay to go the main menu
	IEnumerator BackToMenu()
	{
		yield return new WaitForSeconds(timeToBackMenu);
		GetComponent<LoadSceneButton>().LoadTargetScene();
	}
}

//GameTypes
public enum GameType
{
	timer,
	vs
}
