using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Batterylife : MonoBehaviour
{
    [SerializeField] GameObject chargingBatteryImage;
    [SerializeField] TextMeshProUGUI batteryPercent;
    [SerializeField] GameObject batteryFill;
    float originalCount;

    [SerializeField] GameObject camera;
    [SerializeField] float divider;
    [SerializeField] GameObject slider;
    
    public static Batterylife instance;
    [SerializeField]
    TextMeshProUGUI batteryText;
    [SerializeField] int countBattery;
    public static bool stop;
    // Start is called before the first frame update
    void Start()
    {
        chargingBatteryImage.SetActive(false);
        originalCount = countBattery;
        stop = false;
        instance = this;
        batteryText.text = countBattery.ToString();
    }
   
    public void BatteryDeplete()
    {
        chargingBatteryImage.SetActive(true);
        slider.GetComponent<Image>().fillAmount =1-(countBattery / divider)+1/divider;
        batteryFill.GetComponent<Image>().fillAmount = 1 - (countBattery / divider) + 1 / divider;   
        countBattery--;
        if (countBattery >= 0)
        {
            batteryText.text = countBattery.ToString();
            batteryPercent.text =(100- ((countBattery / originalCount)*100))+"%".ToString();
        }
        if(countBattery==0)
        {
            StartCoroutine(Delay());   
        }
    }

    IEnumerator Delay()
    {
        PauseMenu.instance.Win();//win panel
        stop=true;
        yield return new WaitForSeconds(1.5f);
        batteryText.text = " ".ToString();
        camera.SetActive(false);
    }
}
