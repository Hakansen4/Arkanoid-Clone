using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using Events.Features;
using Events.Others;

public class FeaturesInspector : MonoBehaviour
{
    [SerializeField] private TweenType typeTween;
    bool ElasticPlayer;
    bool BallScaleEffect;
    bool BallRotateEffect;
    bool BallStretchEffect;
    bool BallHitEffect;
    bool ShakeBoxEffect;
    bool ShakeBorderEffect;
    bool BallHitBlock;
    bool BallHitPaddle;
    bool BallHitWall;
    bool GameMusic;
    bool BallVfx;
    bool BoxDeadScale;
    bool BoxDeadFall;
    bool BoxDeadPush;
    bool BoxDeadRotate;
    bool BoxDeadMaterial;
    bool PlayerConfetti;
    bool PlayerEyeActive;
    float EyeScaleValue;
    float EyePosValue;
    bool PaddleMouth;
    bool ScreenShake;
    bool BallTrail;
    public void StartGame()
    {
        EventBus<EV_StartGame>.Emit(this, new EV_StartGame());
    }
    public void SetTweenEvent(int TweenValue,bool randomizer)
    {
        EventBus<EV_SetTweening>.Emit(this, new EV_SetTweening(TweenValue, randomizer));
    }
    public void SetColorEvent()
    {
        EventBus<EV_SetColor>.Emit(this, new EV_SetColor());
    }

    public void SetPaddleElastic(bool value)
    {
        if(ElasticPlayer != value)
        {
            ElasticPlayer = value;
            EventBus<EV_ElasticPaddle>.Emit(this, new EV_ElasticPaddle());
        }
    }
    public void SetBallScaleEffect(bool value)
    {
        if(BallScaleEffect != value)
        {
            BallScaleEffect = value;
            EventBus<EV_ScaleBall>.Emit(this, new EV_ScaleBall());
        }
    }
    
    public void SetBallRotate(bool value)
    {
        if(BallRotateEffect != value)
        {
            BallRotateEffect = value;
            EventBus<EV_RotateBall>.Emit(this, new EV_RotateBall());
        }
    }
    public void SetBallStretch(bool value)
    {
        if(BallStretchEffect != value)
        {
            BallStretchEffect = value;
            EventBus<EV_StretchBall>.Emit(this, new EV_StretchBall());
        }
    }
    public void SetBallHitEffect(bool value)
    {
        if(BallHitEffect != value)
        {
            BallHitEffect = value;
            EventBus<EV_BallHitColor>.Emit(this, new EV_BallHitColor());
        }
    }
    public void SetShakeBoxes(bool value)
    {
        if(ShakeBoxEffect != value)
        {
            ShakeBoxEffect = value;
            EventBus<EV_ShakeBox>.Emit(this, new EV_ShakeBox());
        }
    }
    public void SetShakeBorders(bool value)
    {
        if(ShakeBorderEffect != value)
        {
            ShakeBorderEffect = value;
            EventBus<EV_ShakeBorder>.Emit(this, new EV_ShakeBorder());
        }
    }
    public void SetBallHitBlock(bool value,string type)
    {
        if (BallHitBlock != value)
        {
            BallHitBlock = value;
            EventBus<EV_BallHitSound>.Emit(this, new EV_BallHitSound(type));
        }
    }
    public void SetBallHitPaddle(bool value, string type)
    {
        if (BallHitPaddle != value)
        {
            BallHitPaddle = value;
            EventBus<EV_BallHitSound>.Emit(this, new EV_BallHitSound(type));
        }
    }
    public void SetBallHitWall(bool value, string type)
    {
        if (BallHitWall != value)
        {
            BallHitWall = value;
            EventBus<EV_BallHitSound>.Emit(this, new EV_BallHitSound(type));
        }
    }
    public void SetGameMusic(bool value)
    {
        if (GameMusic != value)
        {
            GameMusic = value;
            EventBus<EV_MusicSound>.Emit(this, new EV_MusicSound());
        }
    }
    public void SetBallVfx(bool value)
    {
        if (BallVfx != value)
        {
            BallVfx = value;
            EventBus<EV_BallHitVfx>.Emit(this, new EV_BallHitVfx());
        }
    }
    public void SetBoxScaleAnim(bool value)
    {
        if (BoxDeadScale != value)
        {
            BoxDeadScale = value;
            EventBus<EV_BoxDestroyEffect>.Emit(this, new EV_BoxDestroyEffect(BoxDestroyEffect.Scale));
        }
    }
    public void SetBoxFallAnim(bool value)
    {
        if (BoxDeadFall != value)
        {
            BoxDeadFall = value;
            EventBus<EV_BoxDestroyEffect>.Emit(this, new EV_BoxDestroyEffect(BoxDestroyEffect.Gravity));
        }
    }
    public void SetBoxPushAnim(bool value)
    {
        if (BoxDeadPush != value)
        {
            BoxDeadPush = value;
            EventBus<EV_BoxDestroyEffect>.Emit(this, new EV_BoxDestroyEffect(BoxDestroyEffect.Push));
        }
    }
    public void SetBoxRotateAnim(bool value)
    {
        if (BoxDeadRotate != value)
        {
            BoxDeadRotate = value;
            EventBus<EV_BoxDestroyEffect>.Emit(this, new EV_BoxDestroyEffect(BoxDestroyEffect.Rotate));
        }
    }
    public void SetBoxDestroyMaterial(bool value)
    {
        if (BoxDeadMaterial != value)
        {
            BoxDeadMaterial = value;
            EventBus<EV_BoxDestroyEffect>.Emit(this, new EV_BoxDestroyEffect(BoxDestroyEffect.ChangeColor));
        }
    }
    public void SetPlayerConfetti(bool value)
    {
        if(PlayerConfetti != value)
        {
            PlayerConfetti = value;
            EventBus<EV_PlayerConfetti>.Emit(this, new EV_PlayerConfetti());
        }
    }
    public void SetPlayerEyeActive(bool value)
    {
        if (PlayerEyeActive != value)
        {
            PlayerEyeActive = value;
            EventBus<EV_PlayerEyeActive>.Emit(this, new EV_PlayerEyeActive());
        }
    }
    public void SetEyeValues(float Scalevalue, float PosValue)
    {
        if (EyePosValue != PosValue    || EyeScaleValue != Scalevalue)
        {
            EyePosValue = PosValue;
            EyeScaleValue = Scalevalue;
            EventBus<EV_EyeValues>.Emit(this, new EV_EyeValues(EyeScaleValue, EyePosValue));
        }
    }
    public void SetPaddleMouth(bool value)
    {
        if (PaddleMouth != value)
        {
            PaddleMouth = value;
            EventBus<EV_ActivateMouth>.Emit(this, new EV_ActivateMouth());
        }
    }
    public void SetScreenShake(bool value)
    {
        if (ScreenShake != value)
        {
            ScreenShake = value;
            EventBus<EV_ScreenShake>.Emit(this, new EV_ScreenShake());
        }
    }
    public void SetBallTrail(bool value)
    {
        if (BallTrail != value)
        {
            BallTrail = value;
            EventBus<EV_BallTrail>.Emit(this, new EV_BallTrail());
        }
    }
}
