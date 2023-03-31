using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Features;
using Events.Others;

public class FeaturesInspector : MonoBehaviour
{
    [SerializeField] private TweenType typeTween;
    bool ElasticPlayer;
    bool BallScaleEffect;
    bool BallRotateEffect;
    public void StartGame()
    {
        EventBus<EV_StartGame>.Emit(this, new EV_StartGame());
    }
    public void SetTweenEvent(int TweenValue,bool randomizer)
    {
        EventBus<EV_SetTweening>.Emit(this, new EV_SetTweening(TweenValue, randomizer));
    }
    public void SetColorEvent()
    {
        EventBus<EV_SetColor>.Emit(this, new EV_SetColor());
    }

    public void SetPaddleElastic(bool value)
    {
        if(ElasticPlayer != value)
        {
            ElasticPlayer = value;
            EventBus<EV_ElasticPaddle>.Emit(this, new EV_ElasticPaddle());
        }
    }
    public void SetBallScaleEffect(bool value)
    {
        if(BallScaleEffect != value)
        {
            BallScaleEffect = value;
            EventBus<EV_ScaleBall>.Emit(this, new EV_ScaleBall());
        }
    }
    
    public void SetBallRotate(bool value)
    {
        if(BallRotateEffect != value)
        {
            BallRotateEffect = value;
            EventBus<EV_RotateBall>.Emit(this, new EV_RotateBall());
        }
    }
}
