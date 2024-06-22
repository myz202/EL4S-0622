using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandamObject : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] blockPrefabs; // プレハブの配列
    public bool redy = true;
    public float interval = 1.0f;

    public int randomIndexNext;
    public int randomIndex;

    GameObject camera;
    GuzaiList guzaiList;
    void Start()
    {
        GameObject guzaiListObject = GameObject.Find("GameManager");
        camera = GameObject.Find("Main Camera");

        if (guzaiListObject != null)
        {
            guzaiList = guzaiListObject.GetComponent<GuzaiList>();
        }

        randomIndexNext = Random.Range(0, blockPrefabs.Length);
        randomIndex = randomIndexNext;
        //Debug.Log("first" + randomIndexNext);
       // StartCoroutine(MyCoroutine(0));
    }



    // Update is called once per frame
    void Update()
    {
        if (redy)
        {
            StartCoroutine(MyCoroutine(interval));
        }
    }

    IEnumerator MyCoroutine(float f)
    {
        redy = false;

        yield return new WaitForSeconds(f);

        randomIndex = randomIndexNext;

        GameObject newObject = Instantiate(blockPrefabs[randomIndex], new Vector2(0,camera.transform.position.y), Quaternion.identity);

        randomIndexNext = Random.Range(0, blockPrefabs.Length);

       // Debug.Log(randomIndexNext);

        //guzaiList.generatedObjects.Add(newObject);

        


    }

}
