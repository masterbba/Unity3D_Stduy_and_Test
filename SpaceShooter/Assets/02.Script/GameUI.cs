using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour
{
    public Text txtScore;
    private int totScore = 0;
	void Start ()
    {
        DispScore(0);
	}

    public void DispScore(int score)
    {
        totScore += score;
        txtScore.text = "Score <color=#ff0000>" + totScore.ToString() + "</color>";
    }
}
