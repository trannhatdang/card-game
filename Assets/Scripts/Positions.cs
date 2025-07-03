using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public enum Positions
{
	UP,
	DOWN,
	LEFT,
	RIGHT,
	DECK,
	DISCARD
}

public class StaticPositions : MonoBehaviour
{
	[SerializeField] public static StaticPositions Instance;
	[SerializeField] List<Vector3> _pos;
	void Awake()
	{
		if(Instance != null)
		{
			Destroy(this.gameObject);
		}
		Instance = this;

		DontDestroyOnLoad(this.gameObject);
	}

	public Vector3 GetPosition(Positions input)
	{
		return _pos[(int)input];
	}

}
