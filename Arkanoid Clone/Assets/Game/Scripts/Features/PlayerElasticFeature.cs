using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Features;
using System;

public class PlayerElasticFeature
{
    private Transform transform;
    private Vector3 startingScale;
    private float MinimumScaleY;
    private float MaxScaleY;
    private float ScaleSpeed;
    private bool isActive;

    public void SubEvents()
    {
        EventBus<EV_ElasticPaddle>.AddListener(ChangeActivity);
    }
    public void UnSubEvents()
    {
        EventBus<EV_ElasticPaddle>.AddListener(ChangeActivity);
    }

    private void ChangeActivity(object sender, EV_ElasticPaddle @event)
    {
        isActive = !isActive;
        transform.localScale = startingScale;
    }

    public PlayerElasticFeature(Transform transform,float MinimumScaleY,float MaxScaleY,float ScaleSpeed)
    {
        this.transform = transform;
        this.MinimumScaleY = MinimumScaleY;
        this.MaxScaleY = MaxScaleY;
        this.ScaleSpeed = ScaleSpeed;
        startingScale = transform.localScale;
    }
    public void Animate(Vector2 target)
    {
        if (!isActive)
            return;

        float Distance = Mathf.Abs(transform.position.x - target.x);
        if (Distance == 0)
            return;

        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x,
                    (1/Distance % MaxScaleY) + MinimumScaleY, 0), ScaleSpeed * Time.deltaTime);
    }
}
