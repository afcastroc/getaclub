using KartGame.KartSystems;
using UnityEngine;

public class AIInput : BaseInput
{
	public float horizontalValue = 0f;
	public float verticalValue = 0f;

	/*Register the horizontal and vertical values by AI_Kart (AssignInputsToIA)
	 * @return: Vector2 with Ai inputs generated
	 */
	public override Vector2 GenerateInput()
	{
		return new Vector2
		{
			x = horizontalValue,
			y = verticalValue
		};
	}
}
