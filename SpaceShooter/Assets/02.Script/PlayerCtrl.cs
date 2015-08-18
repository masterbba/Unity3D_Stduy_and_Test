﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Anim
{
	public AnimationClip idle;
	public AnimationClip runForward;
	public AnimationClip runBackward;
	public AnimationClip runRight;
	public AnimationClip runLeft;
}
public class PlayerCtrl : MonoBehaviour
{
	private float h = 0.0f;
	private float v = 0.0f;

	private Transform tr;
	public float moveSpeed = 10.0f;
	public float rotSpeed = 100.0f;
	public Anim anim;
	public Animation _animation;

	void Start ()
	{
		tr = GetComponent<Transform> ();

		_animation = GetComponentInChildren<Animation> ();
		_animation.clip = anim.idle;
		_animation.Play ();
	}

	void Update ()
	{
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

		Debug.Log ("H=" + h.ToString ());
		Debug.Log ("V=" + v.ToString ());

		Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

		tr.Translate (moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

		tr.Rotate(Vector3.up*Time.deltaTime*rotSpeed*Input.GetAxis("Mouse X"));
	}
}