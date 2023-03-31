using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Events.Features;
using Ambrosia.EventBus;
using System;

public class BallScaleFeature
{
    private Transform transform;
    private Vector3 ScaleSize;
    private Vector3 StarterScale;
    private bool isActive;

    public void SubEvents()
    {
        EventBus<EV_ScaleBall>.AddListener(ChangeActivity);
    }
    public void UnSubEvents()
    {
        EventBus<EV_ScaleBall>.RemoveListener(ChangeActivity);
    }

    private void ChangeActivity(object sender, EV_ScaleBall @event)
    {
        isActive = !isActive;
    }

    public BallScaleFeature(Transform transform,Vector3 ScaleSize)
    {
        this.transform = transform;
        this.ScaleSize = ScaleSize;
        StarterScale = transform.localScale;
        isActive = false;
    }

    public void ScaleEffect()
    {
        if (!isActive)
            return;
   
        transform.DOScale(ScaleSize, 0.05f).OnComplete(() => transform.DOScale(StarterScale, 0.05f));
    }
}
