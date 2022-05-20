using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;


public class SpawnInSpline : MonoBehaviour
{
    SplineFollower splineFollower;
    // Start is called before the first frame update
    void OnEnable()
    {
        splineFollower= gameObject.GetComponent<SplineFollower>();
        splineFollower.startPosition = RandomValue();
        splineFollower.follow = false;
    }

    float RandomValue()
    {
        var value = Random.Range(0,100);
        return (float)value / 100;
    }
}
