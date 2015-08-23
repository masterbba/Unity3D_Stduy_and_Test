using UnityEngine;
using System.Collections;

public class BulletCtrl : MonoBehaviour
{
	public int damage = 20;
	public float speed = 1000.0f;

	void Start ()
	{
		GetComponent<Rigidbody> ().AddForce (transform.forward * speed);	
	}
}
