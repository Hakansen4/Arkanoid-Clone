using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoxesController : MonoBehaviour
{
    public static BoxesController instance;

    private List<BoxController> _BoxList;
    [SerializeField] private GameObject _BoxPrefab;
    public float distanceBtwBoxes_X;
    public float distanceBtwBoxes_Y;
    public float StarterXPos;
    public float StarterYPos;
    public int Size_X;
    public int Size_Y;
    public int BoxTweenDistance;
    public int BoxTweenDuration;
    public int MaxBoxTweenDuration;
    public int MinBoxTweenDuration;
    public float BoxShakeDuration;
    public float BoxShakeStrength;
    private ObjectPool<BoxController> BoxPool;
    [SerializeField] private Material _Color;
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
        box.Init(BoxTweenDistance, BoxTweenDuration, MinBoxTweenDuration, MaxBoxTweenDuration, BoxShakeDuration, BoxShakeStrength, _Color);
        _BoxList.Add(box);
    }
    public void BoxDeactivated(BoxController box)
    {
        _BoxList.Remove(box);
        BoxPool.ObjectDeactivated(box);
    }
}