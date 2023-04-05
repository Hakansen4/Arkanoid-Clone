using Events.Features;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorFeature : IColorful
{
    private Material Color;
    private SpriteRenderer renderer;
    public Material _Color => Color;
    public ColorFeature(SpriteRenderer renderer,Material Color)
    {
        this.renderer = renderer;
        this.Color = Color;
    }
    public void SubEvents()
    {
        EventBus<EV_SetColor>.AddListener(SetColor);
    }
    public void UnSubEvents()
    {
        EventBus<EV_SetColor>.RemoveListener(SetColor);
    }
    public void SetColor(object sender, EV_SetColor @event)
    {
        renderer.material = _Color;
    }
}
