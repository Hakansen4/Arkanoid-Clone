using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class SpriteAtlasScript : MonoBehaviour
{
    [SerializeField] private SpriteAtlas _Atlas;
    [SerializeField] private string SpriteName;

    private void Start()
    {
        GetComponent<Image>().sprite = _Atlas.GetSprite(SpriteName);
    }
}
