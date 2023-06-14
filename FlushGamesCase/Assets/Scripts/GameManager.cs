using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int goldAmount;
    [SerializeField] TextMeshProUGUI goldText;

    private void Start()
    {
        goldAmount = PlayerPrefs.GetInt("Gold", 0);
        AddGold(0);
    }
    public void AddGold(int amount)
    {
        Debug.Log(amount.ToString() + " gold added.");
        goldAmount += amount;
        goldText.text = goldAmount.ToString();
        PlayerPrefs.SetInt("Gold", goldAmount);
    }

    public bool CheckGold(int amount)
    {
        if (goldAmount >= amount)
        {
            return true;
        }
        return false;
    }
}
