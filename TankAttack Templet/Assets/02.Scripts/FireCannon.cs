using UnityEngine;
using System.Collections;

public class FireCannon : MonoBehaviour
{
    public GameObject cannon = null;
    public Transform firePos;

	void Awake()
    {
        cannon = (GameObject)Resources.Load("Cannon");
    }

	void Update ()
    {
	    if( Input.GetMouseButtonDown(0) )
        {
            Fire();
        }
	}

    void Fire()
    {
        Instantiate(cannon, firePos.position, firePos.rotation);
    }
}
