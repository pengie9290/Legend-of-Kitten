using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
	public static void ChangeAlpha(this Material mat, float alpha)
	{
		Color theColor = mat.color;
		Color newColor = new Color(theColor.r, theColor.g, theColor.b, alpha);
		mat.SetColor("_Color", newColor);
	}
}

public class CatsEyeControl : MonoBehaviour
{
	private Renderer _render;
	private GameObject _thePlayer;
	public float Transparency = .5f;
	
	void Start () {
		_render = GetComponent<Renderer> ();
		_thePlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == _thePlayer)
		{
			if (_render != null)
			{
				_render.material.ChangeAlpha(Transparency);
			}
		}
	}
	
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == _thePlayer)
		{
			if (_render != null)
			{
				_render.material.ChangeAlpha(1f);
			}
		}
	}
}
