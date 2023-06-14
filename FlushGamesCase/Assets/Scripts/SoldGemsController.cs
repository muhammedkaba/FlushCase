using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldGemsController : Singleton<SoldGemsController>
{
    [SerializeField] int[] soldCrops;
    [SerializeField] int[] collectedCrops;
    [SerializeField] GemInfoUI[] gemInfoUIs;

    [SerializeField] GameObject pfGemInfoUI;
    [SerializeField] GameObject gemInfoPanel;
    [SerializeField] Transform gemInfoHolder;


    private void Start()
    {
        int cropCount = GameAssets.i.crops.Length;
        soldCrops = new int[cropCount];
        collectedCrops = new int[cropCount];
        gemInfoUIs = new GemInfoUI[cropCount];
        for (int i = 0; i < cropCount; i++)
        {
            collectedCrops[i] = PlayerPrefs.GetInt("Collected" + i.ToString());
            soldCrops[i] = PlayerPrefs.GetInt("Sold" + i.ToString());
            GameObject infoUI = Instantiate(pfGemInfoUI, gemInfoHolder);
            gemInfoUIs[i] = infoUI.GetComponent<GemInfoUI>();
            Crop c = GameAssets.i.crops[i];
            infoUI.GetComponent<GemInfoUI>().Initialize(c.cropName, c.cropSprite, collectedCrops[i], soldCrops[i]);
        }

    }

    public void UpdateValues()
    {
        int cropCount = GameAssets.i.crops.Length;
        for (int i = 0; i < cropCount; i++)
        {
            Crop c = GameAssets.i.crops[i];
            gemInfoUIs[i].GetComponent<GemInfoUI>().Initialize(c.cropName, c.cropSprite, collectedCrops[i], soldCrops[i]);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            return;
        }
        for (int i = 0; i < GameAssets.i.crops.Length; i++)
        {
            PlayerPrefs.SetInt("Collected" + i.ToString(), collectedCrops[i]);
            PlayerPrefs.SetInt("Sold" + i.ToString(), soldCrops[i]);
        }
    }

    public void CropCollected(int index)
    {
        collectedCrops[index]++;
    }

    public void CropSold(int index)
    {
        soldCrops[index]++;
    }


    public void OpenInfoPanel()
    {
        Time.timeScale = 0f;
        gemInfoPanel.transform.DOScale(1f, 0.7f).SetUpdate(true);
        UpdateValues();
    }

    public void CloseInfoPanel()
    {
        gemInfoPanel.transform.DOScale(0f, 0.7f).SetUpdate(true).OnComplete(() =>
        {
            Time.timeScale = 1f;
        });
    }
}
