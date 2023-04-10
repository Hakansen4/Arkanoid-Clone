using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FeaturesInspector))]
public class FeaturesInspectorEditor : Editor
{
    #region FeatureValues
    int TweenValue = 0;
    bool randomizer;
    bool ElasticPlayer;
    bool BallScaleEffect;
    bool BallRotateEffect;
    bool BallStretchEffect;
    bool BallHitEffect;
    bool ShakeBox;
    bool ShakeBorder;
    bool BallHitBlock;
    bool BallHitWall;
    bool BallHitPaddle;
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
    #endregion

    #region GroupValues
    bool TweeningGroup;
    bool EaseTween;
    bool Sounds;
    bool Particles;
    bool Paddle;
    #endregion
    public override void OnInspectorGUI()
    {
        FeaturesInspector myScript = (FeaturesInspector)target;

        if (GUILayout.Button("Start Game"))
        {
            myScript.StartGame();
        }

        GUILayout.Space(5);
        if (GUILayout.Button("Set Color"))
        {
            myScript.SetColorEvent();
        }
        GUILayout.Space(5);
        TweeningGroup = EditorGUILayout.BeginFoldoutHeaderGroup(TweeningGroup, "Tweening");
        if (TweeningGroup)
        {
            randomizer = GUILayout.Toggle(randomizer, "Randomizer");
            GUILayout.Space(2);
            EditorGUILayout.LabelField("Tween Type: 0 => Linear | 1 => Slowly | 2 => Passed | 3 => Bounce");
            TweenValue = EditorGUILayout.IntSlider(TweenValue, 0, 3);
            GUILayout.Space(5);
            if (GUILayout.Button("Set Tweening"))
            {
                myScript.SetTweenEvent(TweenValue, randomizer);
            }
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        GUILayout.Space(5);
        EaseTween = EditorGUILayout.BeginFoldoutHeaderGroup(EaseTween, "Tweening And Easing Juicenes");
        if(EaseTween)
        {
            ElasticPlayer = GUILayout.Toggle(ElasticPlayer, "Elastic Paddle");
            myScript.SetPaddleElastic(ElasticPlayer);
            GUILayout.Space(5);
            GUILayout.Space(5);
            BallScaleEffect = GUILayout.Toggle(BallScaleEffect, "Ball Extra Scale");
            myScript.SetBallScaleEffect(BallScaleEffect);
            GUILayout.Space(5);
            GUILayout.Space(5);
            BallRotateEffect = GUILayout.Toggle(BallRotateEffect, "Ball Rotate");
            myScript.SetBallRotate(BallRotateEffect);
            GUILayout.Space(5);
            GUILayout.Space(5);
            BallStretchEffect = GUILayout.Toggle(BallStretchEffect, "Ball Stretch");
            myScript.SetBallStretch(BallStretchEffect);
            GUILayout.Space(5);
            BallHitEffect = GUILayout.Toggle(BallHitEffect, "Ball Hit Effect");
            myScript.SetBallHitEffect(BallHitEffect);
            GUILayout.Space(5);
            ShakeBox = GUILayout.Toggle(ShakeBox, "Box Shake");
            myScript.SetShakeBoxes(ShakeBox);
            GUILayout.Space(5);
            ShakeBorder = GUILayout.Toggle(ShakeBorder, "Border Shake");
            myScript.SetShakeBorders(ShakeBorder);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        Sounds = EditorGUILayout.BeginFoldoutHeaderGroup(Sounds, "Sounds");
        if(Sounds)
        {
            BallHitBlock = GUILayout.Toggle(BallHitBlock, Strings.BallHitBlockSound);
            myScript.SetBallHitBlock(BallHitBlock, Strings.BallHitBlockSound);
            GUILayout.Space(5);
            BallHitWall = GUILayout.Toggle(BallHitWall, Strings.BallHitWallSound);
            myScript.SetBallHitWall(BallHitWall, Strings.BallHitWallSound);
            GUILayout.Space(5);
            BallHitPaddle = GUILayout.Toggle(BallHitPaddle, Strings.BallHitPaddleSound);
            myScript.SetBallHitPaddle(BallHitPaddle, Strings.BallHitPaddleSound);
            GUILayout.Space(5);
            GameMusic = GUILayout.Toggle(GameMusic, "Game Music");
            myScript.SetGameMusic(GameMusic);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        Particles = EditorGUILayout.BeginFoldoutHeaderGroup(Particles, "Effects & Particles");
        if(Particles)
        {
            BallVfx = GUILayout.Toggle(BallVfx, "Ball Hit Visual Effect");
            myScript.SetBallVfx(BallVfx);
            GUILayout.Space(5);
            BoxDeadScale = GUILayout.Toggle(BoxDeadScale, "Box Scale");
            myScript.SetBoxScaleAnim(BoxDeadScale);
            GUILayout.Space(5);
            BoxDeadFall = GUILayout.Toggle(BoxDeadFall, "Box Gravity");
            myScript.SetBoxFallAnim(BoxDeadFall);
            GUILayout.Space(5);
            BoxDeadPush = GUILayout.Toggle(BoxDeadPush, "Box Push");
            myScript.SetBoxPushAnim(BoxDeadPush);
            GUILayout.Space(5);
            BoxDeadRotate = GUILayout.Toggle(BoxDeadRotate, "Box Rotate");
            myScript.SetBoxRotateAnim(BoxDeadRotate);
            GUILayout.Space(5);
            BoxDeadMaterial = GUILayout.Toggle(BoxDeadMaterial, "Box Darken");
            myScript.SetBoxDestroyMaterial(BoxDeadMaterial);
            GUILayout.Space(5);
            PlayerConfetti = GUILayout.Toggle(PlayerConfetti, "Player Confetti");
            myScript.SetPlayerConfetti(PlayerConfetti);
            GUILayout.Space(5);
            BallTrail = GUILayout.Toggle(BallTrail, "Ball Trail");
            myScript.SetBallTrail(BallTrail);
            GUILayout.Space(5);
            ScreenShake = GUILayout.Toggle(ScreenShake, "Screen Shake");
            myScript.SetScreenShake(ScreenShake);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        Paddle = EditorGUILayout.BeginFoldoutHeaderGroup(Paddle, "Paddle Mouth & Eye");
        if(Paddle)
        {
            EditorGUILayout.BeginHorizontal();
            PlayerEyeActive = GUILayout.Toggle(PlayerEyeActive, "Paddle Eye Acitve");
            myScript.SetPlayerEyeActive(PlayerEyeActive);
            PaddleMouth = GUILayout.Toggle(PaddleMouth, "Paddle Mouth");
            myScript.SetPaddleMouth(PaddleMouth);
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(5);
            EditorGUILayout.LabelField("Paddle Eye Scale");
            EyeScaleValue = EditorGUILayout.Slider(EyeScaleValue, 0, 0.3f);
            GUILayout.Space(5);
            EditorGUILayout.LabelField("Paddle Eye Possition");
            EyePosValue = EditorGUILayout.Slider(EyePosValue, -0.25f, 0.25f);
            myScript.SetEyeValues(EyeScaleValue, EyePosValue);
        }
    }
}
