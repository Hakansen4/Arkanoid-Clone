using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using Ambrosia.EventBus;
using System;

public class SceneLoader : MonoBehaviour
{
    public AssetReference GameplayScene;
    public AssetReference MainMenuScene;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        EventBus<EV_OpenGameplayMenu>.AddListener(StartGame);
    }
    private void OnDisable()
    {
        EventBus<EV_OpenGameplayMenu>.RemoveListener(StartGame);
    }

    private void StartGame(object sender, EV_OpenGameplayMenu @event)
    {
        Addressables.LoadSceneAsync(GameplayScene, UnityEngine.SceneManagement.LoadSceneMode.Single).Completed += SceneLoadComplete;
    }

    private void Start()
    {
        Addressables.LoadSceneAsync(MainMenuScene, UnityEngine.SceneManagement.LoadSceneMode.Single).Completed += SceneLoadComplete;
    }
    private void SceneLoadComplete(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj)
    {
        Debug.Log(obj.Result.Scene.name + " Loaded.");
    }
}
