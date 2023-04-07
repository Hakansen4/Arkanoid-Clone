using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoxesController : MonoBehaviour
{
    public static BoxesController instance;

    private List<BoxController> _BoxList;
    private ObjectPool<BoxController> BoxPool;
    #region Data
    [Header("Box Prefab")]
    [SerializeField] private GameObject _BoxPrefab;
    [Header("Box Placement Information")]
    [SerializeField] private float distanceBtwBoxes_X;
    [SerializeField] private float distanceBtwBoxes_Y;
    [SerializeField] private float StarterXPos;
    [SerializeField] private float StarterYPos;
    [SerializeField] private int Size_X;
    [SerializeField] private int Size_Y;
    [Header("Tween Feature")]
    [SerializeField] private int BoxTweenDistance;
    [SerializeField] private int BoxTweenDuration;
    [SerializeField] private int MaxBoxTweenDuration;
    [SerializeField] private int MinBoxTweenDuration;
    [Header("Shake Feature")]
    [SerializeField] private float BoxShakeDuration;
    [SerializeField] private float BoxShakeStrength;
    [Header("Box Destroy Animations")]
    [SerializeField] private float BoxDestroyAnimTime;
    [SerializeField] private Material DestroyMaterial;
    [Header("Color Feature")]
    [SerializeField] private Material _Color;
    #endregion
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _BoxList = new List<BoxController>();
        BoxPool = new ObjectPool<BoxController>(Size_X*Size_Y,_BoxPrefab);
        StarterYPos += BoxTweenDistance;
        for (int i = 0; i < Size_Y; i++)
        {
            for (int j = 0; j < Size_X; j++)
            {
                CreateBoxe(new Vector3(StarterXPos + (j * distanceBtwBoxes_X)
                                            , StarterYPos - (i * distanceBtwBoxes_Y), 0));
            }
        }
    }
    private void CreateBoxe(Vector3 position)
    {
        var box = BoxPool.GetPooledObject();
        box.gameObject.transform.position = position;
        box.Init(BoxTweenDistance, BoxTweenDuration, MinBoxTweenDuration, MaxBoxTweenDuration, BoxShakeDuration, BoxShakeStrength, _Color, BoxDestroyAnimTime,DestroyMaterial);
        _BoxList.Add(box);
    }
    public void BoxDeactivated(BoxController box)
    {
        _BoxList.Remove(box);
        BoxPool.ObjectDeactivated(box);
    }
}