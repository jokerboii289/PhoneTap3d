using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class SplineMobile : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Batterylife.stop)
        {
            gameObject.GetComponent<SplineFollower>().follow = false;
        }
    }
}
