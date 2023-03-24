using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ambrosia.EventBus;

public class MainMenuUIcontroller : MonoBehaviour
{
    [SerializeField] private Button _PlayGame;

    private void OnEnable()
    {
        _PlayGame.onClick.AddListener(StartGame);
    }
    private void OnDisable()
    {
        _PlayGame.onClick.RemoveListener(StartGame);
    }
    private void StartGame()
    {
        EventBus<EV_OpenGameplayMenu>.Emit(this, new EV_OpenGameplayMenu());
        Debug.Log("EV_OpenGameplayMenu Event Emitted");
    }
}
