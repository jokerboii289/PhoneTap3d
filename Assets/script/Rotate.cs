using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    
    void Update()
    {
        if(!Batterylife.stop)
           transform.RotateAround(transform.up, rotateSpeed * Time.deltaTime);
    }
}
