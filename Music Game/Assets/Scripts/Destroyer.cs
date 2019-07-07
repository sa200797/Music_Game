﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag ==  "Player")
        {
            return;
        }
        else
        {
            Destroy(col.gameObject);
        }
       
    }

}