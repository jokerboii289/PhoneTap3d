using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    float timer;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        size = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.generalVariable)
        {
            gameObject.SetActive(false);
        }
        timer += 2 * Time.deltaTime;
        var value =Mathf.Abs( Mathf.Sin(timer));
        var temp = value*.2f;
        gameObject.transform.localScale=new Vector3( size+temp,size+temp,size+value);
    }

}
