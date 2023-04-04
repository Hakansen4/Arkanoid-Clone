using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events.Features;
using Ambrosia.EventBus;
using System;
public class BallHitColorFeature
{
    private SpriteRenderer _Renderer;
    private Material _HitColor;
    private Material _RealColor;
    private Material ChangedColor;
    private MonoBehaviour mono;
    private bool isActive;

    public BallHitColorFeature(Material HitColor,Material ChangedColor,SpriteRenderer Renderer,MonoBehaviour Mono)
    {
        _HitColor = HitColor;
        _Renderer = Renderer;
        this.ChangedColor = ChangedColor;
        mono = Mono;
        _RealColor = _Renderer.material;
    }
    public void SubEvents()
    {
        EventBus<EV_BallHitColor>.AddListener(ChangeActivity);
        EventBus<EV_SetColor>.AddListener(ChangeRealColor);
    }
    public void UnSubEvents()
    {
        EventBus<EV_BallHitColor>.RemoveListener(ChangeActivity);
        EventBus<EV_SetColor>.RemoveListener(ChangeRealColor);
    }

    private void ChangeRealColor(object sender, EV_SetColor @event)
    {
        _RealColor = ChangedColor;
    }

    private void ChangeActivity(object sender, EV_BallHitColor @event)
    {
        isActive = !isActive;
    }

    public void ColorEffect()
    {
        if (!isActive)
            return;

        _Renderer.material = _HitColor;
        mono.StartCoroutine(ResetColor());
    }
    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.1f);
        _Renderer.material = _RealColor;
    }
}
