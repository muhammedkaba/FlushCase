using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : MonoBehaviour
{
    public float yPos;
    [SerializeField] Transform stackParent;
    [SerializeField] List<CollectedCrop> crops;

    [SerializeField] float sellFrequency;
    private SellArea lastArea;
    Coroutine startSellMethod;

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Tile>(out Tile t))
        {
            t.CollectGem(stackParent, out CollectedCrop crop);
            crops.Add(crop);
            crop.transform.SetParent(stackParent);
            crop.transform.DOLocalMove(new Vector3(0, yPos, 0), 0.4f);
            yPos += crop.GetComponent<MeshRenderer>().bounds.size.y * 1.1f;
        }
        if (other.TryGetComponent<SellArea>(out SellArea s))
        {
            lastArea = s;
            startSellMethod = StartCoroutine(StartSelling());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopSelling();
    }

    IEnumerator StartSelling()
    {
        while (true)
        {
            yield return new WaitForSeconds(sellFrequency);
            if (crops.Count > 0)
            {
                SellItem();
                continue;
            }
            StopCoroutine(startSellMethod);
        }
    }

    public void StopSelling()
    {
        StopCoroutine(startSellMethod);
    }

    public void SellItem()
    {
        CollectedCrop topCrop = crops[crops.Count - 1];
        topCrop.transform.DOKill();
        int value = topCrop.value;
        yPos -= topCrop.GetComponent<MeshRenderer>().bounds.size.y * 1.1f;
        topCrop.transform.DOJump(lastArea.sellPos.position, 1, 1, 0.2f).OnComplete(() =>
        {
            SoldGemsController.i.CropSold(topCrop.cropId);
            GameManager.i.AddGold(value);
            Destroy(topCrop.gameObject);
        });
        crops.RemoveAt(crops.Count - 1);
    }
}
