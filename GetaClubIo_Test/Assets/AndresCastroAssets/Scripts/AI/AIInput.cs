using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : BaseInput
{
	public float horizontalValue = 0f;
	public float verticalValue = 0f;

	public override Vector2 GenerateInput()
	{
		return new Vector2
		{
			x = horizontalValue,
			y = verticalValue
		};
	}
}
