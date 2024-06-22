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

    // Update is called once per frame
    void Update()
    {
       
    }

    public int AddList(GameObject obj)
    {

        generatedObjects.Add(obj);
        num ++;
        return num;
    }

    public void DeleteList(int num)
    {
        Debug.Log("delete = " + num);
        generatedObjects.RemoveAt(num);
    }
}
