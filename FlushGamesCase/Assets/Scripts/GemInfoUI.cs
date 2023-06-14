using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GemInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gemNameText;
    [SerializeField] Image gemImage;
    [SerializeField] TextMeshProUGUI collectedGemsText;
    [SerializeField] TextMeshProUGUI soldGemsText;

    public void Initialize(string name, Sprite sprite, int collected, int sold)
    {
        gemNameText.text = name;
        gemImage.sprite = sprite;
        collectedGemsText.text = "Collected : " + collected.ToString();
        soldGemsText.text = "Sold : " + sold.ToString();
    }
}
