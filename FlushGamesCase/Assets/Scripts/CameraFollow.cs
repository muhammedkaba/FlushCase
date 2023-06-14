using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _objectToFollow;

    private Vector3 offset;
    void Start()
    {
        offset = transform.position - _objectToFollow.position;
    }

    void LateUpdate()
    {
        transform.position = _objectToFollow.position + offset;
    }
}
