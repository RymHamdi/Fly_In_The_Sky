using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    HeaderAttribute LevelUI;
   // public GameObject level_1, level_2, level_3, level_4, level_5;
    public int level_1_1=0,level_1_2=0, level_1_3 = 0, level_1_4=0,level_1_5,level_1_6;
    public GameObject EditorCamera;
    public GameObject drone1;
    public Transform level1_pos,level2_pos, level3_pos, level4_pos,level5_Pos, level6_Pos;
    public GameObject L1_step1_arrows, L1_step2_arrows;
    public GameObject L2_step1_arrows, L2_step2_arrows;
    public GameObject L3_step1_arrows;
    public GameObject L4_step1_arrows, L4_step2_arrows, L4_step3_arrows, L4_step4_arrows;
    public GameObject L5_step1_arrows;
    public GameObject L6_step1_arrows,L6_step2_arrow;
    public GameObject Ground_1,Ground_2;
    public GameObject Level_2Obj;
    public GameObject droneClone1_1, droneClone1_2, droneClone1_3, droneClone1_4, droneClone1_5,droneClone1_6;
    public GameObject myCame;

    public List<DroneBehavior> droneBehaviors;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if(instance != null) {
            Destroy(gameObject);
        }

    }
    
    

    private void Start()
    {
        UIManager.instance.l1start();
       
        

    }
    public void level_1()
    {
        level_1_1 = level_1_1 + 1;
        switch (level_1_1)
        {
            case 1:
                Debug.Log("Level ==" + level_1_1);
                L1_step1_arrows.SetActive(false);
                L1_step2_arrows.SetActive(true);
                break;
            case 2:
                Debug.Log("Level ==" + level_1_1);
                GlobalTimer.Instance.StopTimerAndRecord();
                UIManager.instance.Level1_endUI();
               // UIManager.instance.Level_1_Step2_Start();
                Destroy(droneClone1_1);
                level2Start();
                //Success logic
                break;
            
        }
    }
    public void level2Start()
    {
        level2_pos.gameObject.SetActive(true);
        droneClone1_2 = Instantiate(drone1, level2_pos.transform);
        level_2();
    }

    public void level_2()
    {
        level_1_2 = level_1_2 + 1;
        switch (level_1_2)
        {
            case 1:
                L2_step1_arrows.SetActive(true);
                L2_step2_arrows.SetActive(false);
                break;
            case 2:
                GlobalTimer.Instance.StopTimerAndRecord();
                L2_step1_arrows.SetActive(false);
                L2_step2_arrows.SetActive(true);
                break;
            case 3:
                GlobalTimer.Instance.StopTimerAndRecord();
                Destroy(droneClone1_2);
                UIManager.instance.Level2_endUI();
                level3Start();
                break;
               
        }
    }
    public void level3Start()
    {
        level3_pos.gameObject.SetActive(true);
        droneClone1_3 = Instantiate(drone1, level3_pos.transform);
        level_3();
    }
    public void level_3()
    {
        level_1_3 = level_1_3 + 1;
        switch (level_1_3)
        {
            case 1:
                L3_step1_arrows.SetActive(true);
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                GlobalTimer.Instance.StopTimerAndRecord();
                UIManager.instance.Level3_endUI();
                level4Start();
                Destroy(droneClone1_3);
          //      UIManager.instance.traning3();
                break;

        }
    }
    public void level4Start()
    {
        level4_pos.gameObject.SetActive(true);
        droneClone1_4 = Instantiate(drone1, level4_pos.transform);
        level_4();
    }
    public void level_4()
    {
        level_1_4 = level_1_4 + 1;
        switch (level_1_4)
        {
            case 1:
                L4_step1_arrows.SetActive(true);
                L4_step2_arrows.SetActive(false);
                L4_step3_arrows.SetActive(false);
                L4_step4_arrows.SetActive(false);
                break;
            case 2:
                L4_step1_arrows.SetActive(false);
                L4_step2_arrows.SetActive(true);
                L4_step3_arrows.SetActive(false);
                L4_step4_arrows.SetActive(false);
                break;
            case 3:
                L4_step1_arrows.SetActive(false);
                L4_step2_arrows.SetActive(false);
                L4_step3_arrows.SetActive(true);
                L4_step4_arrows.SetActive(false);
                break;
            case 4:
                L4_step1_arrows.SetActive(false);
                L4_step2_arrows.SetActive(false);
                L4_step3_arrows.SetActive(false);
                L4_step4_arrows.SetActive(true);
                break;
            case 5:
                GlobalTimer.Instance.StopTimerAndRecord();
                L4_step4_arrows.SetActive(false);
                UIManager.instance.Level4_endUI();
                Destroy(droneClone1_4);
                level5Start();
                break;

        }

    }
    public void level5Start()
    {
        Ground_1.SetActive(false);
        Ground_2.SetActive(true);
        level5_Pos.gameObject.SetActive(true);
        droneClone1_5 = Instantiate(drone1, level5_Pos.transform);
        level_5();
    }
    public void level_5()
    {
        level_1_5 = level_1_5 + 1;
        switch (level_1_5)
        {
            case 1:
                L5_step1_arrows.SetActive(true);
                break;
            case 5:
                GlobalTimer.Instance.StopTimerAndRecord();
                UIManager.instance.Level5_endUI();
                level6Start();
                Destroy(droneClone1_5);
                break;
        }
    }
    public void level6Start()
    {
        level6_Pos.gameObject.SetActive(true);
        droneClone1_6 = Instantiate(drone1, level6_Pos.transform);
        level_6();
    }
    public void level_6()
    {
        level_1_6 = level_1_6 + 1;
        switch (level_1_6)
        {
            case 1:
                L6_step1_arrows.SetActive(true);
                L6_step2_arrow.SetActive(false);
                break;
            case 2:
                L6_step1_arrows.SetActive(false);
                L6_step2_arrow.SetActive(true);
                break;
            case 3:
                GlobalTimer.Instance.StopTimerAndRecord();
                UIManager.instance.Level6_endUI();
                Destroy(droneClone1_5);
                break;
        }
    }

    //    public void Level2_steps()
    //{
    //    lvl2 = lvl2 + 1;
    //    switch (lvl2)
    //    {
    //        case 1:

    //            Lvl2_arrows1.SetActive(true);
    //            Lvl2_arrows2.SetActive(false);
    //            break;
    //        case 2:
    //            GlobalTimer.Instance.StopTimerAndRecord();
    //            Lvl2_arrows1.SetActive(false);
    //            Lvl2_arrows2.SetActive(true);
    //            break;
    //        case 3:
    //            //level End
    //            GlobalTimer.Instance.StopTimerAndRecord();
    //           // UIManager.instance.traning5();
    //          //  Destroy(droneClone2_1);
    //            break;
    //    }
    //}
    //public void Level3_steps()
    //{
    //    // level 3 




    //}

    //private void level_1Step_2()
    //{
    //    myCame.SetActive(true);
    //    UIManager.instance.trainng();
    //}
    //public void Level2_Complete()
    //{
    //    //Code for After level complete 
    //}


    ////private void level_1Step_3()
    ////{
    ////    myCame.SetActive(true);
    ////    UIManager.instance.trainng2();
    ////}
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    private void OnEnable()
    {
        Destroy(EditorCamera);
        foreach (var item in droneBehaviors)
        {
            if (item.GetDrone() != null)
            {
                drone1 = item.DroneObj;
            }
        }
        droneClone1_1 = Instantiate(drone1, level1_pos);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class DroneBehavior
{
    public string DroneName;
    public GameObject DroneObj;

    public GameObject GetDrone()
    {
        if (PlayerPrefs.GetString("currentDrone") == DroneName)
        {
            return DroneObj;
        }
        return null;
    }
}