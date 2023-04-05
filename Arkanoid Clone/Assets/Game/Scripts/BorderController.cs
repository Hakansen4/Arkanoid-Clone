using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events.Others;
using Events.Features;
using Ambrosia.EventBus;
using System;

public class BorderController : MonoBehaviour
{
    private ShakeFeature<EV_ShakeBorder> _ShakeFeature;
    private ColorFeature _ColorFeature;
    [SerializeField] private float ShakeDuration;
    [SerializeField] private float StrengthShake;
    [SerializeField] private Material Color;
    private void Awake()
    {
        _ShakeFeature = new ShakeFeature<EV_ShakeBorder>(transform, ShakeDuration, StrengthShake);
        _ColorFeature = new ColorFeature(GetComponent<SpriteRenderer>(), Color);
    }
    private void OnEnable()
    {
        _ShakeFeature.SubEvents();
        _ColorFeature.SubEvents();
    }
    private void OnDisable()
    {
        _ShakeFeature.UnSubEvents();
        _ColorFeature.UnSubEvents();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _ShakeFeature.Shake();
    }
}
