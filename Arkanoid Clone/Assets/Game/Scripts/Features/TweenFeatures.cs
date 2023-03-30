using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ambrosia.EventBus;
using Events.Features;
using System.Collections;

public class TweenFeatures : ITweenable
{
    private int MoveSize;
    private float StandartDuration;
    private float Duration;
    private float MaxDuration;
    private float MinDuration;
    private float MoveTarget;
    private Vector3 startingPosition;
    private Transform transform;
    public TweenFeatures(int TweenDistance,Transform transform,int StandartTweenDuration,int MaxTweenDuration,int minTweenDuration)
    {
        this.transform = transform;
        MoveSize = TweenDistance;
        StandartDuration = StandartTweenDuration;
        MaxDuration = MaxTweenDuration;
        MinDuration = minTweenDuration;
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
        Randomizer(@event.Randomizer);
        Tween((TweenType)@event.TweenValue);
    }

    private void Randomizer(bool value)
    {
        if(!value)
        {
            Duration = StandartDuration;
            return;
        }
        Duration = Random.RandomRange(MinDuration, MaxDuration);
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
