using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Block : MonoBehaviour
{
    bool fall = false;
    Rigidbody2D rd;
    bool isOk = false;
    public int score = 100;
    // Start is called before the first frame update
    GuzaiList guzaiList;
    Vector2 m_pos;
    GameObject camera;
    public float speed = 0.004f;
    bool already = false;
    GameObject guzaiListObject;
    int num;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        rd.velocity = Vector3.zero;
        guzaiListObject = GameObject.Find("GameManager");
        camera = GameObject.Find("Main Camera");
        m_pos = Vector2.zero;

        if (guzaiListObject != null)
        {
            guzaiList = guzaiListObject.GetComponent<GuzaiList>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_pos.x -= speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_pos.x += speed;
        }

      
        RandamObject otherScript = FindObjectOfType<RandamObject>();

        //if (otherScript != null)
        //{
        //    otherScript.redy=false;
        //}

        if (!fall)
        {
            m_pos.y = camera.transform.position.y + 4;
            transform.position = m_pos;
            rd.velocity = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            if(!fall)
            {
                gameObject.tag = "Guzai";
            }
            fall = true;

        }
        if (fall && !isOk)
        {
            otherScript.redy = true;
            isOk = true;
            
        }

        if(transform.position.y <= -8)
        {
            if (already)
            {
                guzaiList.DeleteList(num);
            }
            Destroy(gameObject);
        }
    }

    public int AddScore()
    {
        return score;
    }

    /// <summary>
    /// 
    /// </summary>
    public void EatProc()
    {


        Destroy(this);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!already && fall)
        {
            num = guzaiList.AddList(gameObject);
            num -= 1;
            Debug.Log(num);
            already =true;
        }
    }



}

