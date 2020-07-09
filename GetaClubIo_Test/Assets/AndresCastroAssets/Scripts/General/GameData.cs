
[System.Serializable]
public class GameData
{
    public GameType gameType { get; set; }
	public GameDificult dificulty { get; set; }
	public float topSpeed { get; set; }
	public float acceleration { get; set; }
	public float accelerationCurve { get; set; }
	public float braking { get; set; }
	public float steer { get; set; }
}
