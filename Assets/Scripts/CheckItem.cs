using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItem : MonoBehaviour
{
    private Transform parent;
    private RectTransform rect;
    private Vector3 pos;

    public void ReturnToStart()
    {
        rect.transform.position = pos;
    }

    public void SaveStartPosition()
    {
        rect = GetComponent<RectTransform>();
        pos = rect.position;
    }

    
}
