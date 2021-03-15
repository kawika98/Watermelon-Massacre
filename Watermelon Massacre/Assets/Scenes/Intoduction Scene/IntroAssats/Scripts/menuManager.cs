using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
 //Private Varibles
    
    //Sound
    private float sound_volume_Backround_music = 5f;//5 is default
    private float sound_volume_SFX = 5f;

    //Controls
    private int control_input_Device = 0;// Input Device = Keyboard or mouse Keyboard being 0, Mouse being 1
    private KeyCode control_forward = KeyCode.W,
                    control_left = KeyCode.A,
                    control_right = KeyCode.D,
                    control_down = KeyCode.S,
                    control_rotateLeft = KeyCode.Q,
                    control_rotateRight = KeyCode.R,
                    control_fire = KeyCode.Mouse0,
                    control_inventory_use1 = KeyCode.Alpha1,
                    control_inventory_use2 = KeyCode.Alpha2,
                    control_inventory_use3 = KeyCode.Alpha3,
                    control_inventory_use4 = KeyCode.Alpha4,
                    control_inventory_openMenu = KeyCode.Escape;//Like a pause menu in game


    //General Information
    private int general_level = 1;//Levels go from 1-10
    private bool general_NewSave = true;// False means that this save is being used and has stored data
    private float genral_health;
    private float general_score;
    private float general_diffuclty;

    //ID Info
    private string ID_profile_name;
    private bool ID_in_profile = false;
    private int ID_profile_number = -1;//Profile number (save profiles) goes from 1-3

    //UI info
    private int ui_currentScreen;
    private int ui_previousScreen;
    private Stack<int> ui_backManager = new Stack<int>();
    private bool ui_shouldRecord = true;

    //ScriptableObject info
    public holder_Information Holder1;
    public holder_Information Holder2;
    public holder_Information Holder3;

    //Screen Information
    private bool screen_full_or_not = true;//True means that you are in fullscreen mode

    //Shadow Information
    private string shadow_quality = "VeryHigh";//Default is VeryHigh
    private int currentSave;


 //List of Screenes
    
    enum Screens
    {
        Main,
        PlayScreen,
        Custom,
        Normal,
        SeeSaveInfo,
        Options,
        FullScreenOrNot,
        Sound,
        ShadowQuality,
        EditControls,
        Credits

        
    }

    //List of Key Enums (For ease of use)

    enum keys
    {
        forward,
        backward,
        left,
        right,
        fire1,
        rotateLeft,
        rotateRight,
        inventory_use1,
        inventory_use2,
        inventory_use3,
        inventory_use4,
        inventory_openMenu
    }

    [Header("MainMenu")]

    public GameObject[] Main, Credits;
    public GameObject profile_name;

    [Header("Options")]

    public GameObject[] Options;
    public GameObject[] Custom, Normal, SeeSaveInfo, FullScreenOrNot, Sound, ShadowQuality, EditControls;
    public GameObject b_forward, b_backward, b_left, b_right, b_fire1, b_rotateLeft, b_rotateRight, b_inventory_use1, b_inventory_use2, b_inventory_use3, b_inventory_use4, b_inventory_openMenu;

    [Header("Play")]

    public GameObject[] PlayScreen;

    private void Start()
    {
        ui_currentScreen = (int)Screens.Main;
        ui_previousScreen = (int)Screens.Main;
        defaultSettings();
    }

    private void Update()
    {
        if (ui_currentScreen != (int)Screens.Main)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Back();
            }
        }
    }
    
    //three scriptable object information holder
    //copy over options information 

    //List of public varibles

    public void quitGame()
    {
        Application.Quit();
        Debug.LogWarning("Quitting Game");
    }

    public void Back()
    {
        ui_shouldRecord = false;
        Open(ui_backManager.Pop());
    }

    public void Open(int toOpen)
    {
        if (ui_shouldRecord == true)
        {
            switch (ui_currentScreen)
            {
                case (int)Screens.Main:
                    ui_backManager.Push(ui_currentScreen);
                    break;
                case (int)Screens.Options:
                    ui_backManager.Push(ui_currentScreen);
                    break;
                case (int)Screens.PlayScreen:
                    ui_backManager.Push(ui_currentScreen);
                    break;
                case (int)Screens.EditControls:
                    ui_backManager.Push(ui_currentScreen);
                    break;
                case (int)Screens.SeeSaveInfo:
                    ui_backManager.Push(ui_currentScreen);
                    break;
            }
        }

        ui_shouldRecord = true;

        ui_previousScreen = ui_currentScreen;

        switch (ui_currentScreen)
        {
            case (int)Screens.Main:
                GameObjectDisable(Main);
                break;
            case (int)Screens.Custom:
                GameObjectDisable(Custom);
                break;
            case (int)Screens.Normal:
                GameObjectDisable(Normal);
                break;
            case (int)Screens.EditControls:
                GameObjectDisable(EditControls);
                break;
            case (int)Screens.SeeSaveInfo:
                GameObjectDisable(SeeSaveInfo);
                break;
            case (int)Screens.FullScreenOrNot:
                GameObjectDisable(FullScreenOrNot);
                break;
            case (int)Screens.Sound:
                GameObjectDisable(Sound);
                break;
            case (int)Screens.ShadowQuality:
                GameObjectDisable(ShadowQuality);
                break;
            case (int)Screens.Options:
                GameObjectDisable(Options);
                break;
            case (int)Screens.Credits:
                GameObjectDisable(Credits);
                break;
            default:
                Debug.LogError("Thing to open " + toOpen + " is wrong or missing");
                break;
        }

        ui_currentScreen = toOpen;

        switch (toOpen)
        {
            case (int)Screens.Main:
                GameObjectEnable(Main);
                break;
            case (int)Screens.Custom:
                GameObjectEnable(Custom);
                break;
            case (int)Screens.Normal:
                GameObjectEnable(Normal);
                break;
            case (int)Screens.EditControls:
                GameObjectEnable(EditControls);
                break;
            case (int)Screens.SeeSaveInfo:
                GameObjectEnable(SeeSaveInfo);
                break;
            case (int)Screens.FullScreenOrNot:
                GameObjectEnable(FullScreenOrNot);
                break;
            case (int)Screens.Sound:
                GameObjectEnable(Sound);
                break;
            case (int)Screens.ShadowQuality:
                GameObjectEnable(ShadowQuality);
                break;
            case (int)Screens.Options:
                GameObjectEnable(Options);
                break;
            case (int)Screens.Credits:
                GameObjectEnable(Credits);
                break;
        }

    }


    public void open_Main()
    {
        Open((int)Screens.Main);
    }
    public void open_Custom()
    {
        Open((int)Screens.Custom);
    }
    public void open_Normal()
    {
        Open((int)Screens.Normal);
    }
    public void open_SeeSaveInfo()
    {
        Open((int)Screens.SeeSaveInfo);
    }
    public void open_Options()
    {
        Open((int)Screens.Options);
    }
    public void open_FullScreenOrNot()
    {
        Open((int)Screens.FullScreenOrNot);
    }
    public void open_Sound()
    {
        Open((int)Screens.Sound);
    }
    public void open_ShadowQuality()
    {
        Open((int)Screens.ShadowQuality);
    }
    public void open_EditControls()
    {
        Open((int)Screens.EditControls);
    }
    public void open_Credits()
    {
        Open((int)Screens.Credits);
    }
    public void change_diffucilty()
    {
        general_diffuclty = Normal[1].GetComponent<Slider>().value;
    }
    public void change_name()
    {
        name = Normal[2].GetComponent<TMP_InputField>().text;
    }



    public void GameObjectEnable(GameObject[] oneToTurnOn)
    {
        foreach (GameObject egg in oneToTurnOn)
        {
            egg.SetActive(true);
        }

    }

    public void GameObjectDisable(GameObject[] oneToTurnOff)
    {
        foreach (GameObject egg in oneToTurnOff)
        {
            egg.SetActive(false);
        }
    }

    public void NewGame()
    {
        if(currentSave == 1)
        {
            save(Holder1);
            SceneManager.LoadScene(general_level);

        }
        else if(currentSave == 2)
        {
            save(Holder2);
            SceneManager.LoadScene(general_level);

        }
        else if (currentSave == 3)
        {
            save(Holder3);
            SceneManager.LoadScene(general_level);

        }
        else
        {
            Debug.LogError("There is not current save");
        }
    }

    public void defaultSettings()
    {

    }

    public void play_1()
    {
        if(Holder1.name == "default")
        {
            currentSave = 1;
            open_Normal();
        }
        else
        {
            currentSave = 1;
            open_Normal();
            Normal[1].GetComponent<Slider>().value = general_diffuclty;
            Normal[2].GetComponent<TMP_InputField>().text = name;
        }    
    }
    public void play_2()
    {
        if (Holder1.name == "default")
        {
            currentSave = 2;
            open_Normal();
        }
        else
        {
            currentSave = 2;
            open_Normal();
            Normal[1].GetComponent<Slider>().value = general_diffuclty;
            Normal[2].GetComponent<TMP_InputField>().text = name;
        }
    }
    public void play_3()
    {
        if (Holder1.name == "default")
        {
            currentSave = 3;
            open_Normal();
        }
        else
        {
            currentSave = 3;
            open_Normal();
            Normal[1].GetComponent<Slider>().value = general_diffuclty;
            Normal[2].GetComponent<TMP_InputField>().text = name;
        }
    }

    public void save(holder_Information thingToBeSaved)
    {
        thingToBeSaved.save_name = name;
        thingToBeSaved.save_number = ID_profile_number;
        thingToBeSaved.level = general_level;
        thingToBeSaved.difficulty = (int)general_diffuclty;
       // thingToBeSaved.spawnChance_relic = relic;

        //Controls
        thingToBeSaved.forward = control_forward;
        thingToBeSaved.back = control_down;
        thingToBeSaved.left = control_left;
        thingToBeSaved.right = control_right;
        thingToBeSaved.fireButton = control_fire;

        //Things not being changed 
        thingToBeSaved.rotateLeft = control_rotateLeft;
        thingToBeSaved.rotateRight = control_rotateRight;

        thingToBeSaved.inventoryUse_1 = control_inventory_use1;
        thingToBeSaved.inventoryUse_2 = control_inventory_use2;
        thingToBeSaved.inventoryUse_3 = control_inventory_use3;
        thingToBeSaved.inventoryUse_4 = control_inventory_use4;
        

       // thingToBeSaved.reload = reload;
      //  thingToBeSaved.quickSwichToWeaponOnTheLeft = quick;
       // thingToBeSaved.barrellRoll = barr;
       // thingToBeSaved.pause_and_menu = pause;

       // thingToBeSaved.weapons = ;
      // thingToBeSaved.relics = relics;
      //  thingToBeSaved.parts = parts;
      //  thingToBeSaved.currentWeapon_out = currentWeapon_out;
      //  thingToBeSaved.currentShip = currentShip;

      
    }
}
