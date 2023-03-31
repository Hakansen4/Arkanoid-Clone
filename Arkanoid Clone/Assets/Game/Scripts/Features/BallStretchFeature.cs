using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ambrosia.EventBus;
using Events.Features;
using System;

public class BallStretchFeature
{
    private Transform transform;
    private bool isActive;
    private Vector3 ScaleSize;
    private Vector3 StarterScale;
    public BallStretchFeature(Transform transform,Vector3 StretchSize)
    {
        this.transform = transform;
        StarterScale = transform.localScale;
        ScaleSize = StretchSize;
        isActive = false;
    }

    public void SubEvents()
    {
        EventBus<EV_StretchBall>.AddListener(ChangeActivity);
    }
    public void UnSubEvents()
    {
        EventBus<EV_StretchBall>.RemoveListener(ChangeActivity);
    }

    private void ChangeActivity(object sender, EV_StretchBall @event)
    {
        isActive = !isActive;
    }
    public void AnimateStretch()
    {
        if (!isActive)
            return;

        transform.DOScale(ScaleSize, 0.2f).SetEase(Ease.InOutElastic).SetLoops(4).OnComplete(Reset);
    }
    private void Reset()
    {
        transform.DOScale(StarterScale, 0.2f).SetEase(Ease.InOutElastic);
    }

}
