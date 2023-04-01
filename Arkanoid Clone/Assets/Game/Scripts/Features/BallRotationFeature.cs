using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Features;
using System;

public class BallRotationFeature
{
    private Transform transform;
    private bool isActive;
    public BallRotationFeature(Transform transform)
    {
        this.transform = transform;
        isActive = false;
    }

    public void SubEvents()
    {
        EventBus<EV_RotateBall>.AddListener(ChangeActivity);
    }
    public void UnSubEvents()
    {
        EventBus<EV_RotateBall>.AddListener(ChangeActivity);
    }

    private void ChangeActivity(object sender, EV_RotateBall @event)
    {
        isActive = !isActive;
        transform.rotation = Quaternion.Euler(Vector2.zero);
    }

    public void SetRotation(Vector2 velocity)
    {
        if (!isActive)
            return;

        Vector2 direction = new Vector2(Mathf.Sign(velocity.x), Mathf.Sign(velocity.y));
        if ((direction.x < 0 && direction.y > 0) || (direction.x > 0 && direction.y < 0))
            transform.rotation = Quaternion.Euler(0, 0, 30);
        else
            transform.rotation = Quaternion.Euler(0, 0, -30);
    }
}
