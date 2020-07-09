using KartGame.KartSystems;
using KartGame.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AGameManager : MonoBehaviour
{
	public GameType gameType;

	[Header("PlayerSettings")]
	public float topSpeed = 0f;
	public float acceleration = 0f;
	[Range(0, 1f)]
	public float accelerationCurve = 0f;
	public float braking = 0f;
	public float steer = 0f;

	[Header("TimerModeSettings")]
	public float gameTimer = 0f;
	public Transform timerItems;

	[Header("VsModeSettings")]
	public GameDificulty dificulty;
	public Transform playerKart;
	public Transform kart_AI;

	[Header("ItemsMode")]
	public float gameItemsTimer = 0f;
	public Transform boostItems;
	public Transform loseControlItems;
	public Transform jumpItems;

	[Header("SceneSettings")]
	public float timeToBackMenu = 0f;
	private LoadSceneButton exit;

	[Header("UISettings")]
	public TextMeshProUGUI gameResult;
	public TextMeshProUGUI timerUI;

	//Check Game type and Setup mode
	public void Start()
	{
		SetupPlayer();
		if (gameType == GameType.timer) SetupTimerMode();
		else if (gameType == GameType.vs) SetupVsMode();
		else if (gameType == GameType.Items) SetupItemMode();
		exit = GetComponent<LoadSceneButton>();
	}

	//Set values to Player
	public void SetupPlayer()
	{
		ArcadeKart kart = playerKart.GetComponent<ArcadeKart>();
		kart.baseStats.TopSpeed = topSpeed;
		kart.baseStats.Acceleration = acceleration;
		kart.baseStats.AccelerationCurve = accelerationCurve;
		kart.baseStats.Braking = braking;
		kart.baseStats.Steer = steer;
	}

	//Setup Timer game mode
	public void SetupTimerMode()
	{
		TimerMode mode = gameObject.AddComponent<TimerMode>();
		mode.timerUI = timerUI;
		mode.SetupMode(gameTimer);

		FindObjectOfType<LapDetector>().totalLaps = 1;
		timerItems.gameObject.SetActive(true);
		timerUI.gameObject.SetActive(true);
	}

	//Setup Vs game mode
	public void SetupVsMode()
	{
		kart_AI.gameObject.SetActive(true);
		kart_AI.GetComponent<AI_Kart>().SetupAIKart();
		kart_AI.GetComponent<AI_Kart>().dificulty = dificulty;
		kart_AI.GetComponent<AI_Kart>().SetupDifficult();

		VsMode mode = gameObject.AddComponent<VsMode>();
		mode.player = playerKart.GetComponent<CalculeLap>();
		mode.aiKart = kart_AI.GetComponent<CalculeLap>();

		boostItems.gameObject.SetActive(true);
	}

	//Setup Item mode
	public void SetupItemMode()
	{
		TimerMode mode = gameObject.AddComponent<TimerMode>();
		mode.timerUI = timerUI;
		mode.SetupMode(gameItemsTimer);

		FindObjectOfType<LapDetector>().totalLaps = 1;

		timerUI.gameObject.SetActive(true);

		boostItems.gameObject.SetActive(true);
		loseControlItems.gameObject.SetActive(true);
		jumpItems.gameObject.SetActive(true);
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
	vs,
	Items
}

public enum GameDificulty
{
	easy,
	normal,
	hard
}
