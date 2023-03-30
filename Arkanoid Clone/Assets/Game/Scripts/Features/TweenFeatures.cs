using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ambrosia.EventBus;
using Events.Features;
using System;

public class TweenFeatures : ITweenable
{
    private int MoveSize;
    private float Duration;
    private float MoveTarget;
    private Vector3 startingPosition;
    private Transform transform;
    //private void Start()
    //{
    //    if (Created)
    //        return;

    //    startingPosition = transform.position;
    //    MoveTarget = transform.position.y - MoveSize;
    //}

    //public void Init(int TweenDistance)
    //{
    //    startingPosition = transform.position;
    //    MoveTarget = transform.position.y - TweenDistance;
    //    Created = true;
    //}
    public TweenFeatures(int TweenDistance,Transform transform,int TweenDuration)
    {
        this.transform = transform;
        MoveSize = TweenDistance;
        Duration = TweenDuration;
        startingPosition = transform.position;
        MoveTarget = transform.position.y - MoveSize;
    }
    public void SubEvents()
    {
        EventBus<EV_SetTweening>.AddListener(StartTweening);
    }

    public void UnSubEvents()
    {
        EventBus<EV_SetTweening>.RemoveListener(StartTweening);
    }
    private void StartTweening(object sender, EV_SetTweening @event)
    {
        transform.position = startingPosition;
        Tween((TweenType)@event.TweenValue);
    }

    public void Tween(TweenType tween)
    {
        switch (tween)
        {
            case TweenType.lineer:
                MoveLineer();
                break;
            case TweenType.slowDown:
                MoveSlowDown();
                break;
            case TweenType.pass:
                MovePass();
                break;
            case TweenType.bounce:
                MoveBounce();
                break;
            default:
                break;
        }
    }

    private void MoveLineer()
    {
        transform.DOMoveY(MoveTarget, Duration).SetEase(Ease.Linear);
    }
    private void MoveSlowDown()
    {
        transform.DOMoveY(MoveTarget, Duration).SetEase(Ease.OutQuad);
    }
    private void MovePass()
    {
        transform.DOMoveY(MoveTarget, Duration).SetEase(Ease.OutBack);
    }
    private void MoveBounce()
    {
        transform.DOMoveY(MoveTarget, Duration).SetEase(Ease.OutBounce);
    }
}
