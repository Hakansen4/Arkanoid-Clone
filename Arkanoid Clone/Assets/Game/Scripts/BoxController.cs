using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour,IPoolable
{
    private TweenFeatures _TweenFeature;

    public void Init(int tweenDistance,int TweenDuration,int MinTweenDuration,int MaxTweenDuration)
    {
        _TweenFeature = new TweenFeatures(tweenDistance, transform,TweenDuration,MaxTweenDuration,MinTweenDuration);
        _TweenFeature.SubEvents();
    }
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        _TweenFeature?.UnSubEvents();
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoxesController.instance.BoxDeactivated(this);
        DeActivate();
    }
}
