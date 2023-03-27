using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesController : MonoBehaviour
{
    private List<GameObject> _BoxList;
    public ObjectPool BoxPool;
    public float distanceBtwBoxes_X;
    public float distanceBtwBoxes_Y;
    public float StarterXPos;
    public float StarterYPos;
    public float Size_X;
    public float Size_Y;
    private void Start()
    {
        _BoxList = new List<GameObject>();
        for (int i = 0; i < Size_Y; i++)
        {
            for (int j = 0; j < Size_X; j++)
            {
                var box = BoxPool.GetPooledObject();
                box.transform.position = new Vector3(StarterXPos + (j * distanceBtwBoxes_X)
                                                    , StarterYPos - (i * distanceBtwBoxes_Y), 0);
                _BoxList.Add(box);
            }
        }
    }
}