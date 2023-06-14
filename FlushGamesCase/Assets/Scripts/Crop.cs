using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Crop
{
    public int cropId;
    public string cropName;
    public int baseValue;
    public GameObject pfCrop;
    public Sprite cropSprite;

    public static Crop GetRandomCrop()
    {
        int random = Random.Range(0, GameAssets.i.crops.Length);
        Crop crop = GameAssets.i.crops[random];
        return crop;
    }
}
