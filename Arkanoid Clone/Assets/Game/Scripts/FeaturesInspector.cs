using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Features;

public class FeaturesInspector : MonoBehaviour
{
    [SerializeField] private TweenType typeTween;
    public void SetTweenEvent(int TweenValue,bool randomizer)
    {
        EventBus<EV_SetTweening>.Emit(this, new EV_SetTweening(TweenValue, randomizer));
    }
    public void SetColorEvent()
    {
        EventBus<EV_SetColor>.Emit(this, new EV_SetColor());
    }
}
