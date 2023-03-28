using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoxesController : MonoBehaviour
{
    public static BoxesController instance;

    private List<GameObject> _BoxList;
    [SerializeField] private GameObject _BoxPrefab;
    public float distanceBtwBoxes_X;
    public float distanceBtwBoxes_Y;
    public float StarterXPos;
    public float StarterYPos;
    public int Size_X;
    public int Size_Y;
    private ObjectPool<BoxController> BoxPool;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _BoxList = new List<GameObject>();
        BoxPool = new ObjectPool<BoxController>(Size_X*Size_Y,_BoxPrefab);
        for (int i = 0; i < Size_Y; i++)
        {
            for (int j = 0; j < Size_X; j++)
            {
                var box = BoxPool.GetPooledObject();
                box.gameObject.transform.position = new Vector3(StarterXPos + (j * distanceBtwBoxes_X)
                                                    , StarterYPos - (i * distanceBtwBoxes_Y), 0);
                _BoxList.Add(box.gameObject);
            }
        }
    }
    public void BoxDeactivated(BoxController box)
    {
        _BoxList.Remove(box.gameObject);
        BoxPool.ObjectDeactivated(box);
    }
}