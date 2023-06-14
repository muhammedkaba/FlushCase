using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    private GameObject _pfTile;

    [SerializeField] int x, z;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void InitializeTiles()
    {
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        _pfTile = GameAssets.i.pfTile;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < z; j++)
            {
                GameObject createdTile =
                    Instantiate(_pfTile, transform.position + new Vector3(i * _pfTile.transform.localScale.x * 1.1f, 0f, j * _pfTile.transform.localScale.z * 1.1f), _pfTile.transform.rotation, transform);
            }
        }
        DestroyImmediate(GameAssets.i.gameObject);
    }
}
