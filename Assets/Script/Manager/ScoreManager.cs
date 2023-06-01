using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public static int currentScore;
    [SerializeField] public Text textScore;
    void Start()
    {
        EventManager.AddListener(EventName.AddScoreEvent, AddScoreKillEnemy);
    }
    private void DisplayScore()
    {
        textScore.text = "Xu: " + currentScore.ToString();
        if(currentScore <= 1000)
        {
            textScore.color = Color.red;
        }
        else
        {
            textScore.color = Color.white;
        }
    }

    public void AddScoreKillEnemy(int enemyPoint)
    {
        currentScore += enemyPoint;
        Debug.Log("Current Score: "+ currentScore );
        DisplayScore();
    }

    public static void SubtractScoreUpgradeTower(int upgradeCost)
    {
        if (currentScore >= upgradeCost)
        {
            currentScore -= upgradeCost;
        }
        else
        {
            Debug.Log("Can't Upgrade!");
        }
    }

    public static void AddScoreSellTower(int towerPrice)
    {
        currentScore += towerPrice;
    }
}
