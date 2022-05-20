using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChargePointSpawn : MonoBehaviour
{
    int count;
    [SerializeField] GameObject batteryLowScreeen;
    [SerializeField] GameObject lowestBatteryScreen;
    [SerializeField] GameObject effectOfCharging;
    bool canDestroy;
    private void Awake()
    {
        count = 0;
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        canDestroy = false;
        if (count >= 1)
        {
            Spawn.instance.SetAngle();
        }
        count++;
    }

    private void Update()
    {   
        if(Input.touchCount>0 && Input.GetTouch(0).phase== TouchPhase.Ended)
        {
            if(canDestroy)
                StartCoroutine(Delay());
            else if(!canDestroy)
            {
                PauseMenu.instance.Fail();// cannot destroy the charger
            }
        }
    }
    
    IEnumerator Delay()
    {
        AudioManager.instance.Play("charging");
        batteryLowScreeen.SetActive(false);
        lowestBatteryScreen.SetActive(true);
        Effect();
        yield return new WaitForSeconds(0f);
        SpawnCharger.instance.DisableCharger();
        Batterylife.instance.BatteryDeplete();
       // Vibration.Vibrate(27);//vibrate
        gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("phone"))
        {
            canDestroy = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("phone"))
        {
            canDestroy = false;
        }
    }

    void Effect()
    {
        var obj = ObjectPooling.instance.GetFromPool(effectOfCharging);
        if(obj!=null)
        {
            obj.transform.position = transform.position;
        }
    }

}
