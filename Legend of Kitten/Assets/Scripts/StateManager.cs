using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
	{
		public List<String> States;
		public List<String> StartupStates;
		public static StateManager PlayerState;
	
	
		void Start ()
		{
			if (PlayerState != null)
			{
				print("WTS");
			}
			PlayerState = this;
			States.Clear();
			LoadStartupStates();
			ReportState();
		}
	
		void Update ()
		{
			if (Input.GetKeyUp(KeyCode.I))
			{
				ReportState();
			}
		}

		void LoadStartupStates()
		{
			foreach (string item in StartupStates)
			{
				States.Add(item.ToLower());
			}
		}

		public void SetState(string StateName)
		{
			States.Add(StateName.ToLower());
			ReportState();
		}

		public void ClearState(string StateName)
		{
			if (States.Contains(StateName.ToLower()))
			{
				States.Remove(StateName.ToLower());
				ReportState();
			}
			else
			{
				print("No Existing State: " + StateName);
			}
		}

		public string ReportState()
		{
			string TheMessage = "";
			foreach (string S in States)
			{
				if (TheMessage.Length > 0)
				{
					TheMessage += ", ";
				}
				TheMessage += S;
			}
			print("State: " + TheMessage);
			return TheMessage;
		}

		public bool CheckState(string StateName)
		{
			return States.Contains(StateName.ToLower());
		}

		public static bool CheckPlayerState(string StateName)
		{
			if (PlayerState == null)
			{
				return false;
			}
			return PlayerState.CheckState(StateName);
		}
		
	}
