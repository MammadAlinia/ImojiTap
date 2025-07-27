using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class ImojiObject : MonoBehaviour

{
    //آبجکت ایموجی 
    public bool isHadaff;

    public SpriteRenderer _renderer;


    
    private void OnMouseDown()
    {
        // هنگامی که روی من کلیک شد
        if (EventSystem.current.IsPointerOverGameObject()) return;

        ImojiManager.Instance.KelikMe(this);
    }
}