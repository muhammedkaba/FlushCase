using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Crop _currentCrop;
    private GameObject _currentCropObject;

    private GameObject _cropParent;

    private void Start()
    {
        _cropParent = transform.GetChild(0).gameObject;
        GetNewCrop();
    }

    public void GetNewCrop()
    {
        Crop crop = Crop.GetRandomCrop();
        _currentCrop = crop;
        GameObject temp = Instantiate(crop.pfCrop, transform.GetChild(0));
        _currentCropObject = temp;
        _cropParent.transform.DOScale(1f, 5f).SetEase(Ease.Linear);
        StartCoroutine(ReadyToCollect(1.25f));
    }

    public int CalculateValue()
    {
        int value = _currentCrop.baseValue + (int)(100 * _cropParent.transform.localScale.x);
        return value;
    }

    IEnumerator ReadyToCollect(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<Collider>().enabled = true;
    }

    public void CollectGem(Transform collector, out CollectedCrop crop)
    {
        SoldGemsController.i.CropCollected(_currentCrop.cropId);
        _currentCropObject.transform.SetParent(collector);
        CollectedCrop collectedCrop = _currentCropObject.AddComponent<CollectedCrop>();
        collectedCrop.cropId = _currentCrop.cropId;
        collectedCrop.value = CalculateValue();
        crop = collectedCrop;
        _cropParent.transform.DOKill();
        _cropParent.transform.localScale = Vector3.zero;
        StopAllCoroutines();
        GetComponent<Collider>().enabled = false;
        GetNewCrop();
    }
}
