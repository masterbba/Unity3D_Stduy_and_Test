using UnityEngine;
using System.Collections;

public class MonsterCtrl : MonoBehaviour
{
	public enum MonsterState { idle, trace, attack, die };
	public MonsterState monsterState = MonsterState.idle;

	private Transform monsterTr;
	private Transform playerTr;
	private NavMeshAgent nvAgent;

	public float traceDist = 10.0f;
	public float attackDist = 2.0f;

	private bool isDie = false;

	void Start ()
	{
		monsterTr = this.gameObject.GetComponent<Transform> ();
		playerTr = GameObject.FindWithTag ("Player").GetComponent<Transform> ();
		nvAgent = this.gameObject.GetComponent<NavMeshAgent>();

		//nvAgent.destination = playerTr.position;
		StartCoroutine (this.CheckMonsterState ());
		StartCoroutine (this.MonsterAction ());
	}

	IEnumerator CheckMonsterState()
	{
		while(!isDie)
		{
			yield return new WaitForSeconds(0.2f);
			float dist = Vector3.Distance(playerTr.position, monsterTr.position);

			if( dist <= attackDist )
			{
				monsterState = MonsterState.attack;
			}
			else if ( dist <= traceDist )
			{
				monsterState = MonsterState.trace;
			}
			else
			{
				monsterState = MonsterState.idle;
			}
		}
	}

	IEnumerator MonsterAction()
	{
		while (!isDie)
		{
			switch(monsterState)
			{
			case MonsterState.idle :
				nvAgent.Stop();
				break;
			case MonsterState.trace:
				nvAgent.destination = playerTr.position;
				nvAgent.Resume();
				break;
			case MonsterState.attack:
				break;
			}
			yield return null;
		}
	}
}
