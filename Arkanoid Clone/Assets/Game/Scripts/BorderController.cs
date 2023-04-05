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
    [SerializeField] private float ShakeDuration;
    [SerializeField] private float StrengthShake;
    private void Awake()
    {
        _ShakeFeature = new ShakeFeature<EV_ShakeBorder>(transform, ShakeDuration, StrengthShake);
    }
    private void OnEnable()
    {
        _ShakeFeature.SubEvents();
    }
    private void OnDisable()
    {
        _ShakeFeature.UnSubEvents();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _ShakeFeature.Shake();
    }
}
