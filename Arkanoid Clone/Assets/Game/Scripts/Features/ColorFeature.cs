using Events.Features;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorFeature : MonoBehaviour, IColorful
{
    [SerializeField] private Material Color;
    public Material _Color => Color;

    private void OnEnable()
    {
        EventBus<EV_SetColor>.AddListener(SetColor);
    }
    private void OnDisable()
    {
        EventBus<EV_SetColor>.RemoveListener(SetColor);
    }
    public void SetColor(object sender, EV_SetColor @event)
    {
        GetComponent<SpriteRenderer>().material = _Color;
    }
}
