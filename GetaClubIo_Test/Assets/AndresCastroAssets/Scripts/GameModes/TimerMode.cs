using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using KartGame.UI;

public class TimerMode : Mode
{
	[Header("GeneralSettings")]
	public float totalTimer = 0f;
	private float currentTime = 0f;

	[Header("UISettings")]
	public TextMeshProUGUI timerUI;

	private void Update()
	{
		CountDown();
	}

	//Configure Mode
	public void SetupMode(float _timer)
	{
		if (_timer == 0f) totalTimer = 60f;
		else totalTimer = _timer;
		if (timerUI == null) timerUI = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
		currentTime = totalTimer;
	}

	//Calcule the contdownTime
	private void CountDown()
	{
		currentTime -= Time.deltaTime;
		int _mins = Mathf.FloorToInt(currentTime / 60f);
		int _secs = Mathf.RoundToInt(currentTime % 60f);
		if(currentTime > 0f) ShowTimeUI(_mins, _secs);
		else GetComponent<AGameManager>().EndGame(false);
	}

	//Add time to current countdown from timerItem
	public void AddTime(float time)
	{
		currentTime += time;
	}

	//Show current countdown time in UI
	private void ShowTimeUI(int _mins, int _secs)
	{
		timerUI.text = _mins.ToString() + ":" + _secs.ToString();
	}

	//Verify if end of game
	public override void CheckEndGame()
	{
		GetComponent<AGameManager>().EndGame(true);
	}
}
