using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;
    public GameObject level1UI;
    public GameObject level_1_Map_1, level_1_Map_2, level_1_Map_3; //level_1_Map_3, level_1_Map_4;
    public Image L1Map1A, L1Map1B, L1Map1C, L1Map1D;
    public Sprite Red, Green, Orange;
    public Image FadeImg;
    public GameObject HistryUi,TimerUI;
    public GameObject endstep1, endstep2;

    public GameObject l1map, l2map, l3map, l4map, l5map, l6map,l1Ins,l2ins,l3ins,l4ins,l5ins,l6ins;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

    }

    public void l1start()
    {
        l1map.SetActive(true);
        l1Ins.SetActive(true);
    }
    public void Level1_step1UI()
    {
        level1UI.SetActive(true);
        level_1_Map_1.SetActive(true);
    }
    public void Level1_endUI()
    {
        GlobalTimer.Instance.DisplayLastRecordedTime();
        HistryUi.SetActive(true);
        l1map.SetActive(false);
        l1Ins.SetActive(false);
        l2map.SetActive(true);
        l2ins.SetActive(true);
        //L1Map1B.sprite = Green;
        //L1Map1C.sprite = Orange;
        //L1Map1D.sprite = Red;
    }
    public void Level2_endUI()
    {
        GlobalTimer.Instance.DisplayLastRecordedTime();
        HistryUi.SetActive(true);
        l2map.SetActive(false);
        l2ins.SetActive(false);
        l3map.SetActive(true);
        l3ins.SetActive(true);
    }
    public void Level3_endUI()
    {
        GlobalTimer.Instance.DisplayLastRecordedTime();
        HistryUi.SetActive(true);
        l3map.SetActive(false);
        l3ins.SetActive(false);
        l4map.SetActive(true);
        l4ins.SetActive(true);
    }
    public void Level4_endUI()
    {
        GlobalTimer.Instance.DisplayLastRecordedTime();
        HistryUi.SetActive(true);
        l4map.SetActive(false);
        l4ins.SetActive(false);
        l5map.SetActive(true);
        l5ins.SetActive(true);
    }
    public void Level5_endUI()
    {
        GlobalTimer.Instance.DisplayLastRecordedTime();
        HistryUi.SetActive(true);
        l5map.SetActive(false);
        l5ins.SetActive(false);
        l6map.SetActive(true);
        l6ins.SetActive(true);
    }
    public void Level6_endUI()
    {
        GlobalTimer.Instance.DisplayLastRecordedTime();
        HistryUi.SetActive(true);
        endstep1.SetActive(true);
        
    }
    public void Level_1_Step1_Complete()
    {
        GlobalTimer.Instance.DisplayLastRecordedTime();
        HistryUi.SetActive(true);
        FadeImg.gameObject.SetActive(true);
        StartCoroutine(FadeIn(FadeImg));
        level_1_Map_1.SetActive(false);
    }
    public void TimerScreen()
    {
        TimerUI.SetActive(true);
    }
    public void Level_2_Start()
    {
        
        StartCoroutine(FadeOut(FadeImg));
        level_1_Map_2.SetActive(true);
        level_1_Map_1.SetActive(false);
        endstep2.SetActive(false);
    }
    public void Level_1_Step3_Start()
    {
        StartCoroutine(FadeOut(FadeImg));
        level_1_Map_2.SetActive(true);
        level_1_Map_1.SetActive(false);
        level_1_Map_3.SetActive(true);
        endstep2.SetActive(false);
        GameManager.instance.level_3();
    }
    public void Level_1_Step4_Start()
    {
        StartCoroutine(FadeOut(FadeImg));
        level_1_Map_2.SetActive(true);
        level_1_Map_1.SetActive(false);
        level_1_Map_3.SetActive(true);
        endstep2.SetActive(false);
        GameManager.instance.level_4();
    }
    public void Level2_Start()
    {
        StartCoroutine(FadeOut(FadeImg));
        endstep2.SetActive(false);
       // GameManager.instance.Level2_steps();
        //Level 2 start logic
    }
    public void Level3_Start()
    {
        StartCoroutine(FadeOut(FadeImg));
        endstep2.SetActive(false);
     //   GameManager.instance.Level3_steps();
        //Level 2 start logic
    }
    private YieldInstruction fadeInstruction = new YieldInstruction();
    IEnumerator FadeOut(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < 2)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / 2);
            image.color = c;
        }
        image.gameObject.SetActive(false);
    }
    IEnumerator FadeIn(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < 2)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / 2);
            image.color = c;
        }
    }
    public void pause()
    {
        Time.timeScale =0;

    }
    public void play()
    {
        Time.timeScale = 1;
    }
    public void restart()
    {
        SceneManager.LoadScene(1);
    }

    public void exit()
    {
        Application.Quit();
    }
    //public void trainng()
    //{
    //    FadeImg.gameObject.SetActive(true);
    //    StartCoroutine(endTrainging());
    //}
    //public void traning2()
    //{
    //    FadeImg.gameObject.SetActive(true);
    //    StartCoroutine(endTrainging2());
    //}
    //public void traning3()
    //{
    //    FadeImg.gameObject.SetActive(true);
    //    StartCoroutine(endTrainging3());
    //}
    //public void traning4()
    //{
    //    FadeImg.gameObject.SetActive(true);
    //    StartCoroutine(endTrainging4());
    //}
    //public void traning5()
    //{
    //    FadeImg.gameObject.SetActive(true);
    //    StartCoroutine(endTrainging5());
    //}
    //public IEnumerator endTrainging()
    //{
    //    endstep1.SetActive(true);
    //    endstep2.SetActive(false);
    //    yield return new WaitForSeconds(3.0f);
    //    endstep1.SetActive(false);
    //    endstep2.SetActive(true);
    //    yield return new WaitForSeconds(3.0f);
    //    StartCoroutine(FadeIn(FadeImg));
    //    Level_1_Step2_Start();
    //    GameManager.instance. level1_pos2.gameObject.SetActive(true);
    //    GameManager.instance.droneClone1_2 = Instantiate(GameManager.instance.drone1, GameManager.instance.level1_pos2.transform);
    //    GameManager.instance.level_1Step2();
    //}
    //public IEnumerator endTrainging2()
    //{
    //    endstep1.SetActive(true);
    //    endstep2.SetActive(false);
    //    yield return new WaitForSeconds(3.0f);
    //    endstep1.SetActive(false);
    //    endstep2.SetActive(true);
    //    yield return new WaitForSeconds(3.0f);
    //    StartCoroutine(FadeIn(FadeImg));
    //    Level_1_Step3_Start();
    //    GameManager.instance.level1_pos3.gameObject.SetActive(true);
    //    GameManager.instance.droneClone1_3 =Instantiate(GameManager.instance.drone1, GameManager.instance.level1_pos3.transform);
    //  //  GameManager.instance.level_1Step3();
    //}
    //public IEnumerator endTrainging3()
    //{
    //    endstep1.SetActive(true);
    //    endstep2.SetActive(false);
    //    yield return new WaitForSeconds(3.0f);
    //    endstep1.SetActive(false);
    //    endstep2.SetActive(true);
    //    yield return new WaitForSeconds(3.0f);
    //    StartCoroutine(FadeIn(FadeImg));
    //    Level_1_Step4_Start();
    //    GameManager.instance.level1_pos4.gameObject.SetActive(true);
    //    GameManager.instance.droneClone1_4 =Instantiate(GameManager.instance.drone1, GameManager.instance.level1_pos4.transform);
    //  //  GameManager.instance.level_1Step3();
    //}
    //public IEnumerator endTrainging4()//Level1-step 4 ending
    //{
    //    endstep1.SetActive(true);
    //    endstep2.SetActive(false);
    //    yield return new WaitForSeconds(3.0f);
    //    endstep1.SetActive(false);
    //    endstep2.SetActive(true);
    //    yield return new WaitForSeconds(3.0f);
    //    StartCoroutine(FadeIn(FadeImg));
    //    Level2_Start();
    //    GameManager.instance.Level2_Pos.gameObject.SetActive(true);
    //    GameManager.instance.droneClone2_1 =Instantiate(GameManager.instance.drone1, GameManager.instance.Level2_Pos.transform);
    //    GameManager.instance.Level_2Obj.SetActive(true);
    //    //  GameManager.instance.level_1Step3();
    //}
    //public IEnumerator endTrainging5()//Level2 end
    //{
    //    endstep1.SetActive(true);
    //    endstep2.SetActive(false);
    //    yield return new WaitForSeconds(3.0f);
    //    endstep1.SetActive(false);
    //    endstep2.SetActive(true);
    //    yield return new WaitForSeconds(3.0f);
    //    StartCoroutine(FadeIn(FadeImg));
    //    Level3_Start();
    //    GameManager.instance.Level3_Pos.gameObject.SetActive(true);
    //    GameManager.instance.droneClone2_1 = Instantiate(GameManager.instance.drone1, GameManager.instance.Level3_Pos.transform);
    //    GameManager.instance.Level_2Obj.SetActive(true);
    //    //  GameManager.instance.level_1Step3();
    //}


    public void Level2_Complete()
    {
        //Code for After level complete 
    }
}
