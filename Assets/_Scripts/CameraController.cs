using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

using UnityEngine;

public class CameraController : MonoBehaviour
{
  
    [SerializeField] private float _buffer;
    [SerializeField] private Camera _cam;
    private void Start()
    {
       
      
    }

    public void UpdateCamera(List<ImojiObject> taps)
    {
        var (center, size) = CalculateOrthoSize(taps);
        transform.DOMove(center,.5f) ;
        _cam.DOOrthoSize(size, .5f);
    }
    private (Vector3 center, float size) CalculateOrthoSize(List<ImojiObject> taps)
    {
        var bounds = new Bounds();

        foreach (var col in taps) bounds.Encapsulate(col.GetComponent<Collider2D>().bounds);
        bounds.Expand(_buffer);

        var vertical = bounds.size.y;
        var horizontal = bounds.size.x * _cam.pixelHeight / _cam.pixelWidth;

        var size = Mathf.Max(horizontal, vertical) * 0.5f;
        var center = bounds.center + new Vector3(0, 0, -10);

        return (center, size);


    }
}