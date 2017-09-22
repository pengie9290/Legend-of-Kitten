using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
	{
		public List<String> Items;
		public List<String> StartupItems;
		public static List<InventoryObject> MasterInventoryObjects = new List<InventoryObject>();
		public static InventoryManager PlayerInventory;
	
	
		void Start ()
		{
			if (PlayerInventory != null)
			{
				print("WTI");
			}
			PlayerInventory = this;
			Items.Clear();
			LoadStartupItems();
			ReportInventory();
		}
	
		void Update ()
		{
			if (Input.GetKeyUp(KeyCode.I))
			{
				ReportInventory();
			}
		}

		void LoadStartupItems()
		{
			foreach (string item in StartupItems)
			{
				Items.Add(item.ToLower());
			}
		}

		public void PickUp(string ItemName)
		{
			Items.Add(ItemName.ToLower());
			ReportInventory();
		}

		public void Drop(string ItemName)
		{
			Items.Remove(ItemName.ToLower());
			ReportInventory();
		}

		public string ReportInventory()
		{
			string TheMessage = "";
			foreach (string S in Items)
			{
				if (TheMessage.Length > 0)
				{
					TheMessage += ", ";
				}
				TheMessage += S;
			}
			print("Inventory: " + TheMessage);
			return TheMessage;
		}

		public bool IsCarrying(string ItemName)
		{
			return Items.Contains(ItemName.ToLower());
		}

		public static bool IsInInventory(string ItemName)
		{
			foreach (var Item in MasterInventoryObjects)
			{
				if (Item.Name == ItemName.ToLower())
				{
					return true;
				}
			}
			return false;
		}

		public static void RegisterInventoryObject(InventoryObject theobject)
		{
			MasterInventoryObjects.Add(theobject);
		}

		public static bool IsPlayerCarrying(string ItemName)
		{
			if (PlayerInventory == null)
			{
				return false;
			}
			return PlayerInventory.IsCarrying(ItemName);
		}
		
	}
