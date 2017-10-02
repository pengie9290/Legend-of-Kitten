using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
	public bool IsOpen = false;
	public List<string> NeededKeys;
	public string TriggerButton = "Fire1";
	private GameObject _thePlayer;
	public float TriggerRange = 1f;
	public Transform KeyLocation;
	public bool UseZCoordinate = false;
	public bool DestroyKeys = true;
	public List<string> KeysToDestroy;
	public List<string> KeysToPreserve;

	void Start () {
		_thePlayer = GameObject.FindGameObjectWithTag ("Player");
		if (KeyLocation == null)
		{
			KeyLocation = transform;
		}
		if (KeysToDestroy.Count < 1 && DestroyKeys == true)
		{
			KeysToDestroy = NeededKeys;
		}
	}
	
	void Update () {
		if (_thePlayer == null || IsOpen)
		{
			return;
		}
		if (Input.GetButton(TriggerButton))
		{
			if (HasNeededKeys())
			{
				if (IsInRange())
				{
					print(gameObject.name + " Is Open");
					IsOpen = true;
					OpenDoor();
					_destroyKeys();
				}
			}
		}		
	}

	public bool HasNeededKeys()
	{
		foreach (var Key in NeededKeys)
		{
			if (InventoryManager.IsPlayerCarrying(Key) == false)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsInRange()
	{
		var DoorPoint = KeyLocation.position;
		var PlayerPoint = _thePlayer.transform.position;
		if (!UseZCoordinate)
		{
			DoorPoint.z = 0;
			PlayerPoint.z = 0;
		}
		if (Vector3.Distance(DoorPoint, PlayerPoint) < TriggerRange)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void OpenDoor()
	{
		gameObject.SetActive(false);
		IsOpen = true;
	}

	private void _destroyKeys()
	{
		if (DestroyKeys == false)
		{
			return;
		}
		foreach (var Key in KeysToDestroy)
		{
			if (KeysToPreserve.Contains(Key) == false)
			{
				InventoryManager.DropObject(Key);
			}
		}
	}
}
