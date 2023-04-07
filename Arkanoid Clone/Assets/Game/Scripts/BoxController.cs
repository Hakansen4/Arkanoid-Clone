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
    private BoxDestroyAnim _DestroyFeature;
    private float DestroyAnimTime;
    public void Init(int tweenDistance,int TweenDuration,int MinTweenDuration,int MaxTweenDuration,float ShakeDuration,float ShakeStrength,Material Color,float DestroyAnimTime)
    {
        _ShakeFeature = new ShakeFeature<EV_ShakeBox>(transform, ShakeDuration, ShakeStrength);
        _TweenFeature = new TweenFeatures(tweenDistance, transform,TweenDuration,MaxTweenDuration,MinTweenDuration);
        _ColorFeature = new ColorFeature(GetComponent<SpriteRenderer>(), Color);
        _DestroyFeature = new BoxDestroyAnim(transform, DestroyAnimTime, GetComponent<Rigidbody2D>(),GetComponent<BoxCollider2D>());
        _DestroyFeature.SubEvents();
        _ColorFeature.SubEvents();
        _TweenFeature.SubEvents();
        _ShakeFeature.SubEvents();
        EventBus<EV_BallCollide>.AddListener(ShakeBox);
        this.DestroyAnimTime = DestroyAnimTime;
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
        _DestroyFeature?.UnSubEvents();
        gameObject.SetActive(false);
    }

    private void ShakeBox(object sender, EV_BallCollide @event)
    {
        _ShakeFeature.Shake();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_DestroyFeature.Animate())
        {
            BoxesController.instance.BoxDeactivated(this);
            DeActivate();
        }
        else
            StartCoroutine(DestroyAfterAnim());
    }
    private IEnumerator DestroyAfterAnim()
    {
        yield return new WaitForSeconds(DestroyAnimTime);
        BoxesController.instance.BoxDeactivated(this);
        DeActivate();
    }
}
