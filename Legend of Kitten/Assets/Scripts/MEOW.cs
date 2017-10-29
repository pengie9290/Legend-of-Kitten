using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEOW : MonoBehaviour{
	public float IdleVolume = 0.5f;
	public float MainVolume = 0.5f;
	public AudioClip IdleMeow;
	public AudioClip JumpMeow;
	public AudioClip ClimbMeow;
	public AudioClip SwipeMeow;
	public AudioClip FallMeow;
	public AudioClip RespawnMeow;
	private AudioSource IdleCat;
	private AudioSource JumpCat;
	private AudioSource ClimbCat;
	private AudioSource SwipeCat;
	private AudioSource FallCat;
	private AudioSource RespawnCat;

	AudioSource MakeSource (AudioClip Clip, bool PlayOnWake = false, bool Loop = false){
		AudioSource NewSource = gameObject.AddComponent <AudioSource> ();
		if (Clip != null) {
			NewSource.clip = Clip;
			NewSource.playOnAwake = PlayOnWake;
			NewSource.loop = Loop;
			NewSource.rolloffMode = AudioRolloffMode.Linear;
			NewSource.volume = MainVolume;
		}
		return NewSource;
	}

	void Awake (){
		IdleCat = MakeSource (IdleMeow);
		if (IdleCat != null)
			IdleCat.volume = IdleVolume;
		JumpCat = MakeSource (JumpMeow);
		ClimbCat = MakeSource (ClimbMeow);
		SwipeCat = MakeSource (SwipeMeow);
		FallCat = MakeSource (FallMeow);
		RespawnCat = MakeSource (RespawnMeow);
		print ("Mrow!");
	}


	public void SayIdle (){
		IdleCat.Play ();
	}

	public void SayJump (){
		JumpCat.Play ();
		IdleCat.Stop ();
	}

	public void SayClimb (){
		ClimbCat.Play ();
		IdleCat.Stop ();
	}

	public void SaySwipe (){
		SwipeCat.Play ();
		IdleCat.Stop ();
	}

	public void SayFall (){
		FallCat.Play ();
		IdleCat.Stop ();
	}

	public void SayRespawn (){
		RespawnCat.Play ();
		IdleCat.Stop ();
	}
}
