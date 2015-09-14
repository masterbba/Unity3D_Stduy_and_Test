using UnityEngine;
using System.Collections;

public class GameMgr : MonoBehaviour
{
    public Transform[] points;
    public GameObject monsterPrefab;

    public float createTime = 2.0f;
    public int maxMonster = 10;
    public bool isGameOver = false;
    public static GameMgr instance = null;

    void Awake()
    {
        instance = this;
    }

	void Start ()
    {
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        if( points.Length > 0 )
        {
            StartCoroutine(this.CreateMonster());
        }
	
	}
	
    IEnumerator CreateMonster()
    {
        while (!isGameOver)
        {
            int MonsterCount = (int)GameObject.FindGameObjectsWithTag("MONSTER").Length;
            if (MonsterCount < maxMonster)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);
                Instantiate(monsterPrefab, points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }
    }
}
