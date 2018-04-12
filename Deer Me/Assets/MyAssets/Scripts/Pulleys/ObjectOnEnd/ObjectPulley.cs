﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPulley : MonoBehaviour {


    //1= side that player is on
    //2= side player is moving

    public bool onPlatform_1;

    //platforms
    public GameObject plat_1;
    public GameObject obj;

    //ropes attached to platforms
    public GameObject rope_1;
    public GameObject rope_2;

    public Transform start_1;
    public Transform start_2;

    //where platforms end
    public Transform end_1;
    public Transform end_2;

    public float speed_1 = 0.5f;
    public float speed_2 = 0.5f;

    //scale the role ends
    public Vector3 finalScale_1;
    public Vector3 finalScale_2;


    Vector3 temp_1 =  new Vector3(1,1,1);
    Vector3 temp_2 =  new Vector3(1,1,1);


    // Update is called once per frame
    void Update () 
    {
        if (onPlatform_1)
        {
            MoveToEnd();
        }
    }

    void MoveToEnd()
    {
        if (plat_1.transform.position != end_1.position)
        {
            plat_1.transform.position = Vector3.MoveTowards(plat_1.transform.position, end_1.position, Time.deltaTime);
        }

        if (obj.transform.position != end_2.position)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, end_2.position, Time.deltaTime);
        }

        if (temp_1.y != finalScale_1.y)
        {
            temp_1 = Vector3.MoveTowards(temp_1, finalScale_1, speed_1 * Time.deltaTime);
            rope_1.transform.localScale = temp_1;      

        }

        if (temp_2.y != finalScale_2.y)
        {
            temp_2 = Vector3.MoveTowards(temp_2, finalScale_2, speed_2 * Time.deltaTime);
            rope_2.transform.localScale = temp_2;      

        }
            
    }

    void MoveToStart()
    {
        //check if platform has made it to final position
        if (plat_1.transform.position != start_1.position)
        {
            plat_1.transform.position = Vector3.MoveTowards(plat_1.transform.position, start_1.position, Time.deltaTime);
        }
        if (temp_1.y != 1f)
        {
            temp_1 = Vector3.MoveTowards(temp_1, Vector3.one, speed_1 * Time.deltaTime);
            rope_1.transform.localScale = temp_1;      

        }
        if (obj.transform.position != start_2.position)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, start_2.position, Time.deltaTime);
        }

        if (temp_2.y != 1f)
        {
            temp_2 = Vector3.MoveTowards(temp_2, Vector3.one, speed_2 * Time.deltaTime);
            rope_2.transform.localScale = temp_2;      

        }
    }
}