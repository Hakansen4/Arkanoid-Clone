using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events.Features;
using Ambrosia.EventBus;
using System;

public class BallTrailFeature
{
    private GameObject _TrailObject;
    private Material _ColorFeature;
    public BallTrailFeature(GameObject TrailObject, Material colorFeature)
    {
        _TrailObject = TrailObject;
        _ColorFeature = colorFeature;
    }
    public void SubEvents()
    {
        EventBus<EV_SetColor>.AddListener(ChangeColor);
        EventBus<EV_BallTrail>.AddListener(ChangeActivity);
    }
    public void UnSubEvents()
    {
        EventBus<EV_SetColor>.RemoveListener(ChangeColor);
        EventBus<EV_BallTrail>.RemoveListener(ChangeActivity);
    }

    private void ChangeActivity(object sender, EV_BallTrail @event)
    {
        if (_TrailObject.active)
            _TrailObject.SetActive(false);
        else
            _TrailObject.SetActive(true);
    }

    private void ChangeColor(object sender, EV_SetColor @event)
    {
        _TrailObject.GetComponent<TrailRenderer>().material = _ColorFeature;
    }
}
