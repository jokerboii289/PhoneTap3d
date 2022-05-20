using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharger : MonoBehaviour
{
   
    public static SpawnCharger instance;
    [SerializeField] GameObject chargerPoint;
   
    public bool spawn;
    int count;

    //when spline used
    [SerializeField] bool splineUse;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        spawn = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawn && count<=0 && !splineUse && !Batterylife.stop)
        {           
            chargerPoint.SetActive(true);
            count++;
        }
    }

    public void DisableCharger()
    {
        spawn = false;
        count = 0;
    }

}
