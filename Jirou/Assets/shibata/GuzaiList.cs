using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuzaiList : MonoBehaviour
{

    public List<GameObject> generatedObjects;
    int num;
    // Start is called before the first frame  
    void Start()
    {
        generatedObjects = new List<GameObject>();
        num = 0;
    }


    public int AddList(GameObject obj)
    {

        generatedObjects.Add(obj);
        num ++;
        return num;
    }

    public void DeleteList(int n)
    {
        Debug.Log("delete = " + n);
        generatedObjects.RemoveAt(n);
        num--;
    }
}
