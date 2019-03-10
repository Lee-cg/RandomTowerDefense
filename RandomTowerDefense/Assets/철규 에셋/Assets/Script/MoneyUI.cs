using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyUI : MonoBehaviour
{

    public Text MoneyText; // 플레이어 돈 항상 업데이트

    void Update()
    {
        MoneyText.text = PlayerStats.Money.ToString() + "G";
    }
}