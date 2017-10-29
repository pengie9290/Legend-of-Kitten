using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour {
	public string Name = "";
	public string PickupMessage = "";
	public bool IsVisible = true;
	public bool IsEnabled = true;
	public bool CanCarry = true;
	public bool IsCarried = false;
	public bool IsExpendable = true;
	public string StateToSet = "";
	private GameObject _thePlayer;
	public bool IsAKey = true;
	private GameObject _audioManager;

	void Start ()
	{
		InventoryManager.IsInInventory("ItemName");
		if (IsVisible == false) {
			//disable Mesh Renderer
		}
		_thePlayer = GameObject.FindGameObjectWithTag ("Player");
		_audioManager = GameObject.FindGameObjectWithTag("AudioManager");
	}
	
	void Update () {
		
	}

	public void OnCollisionEnter (Collision collision){
		if (_thePlayer != null && collision.gameObject == _thePlayer) {
			if (CanCarry == true) {
				_thePlayer.SendMessage ("PickUp", Name);
				IsCarried = true;
				CanCarry = false;
				print("PickedUp: " + InventoryManager.IsPlayerCarrying(Name));
				if (IsAKey)
				{
					_audioManager.SendMessage("SayGetKey");
				}
			}
			if (PickupMessage.Length > 0) {
				_thePlayer.SendMessage ("Report", PickupMessage);
			}
			if (StateToSet.Length > 0) {
				_thePlayer.SendMessage ("SetState", StateToSet);
			}
			if (IsExpendable == true) {
				gameObject.SetActive (false);
			}
		}
	}
}
