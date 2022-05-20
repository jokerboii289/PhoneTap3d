using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static Spawn instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void SetAngle()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }
}
