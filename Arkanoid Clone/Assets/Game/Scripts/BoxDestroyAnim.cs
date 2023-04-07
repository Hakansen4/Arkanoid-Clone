using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Events.Features;
using Ambrosia.EventBus;


[RequireComponent(typeof(Rigidbody2D))]
public class BoxDestroyAnim
{
    private float Duration;
    private Transform transform;
    private Rigidbody2D Physic;
    private BoxCollider2D BoxCollider;

    private bool ScaleActive;
    private bool GravityActive;
    private bool PushActive;
    private bool RotateActive;
    public BoxDestroyAnim(Transform transform, float Duration,Rigidbody2D Rigidbody,BoxCollider2D Collider)
    {
        this.Duration = Duration;
        this.transform = transform;
        BoxCollider = Collider;
        Physic = Rigidbody;
    }
    public void SubEvents()
    {
        EventBus<EV_BoxDestroyEffect>.AddListener(CheckActivity);
    }
    public void UnSubEvents()
    {
        EventBus<EV_BoxDestroyEffect>.RemoveListener(CheckActivity);
    }

    private void CheckActivity(object sender, EV_BoxDestroyEffect @event)
    {
        switch (@event.effect)
        {
            case BoxDestroyEffect.Scale:
                ScaleActive = !ScaleActive;
                break;
            case BoxDestroyEffect.Gravity:
                GravityActive = !GravityActive;
                break;
            case BoxDestroyEffect.Push:
                PushActive = !PushActive;
                break;
            case BoxDestroyEffect.Rotate:
                RotateActive = !RotateActive;
                break;
            default:
                break;
        }
    }

    public bool Animate()
    {
        if (!ScaleActive && !RotateActive && !PushActive && !GravityActive)
            return false;

        RotateBox();
        PushUp();
        SetGravity();
        ScaleAnim();
        return true;
    }
    private void ScaleAnim()
    {
        if (ScaleActive)
            transform.DOScale(Vector3.zero, Duration);
    }
    private void SetGravity()
    {
        if (!GravityActive)
            return;

        BoxCollider.enabled = false;
        Physic.gravityScale = 1.5f;
    }
    private void PushUp()
    {
        if (!PushActive)
            return;

        int xValue = Random.RandomRange(-100, 100);
        Physic.AddForce(new Vector2(xValue, 200));
    }
    private void RotateBox()
    {
        if (RotateActive)
            transform.DORotate(new Vector3(0, 0, -180), Duration);
    }
}
public enum BoxDestroyEffect
{
    Scale,Gravity,Push,Rotate
};