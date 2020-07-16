using KartGame.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class GetDataGame : MonoBehaviour
{
	[Header("Difficult")]
	public GameDificulty dificult;

	[Header("PlayerSettings")]
	public float topSpeed = 0f;
	public float acceleration = 0f;
	[Range(0, 1f)]
	public float accelerationCurve = 0f;
	public float braking = 0f;
	public float steer = 0f;

	//Setup timer game mode
	public void ContructTimerGame ()
	{
		GameData data = new GameData();
		data.gameType = GameType.timer;
		data.dificulty = dificult;
		data = SetKartsData(data);
		string dataToSave = JsonConvert.SerializeObject(data);
		SaveGameData(dataToSave);
		GetComponent<LoadSceneButton>().LoadTargetScene();
	}

	//Setup Vs game mode
	public void ContructVsGame()
	{
		GameData data = new GameData();
		data.gameType = GameType.vs;
		data.dificulty = dificult;
		data = SetKartsData(data);
		string dataToSave = JsonConvert.SerializeObject(data);
		SaveGameData(dataToSave);
		GetComponent<LoadSceneButton>().LoadTargetScene();
	}

	//Setup Items game mode
	public void ContructItemsGame()
	{
		GameData data = new GameData();
		data.gameType = GameType.Items;
		data = SetKartsData(data);
		string dataToSave = JsonConvert.SerializeObject(data);
		SaveGameData(dataToSave);
		GetComponent<LoadSceneButton>().LoadTargetScene();
	}

	/*Set kart data for setup in game
	 * @parm: Data saved by previous scene
	 * @return: void
	 */
	private GameData SetKartsData(GameData data)
	{
		data.topSpeed = topSpeed;
		data.acceleration = acceleration;
		data.accelerationCurve = accelerationCurve;
		data.braking = braking;
		data.steer = steer;
		return data;
	}

	/*Save gameConfig to Load by next scene
	 * @parm: json string value to save
	 * @return: void
	 */
	private void SaveGameData(string json)
	{
		PlayerPrefs.SetString(GameConst.GAME_DATA_KEY, json);
	}
}
