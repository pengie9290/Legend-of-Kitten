using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RandomPlacement : MonoBehaviour
{
	public List<Transform> Locations;

	void Start()
	{
		if (Locations != null)
		{
			var Count = Locations.Count;
			switch (Count)
			{
				case 0: break;
				case 1: transform.position = Locations[0].position;
					break;
				default: RandomlyPlace();
					break;
			}
		}
	}
	
	void RandomlyPlace ()
	{
		var Count = Locations.Count;
		int Index = Random.Range(0, Count - 1);
		print(Index);
		transform.position = Locations[Index].position;
	}
}
