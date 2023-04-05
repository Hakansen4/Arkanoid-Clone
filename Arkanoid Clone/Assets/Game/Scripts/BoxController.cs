using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Features;
using Events.Others;
using System;

public class BoxController : MonoBehaviour,IPoolable
{
    private TweenFeatures _TweenFeature;
    private ShakeFeature<EV_ShakeBox> _ShakeFeature;
    private ColorFeature _ColorFeature;
    public void Init(int tweenDistance,int TweenDuration,int MinTweenDuration,int MaxTweenDuration,float ShakeDuration,float ShakeStrength,Material Color)
    {
        _ShakeFeature = new ShakeFeature<EV_ShakeBox>(transform, ShakeDuration, ShakeStrength);
        _TweenFeature = new TweenFeatures(tweenDistance, transform,TweenDuration,MaxTweenDuration,MinTweenDuration);
        _ColorFeature = new ColorFeature(GetComponent<SpriteRenderer>(), Color);
        _ColorFeature.SubEvents();
        _TweenFeature.SubEvents();
        _ShakeFeature.SubEvents();
        EventBus<EV_BallCollide>.AddListener(ShakeBox);
    }
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        EventBus<EV_BallCollide>.RemoveListener(ShakeBox);
        _ColorFeature?.UnSubEvents();
        _TweenFeature?.UnSubEvents();
        _ShakeFeature?.UnSubEvents();
        gameObject.SetActive(false);
    }

    private void ShakeBox(object sender, EV_BallCollide @event)
    {
        _ShakeFeature.Shake();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoxesController.instance.BoxDeactivated(this);
        DeActivate();
    }
}
