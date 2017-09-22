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
	private GameObject ThePlayer;

	void Start ()
	{
		InventoryManager.IsInInventory("ItemName");
		if (IsVisible == false) {
			//disable Mesh Renderer
		}
		ThePlayer = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void Update () {
		
	}

	public void OnCollisionEnter (Collision collision){
		if (ThePlayer != null && collision.gameObject == ThePlayer) {
			if (CanCarry == true) {
				ThePlayer.SendMessage ("PickUp", Name);
				IsCarried = true;
				CanCarry = false;
				print("PickedUp: " + InventoryManager.IsPlayerCarrying(Name));
			}
			if (PickupMessage.Length > 0) {
				ThePlayer.SendMessage ("Report", PickupMessage);
			}
			if (StateToSet.Length > 0) {
				ThePlayer.SendMessage ("SetState", StateToSet);
			}
			if (IsExpendable == true) {
				gameObject.SetActive (false);
			}
		}
	}
}
