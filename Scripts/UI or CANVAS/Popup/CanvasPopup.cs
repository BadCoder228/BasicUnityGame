using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CanvasPopup : MonoBehaviour
{
    [SerializeField] Text PlayerScoreDisplayer, EnemyScoreDisplayer;

    private void Update()
    {
        PlayerScoreDisplayer.text = "Player's Score:" + (FindObjectOfType<Score>().CharacterScore * 10).ToString();
        EnemyScoreDisplayer.text =  "Enemy's Score:" + (FindObjectOfType<Score>().EnemyScore * 10).ToString();
    }
}
