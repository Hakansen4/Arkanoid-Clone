using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FeaturesInspector))]
public class FeaturesInspectorEditor : Editor
{
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
        randomizer = GUILayout.Toggle(randomizer, "Randomizer");
        GUILayout.Space(2);
        TweenValue = EditorGUILayout.IntSlider(TweenValue, 0, 3);
        GUILayout.Space(5);
        if(GUILayout.Button("Set Tweening"))
        {
            myScript.SetTweenEvent(TweenValue, randomizer);
        }
        GUILayout.Space(5);
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
        GUILayout.Space(5);
        GUILayout.Space(5);
        GUILayout.Space(5);
        GUILayout.Space(5);
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
        GUILayout.Space(5);
        GUILayout.Space(5);
        GUILayout.Space(5);
        GUILayout.Space(5);
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
    }
}
