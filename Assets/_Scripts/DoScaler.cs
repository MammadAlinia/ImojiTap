using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoScaler : MonoBehaviour
{
    [SerializeField] private float scale;
    [SerializeField] private float duration;
    [SerializeField] private bool infinitLoop;
    [SerializeField] private int loopCount;

    [SerializeField] private AnimationCurve curve;
    private void Start()
    {
        transform.DOScale(transform.localScale * scale, duration).SetLoops(infinitLoop?-1: loopCount).SetEase(curve);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}