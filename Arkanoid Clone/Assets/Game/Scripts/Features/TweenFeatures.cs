using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ambrosia.EventBus;
using Events.Features;
using System;

public class TweenFeatures : MonoBehaviour, ITweenable
{
    public int MoveSize;
    public float Duration;
    private float MoveTarget;
    private Vector3 startingPosition;
    private void Start()
    {
        startingPosition = transform.position;
        MoveTarget = transform.position.y - MoveSize;
    }

    private void OnEnable()
    {
        EventBus<EV_SetTweening>.AddListener(StartTweening);
    }

    private void OnDisable()
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
