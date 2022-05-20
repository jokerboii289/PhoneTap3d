using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject batteryImage;
    [SerializeField] GameObject phoneDestroyParticle;
    [SerializeField] GameObject failPanel;
    [SerializeField] GameObject winPanel;
    public static PauseMenu instance;
    public static bool generalVariable;
    private void Start()
    {
        generalVariable = false;
        Application.targetFrameRate = 120;
        QualitySettings.vSyncCount = 0;
        failPanel.SetActive(false);
        winPanel.SetActive(false);
        instance = this;

        Vibration.Init();
    }

    public void Fail()
    {
        var player = GameObject.FindGameObjectWithTag("phone").gameObject;
        Instantiate(phoneDestroyParticle, player.transform.position, Quaternion.identity);
        player.SetActive(false);
        
        StartCoroutine(DelayFailpanel());
    }
    public void Win()
    {
        batteryImage.SetActive(false);
        StartCoroutine(DelayWinpanel());
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
     public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    
    IEnumerator DelayFailpanel()
    {
        generalVariable = true;
        yield return new WaitForSeconds(1.5f);
        AudioManager.instance.Play("fail");
        failPanel.SetActive(true);
    }
    IEnumerator DelayWinpanel()
    {
        generalVariable = true;
        yield return new WaitForSeconds(3.5f);
        AudioManager.instance.Play("win");
        winPanel.SetActive(true);
    }
}
