using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip LockedClip;
	public AudioClip GetKeyClip;
	public AudioClip UnlockClip;
	public AudioClip WineRackClip;
	private AudioSource _lockedSource;
	private AudioSource _getKeySource;
	private AudioSource _unlockSource;
	private AudioSource _wineRackSource;

	AudioSource MakeSource (AudioClip Clip, bool PlayOnWake = false, bool Loop = false){
		AudioSource NewSource = gameObject.AddComponent <AudioSource> ();
		if (Clip != null) {
			NewSource.clip = Clip;
			NewSource.playOnAwake = PlayOnWake;
			NewSource.loop = Loop;
			NewSource.rolloffMode = AudioRolloffMode.Linear;
		}
		return NewSource;
	}
	
	void Awake (){
		_lockedSource = MakeSource (LockedClip);
		_getKeySource = MakeSource (GetKeyClip);
		_unlockSource = MakeSource (UnlockClip);
		_wineRackSource = MakeSource(WineRackClip);
	}

	public void SayLocked()
	{
		_lockedSource.Play();
	}

	public void SayGetKey()
	{
		_getKeySource.Play();
	}

	public void SayUnlock()
	{
		_unlockSource.Play();
	}

	public void SayWineRack()
	{
		_wineRackSource.Play();
	}
}
