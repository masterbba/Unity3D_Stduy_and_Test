using UnityEngine;
using System.Collections;

public class UIMgr : MonoBehaviour
{
	public void OnClickStartBtn( RectTransform rt )
	{
		Debug.Log("Click Button "+rt.localScale.x.ToString());
	}
}
