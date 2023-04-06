using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Others;
public class BallCollision : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _physic;
    [SerializeField] private SpriteRenderer _renderer;

    private BallScaleFeature _ScaleFeature;
    private BallRotationFeature _RotateFeature;
    private BallStretchFeature _StretchFeature;
    private BallHitColorFeature _HitColorFeature;
    private void OnEnable()
    {
        _ScaleFeature.SubEvents();
        _RotateFeature.SubEvents();
        _StretchFeature.SubEvents();
        _HitColorFeature.SubEvents();
    }

    private void OnDisable()
    {
        _ScaleFeature.UnSubEvents();
        _RotateFeature.UnSubEvents();
        _StretchFeature.UnSubEvents();
        _HitColorFeature.UnSubEvents();
    }

    public void Init(Vector3 ScaleAnimSize,Vector3 StretchSize,Material HitColor,Material ColorfulColor)
    {
        _StretchFeature = new BallStretchFeature(transform, StretchSize);
        _ScaleFeature = new BallScaleFeature(transform, ScaleAnimSize);
        _RotateFeature = new BallRotationFeature(transform);
        _HitColorFeature = new BallHitColorFeature(HitColor, ColorfulColor, _renderer, this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerHitEvents(collision.gameObject.tag);
        _RotateFeature.SetRotation(_physic.velocity);
        _StretchFeature.AnimateStretch();
        _ScaleFeature.ScaleEffect();
        _HitColorFeature.ColorEffect();
    }
    private void TriggerHitEvents(string collidedObject)
    {
        EventBus<EV_BallCollide>.Emit(this, new EV_BallCollide());
        if (collidedObject == Strings.BoxTag)
            EventBus<EV_BallBlockCollide>.Emit(this, new EV_BallBlockCollide());
        else if (collidedObject == Strings.PlayerTag)
            EventBus<EV_BallPaddleCollide>.Emit(this, new EV_BallPaddleCollide());
        else if (collidedObject == Strings.BorderTag)
            EventBus<EV_BallWallCollide>.Emit(this, new EV_BallWallCollide());
    }
}
