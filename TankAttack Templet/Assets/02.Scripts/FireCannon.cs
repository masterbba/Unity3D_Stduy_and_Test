using UnityEngine;
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
        if ( MouseHover.instance && MouseHover.instance.isUIHover ) return;

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
        GameObject _cannon = (GameObject)Instantiate(cannon, firePos.position, firePos.rotation);
        _cannon.GetComponent<Cannon>().playerId = pv.ownerId;
    }
}
