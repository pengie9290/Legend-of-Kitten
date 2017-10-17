using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenPlayerControl : MonoBehaviour {
	public float MaxSpeed = 1f;
	public int Direction = 0;
	public int OldDirection = 0;
	Rigidbody rb;
	private Animator _kittenAnimator;

	void Start () {
		rb = GetComponent <Rigidbody> ();
		_kittenAnimator = gameObject.GetComponentInChildren<Animator>();
	}
	
	void Update () {
		var haxis = Input.GetAxis ("Horizontal");
		var vaxis = Input.GetAxis ("Vertical");
		transform.Translate (haxis * MaxSpeed * Time.deltaTime, vaxis * MaxSpeed * Time.deltaTime, 0);
		Direction = DirectionDetection (haxis, vaxis);
		if (Direction != OldDirection)
		{
			if (_kittenAnimator != null)
			{
				_kittenAnimator.SetBool("IsIdle", CalculateIdle(Direction));
				_kittenAnimator.SetInteger("Direction", CalculateAnimationDirection(Direction));
				_kittenAnimator.SetTrigger("ChangeState");
			}
			
			
			
			
			OldDirection = Direction;
		}
	}

	int DirectionDetection (float haxis, float vaxis){
		if (haxis > 0.25f) {
			if (vaxis > 0.25f) {
				return 1;
			} else if (vaxis < -0.25f) {
				return 3;
			} else {
				return 2;
			}
		} else if (haxis < -0.25f) {
			if (vaxis > 0.25f) {
				return 7;
			} else if (vaxis < -0.25f) {
				return 5;
			} else {
				return 6;
			}
		} else {
			if (vaxis > 0.25f) {
				return 8;
			} else if (vaxis < -0.25f) {
				return 4;
			} else {
				return 0;
			}
		}
	}

	private int[] AnimationDirection = new int[] {0, 2, 3, 0, 0, 0, 1, 2, 2};

	private int CalculateAnimationDirection(int direction)
	{
		if (direction > AnimationDirection.Length || direction < 0)
		{
			return 0;
		}
		return AnimationDirection[direction];
	}

	private bool CalculateIdle(int direction)
	{
		return direction == 0;
	}
	
	//0 = still
	//1 = up-right
	//2 = right
	//3 = down-right
	//4 = down
	//5 = down-left
	//6 = left
	//7 = up-left
	//8 = up

	public void Report (string Message){
		print (Message);
		MessageDisplay.Show(Message);
	}
}
