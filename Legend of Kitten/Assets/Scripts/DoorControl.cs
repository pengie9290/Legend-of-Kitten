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
	private GameObject _audioManager;
	public float TriggerRange = 1f;
	public Transform KeyLocation;
	public bool UseZCoordinate = false;
	public bool DestroyKeys = true;
	public List<string> KeysToDestroy;
	public List<string> KeysToPreserve;
	public string ActivationMessage;
	public string DenialMessage;
	public bool NotifyUserOfDenial = true;
	public List<GameObject> ObjectsToActivate;
	public List<GameObject> ObjectsToDeactivate;
	public bool PlayDoorSFX = true;
	public bool PlayWineRackSFX = false;

	void ReportActivation()
	{
		var DefaultMessage = "Door Opens";
		if (PlayDoorSFX)
		{
			_audioManager.SendMessage("SayUnlock");
		}
		if (!PlayDoorSFX && PlayWineRackSFX)
		{
			_audioManager.SendMessage("SayWineRack");
		}
		if (ActivationMessage.Length < 1)
		{
			print(DefaultMessage);
			MessageDisplay.Show(DefaultMessage);
		}
		else
		{
			print(ActivationMessage);
			MessageDisplay.Show(ActivationMessage);
		}
	}
	
	void ReportDenial()
	{
		var DefaultMessage = "Door is Locked";
		if (PlayDoorSFX)
		{
			_audioManager.SendMessage("SayLocked");
		}
		if (!NotifyUserOfDenial)
		{
			return;
		}
		if (DenialMessage.Length < 1)
		{
			print(DefaultMessage);
			MessageDisplay.Show(DefaultMessage);
		}
		else
		{
			print(DenialMessage);
			MessageDisplay.Show(DenialMessage);
		}
	}
	
	void Start ()
	{
		_audioManager = GameObject.FindGameObjectWithTag("AudioManager");
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
			if (IsInRange())
			{
				if (HasNeededKeys())
				{
					print(gameObject.name + " Is Open");
					IsOpen = true;
					OpenDoor();
					_destroyKeys();
				}
				else
				{
					ReportDenial();
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

	void ApplyConsequences()
	{
		foreach (var obj in ObjectsToActivate)
		{
			obj.SetActive(true);
		}
		foreach (var obj in ObjectsToDeactivate)
		{
			obj.SetActive(false);
		}
	}
	
	public void OpenDoor()
	{
		gameObject.SetActive(false);
		IsOpen = true;
		ApplyConsequences();
		ReportActivation();
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
