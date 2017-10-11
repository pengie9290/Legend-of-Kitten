using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour {
    
	public string Message;
	public List<Text> Displays;
	public static MessageDisplay TheMessageDisplay = null;
	public float FadeDelay = 2;
	public float FadeCountdown = 0;
	public List<string> TheMessageQueue = new List<string>();
    
	void Start ()
	{
		FadeCountdown = FadeDelay;
		if (TheMessageDisplay == null)
		{
			TheMessageDisplay = this; 
		}
		var TheControls = GetComponentsInChildren<Text>();
		foreach (var Control in TheControls)
		{
			Displays.Add(Control);
		}
	}
	
	void Update () {
		if (FadeCountdown > 0)
		{
			FadeCountdown -= Time.deltaTime;
			if (FadeCountdown <= 0)
			{
				FadeCountdown = 0;
				SetVisibility(false);
			}
		}
	}

	public static void Show(string TheMessage)
	{
		if (TheMessageDisplay != null)
		{
			TheMessageDisplay.ShowMessage(TheMessage);
		}
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
			SetVisibility(true);
		}
	}

	public void SetVisibility(bool visible)
	{
		for (int x = 0; x < transform.childCount; x++)
		{
			var Child = transform.GetChild(x);
			if (Child != null)
			{
				Child.gameObject.SetActive(visible);
			}
		}
		if (visible)
		{
			FadeCountdown = FadeDelay;
		}
	}
}