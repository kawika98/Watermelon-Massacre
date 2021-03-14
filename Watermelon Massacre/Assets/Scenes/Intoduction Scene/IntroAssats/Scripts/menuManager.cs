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
    private KeyCode control_forward,
                    control_left,
                    control_right,
                    control_down,
                    control_rotateLeft,
                    control_rotateRight,
                    control_fire,
                    control_inventory_use1,
                    control_inventory_use2,
                    control_inventory_use3,
                    control_inventory_use4,
                    control_inventory_openMenu;//Like a pause menu in game


    //General Information
    private int general_level = 1;//Levels go from 1-10
    private bool general_NewSave = true;// False means that this save is being used and has stored data
    private float genral_health;
    private float general_score;

    //ID Info
    private string ID_profile_name;
    private bool ID_in_profile = false;
    private int ID_profile_number = -1;//Profile number (save profiles) goes from 1-3

    //UI info
    private int ui_currentScreen;
    private int ui_previousScreen;
    private Stack<int> ui_backManager = new Stack<int>();
    private bool ui_shouldRecord = true;

    //Screen Information
    private bool screen_full_or_not = true;//True means that you are in fullscreen mode

    //Shadow Information
    private string shadow_quality = "VeryHigh";//Default is VeryHigh


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
        ShadowQuailty,
        EditControls
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

    //List of public varibles

    public GameObject[,] pig = new GameObject[3,3];
}
