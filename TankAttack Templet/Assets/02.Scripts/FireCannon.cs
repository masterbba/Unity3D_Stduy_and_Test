﻿using UnityEngine;
using System.Collections;

public class FireCannon : MonoBehaviour
{
    public GameObject cannon = null;
    public Transform firePos;
    private AudioClip fireSfx = null;
    private AudioSource sfx = null;
    private PhotonView pv = null;

	void Awake()
    {
        cannon = (GameObject)Resources.Load("Cannon");
        fireSfx = Resources.Load<AudioClip>("CannonFire");
        sfx = GetComponent<AudioSource>();
        pv = GetComponent<PhotonView>();
    }

	void Update ()
    {
	    if( pv.isMine && Input.GetMouseButtonDown(0) )
        {
            Fire();
            pv.RPC("Fire", PhotonTargets.Others, null);
        }
	}

    [PunRPC]    
    void Fire()
    {
        sfx.PlayOneShot(fireSfx, 1.0f);
        Instantiate(cannon, firePos.position, firePos.rotation);
    }
}
