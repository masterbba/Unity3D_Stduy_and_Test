using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
    public float speed = 60000.0f;
    public GameObject expEffect;
    private CapsuleCollider _collider;
    private Rigidbody _rigidBody;

	void Start ()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidBody = GetComponent<Rigidbody>();

        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        StartCoroutine(this.ExplosionCannon(3.0f));
	}

    void OnTrigerEnter()
    {
        StartCoroutine(this.ExplosionCannon(0.0f));
    }

    IEnumerator ExplosionCannon(float tm)
    {
        yield return new WaitForSeconds(tm);
        _collider.enabled = false;
        _rigidBody.isKinematic = true;

        GameObject obj = (GameObject)Instantiate(expEffect, transform.position, Quaternion.identity);

        Destroy(obj, 1.0f);

        Destroy(this.gameObject, 1.0f);
    }
}
