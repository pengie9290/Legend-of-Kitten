using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {
    
    public string Message;
	public List<Text> Displays;
    
	void Start ()
	{
		var TheControls = GetComponentsInChildren<Text>();
		foreach (var Control in TheControls)
		{
			Displays.Add(Control);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//"Massage" because cats like massages, or something. ...Just go with it.
	public void ShowMessage(string massage)
	{
		print(massage);
		if (Displays.Count < 1)
		{
			print("No Inventory Text Found");
		}
		else
		{
			Displays[0].text = massage;
		}
	}
}
