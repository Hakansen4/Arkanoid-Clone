using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> poolList;
    public GameObject pooledObject;
    public int amountOfPool;

    private void Awake()
    {
        poolList = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountOfPool; i++)
        {
            tmp = Instantiate(pooledObject);
            tmp.SetActive(false);
            poolList.Add(tmp);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountOfPool; i++)
        {
            if(!poolList[i].activeInHierarchy)
            {
                poolList[i].SetActive(true);
                return poolList[i];
            }
        }
        return null;
    }
}
