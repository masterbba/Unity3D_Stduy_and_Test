using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayUserId : MonoBehaviour
{
    public Text userId;
    private PhotonView pv = null;

	void Start ()
    {
        pv = GetComponent<PhotonView>();
        userId.text = pv.owner.name;
	}
}
