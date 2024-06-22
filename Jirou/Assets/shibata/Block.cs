using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    bool fall = false;
    Rigidbody2D rd;
    bool isOk = false;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        rd.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 m_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_pos.y = 0;
        RandamObject otherScript = FindObjectOfType<RandamObject>();

        //if (otherScript != null)
        //{
        //    otherScript.redy=false;
        //}

        if (!fall)
        {
            transform.position = m_pos;
            rd.velocity = Vector3.zero;
        }

        if (Input.GetMouseButtonDown(0))
        {
            fall = true;
            
        }

        if (fall && !isOk)
        {
            otherScript.redy = true;
            isOk = true;
        }
    }
}
