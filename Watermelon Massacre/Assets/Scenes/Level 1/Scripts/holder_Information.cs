using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Information/data_player", order = 1)]
public class holder_Information : ScriptableObject
{
    [Header("Id Information")]
 
    public string save_name = "default";//Id
    public int save_number = -1;//Number of save file you are in 1-3 (Only Three save files in total)
    public int level = -1;//Current Level user is on
    public int difficulty = 5;//One number used to describe diffictly From 1(Easy) to 10(Immpossible)
    public int spawnChance_relic = 5;//Default is 5 lowest is 1(Bad Relics Only) to 10(Legendary Relics Only), NOTE : Relics go from Basic,Rare,Epic,Legendary

    [Header("Controls")]

    public KeyCode forward = KeyCode.W;
    public KeyCode back = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode fireButton = KeyCode.Mouse0;

    //Under me we are not changing for now
    public KeyCode inventoryUse_1 = KeyCode.Keypad1;//This button is on the top of the keyboard
    public KeyCode inventoryUse_2 = KeyCode.Keypad2;//This button is on the top of the keyboard
    public KeyCode inventoryUse_3 = KeyCode.Keypad3;//This button is on the top of the keyboard
    public KeyCode inventoryUse_4 = KeyCode.Keypad4;//This button is on the top of the keyboard

    public KeyCode reload = KeyCode.R;
    public KeyCode quickSwichToWeaponOnTheLeft = KeyCode.F;
    public KeyCode barrellRoll = KeyCode.Space;
    public KeyCode pause_and_menu = KeyCode.Escape;
    public KeyCode rotateLeft = KeyCode.Q;
    public KeyCode rotateRight = KeyCode.E;

    [Header("PlayerInformation")]

    public List<GameObject> weapons = null;//You must change this later to the base Weapons Class
    public List<GameObject> relics = null;//You must change this later to the base Relics Class
    public int parts = 0;//Parts is the currency to buy things from the shop
    public GameObject currentWeapon_out = null;//You must change this later to the base Weapons Class
    public GameObject currentShip = null;//You must change this later to the base Ships Class
    public int goldenWatermelons_collected = 0;//Might not be used in current build of game due to time constraints

    //Later down the line when we add unlockables you must add that information under this comment

    //NOTE In the handeler for this method, you will need to add a few methods to it setRawData(holder_Information passedSave) set the rawData from a save to passed save (Also must change the values that are -1 or null if possible)
    
    public bool save(holder_Information thingToBeSaved)
    {
        //Will return true if did well or false if it did not go well
        //This will save thingsToBeSaved to the current save you are in


        return false;
    }

    public bool createFreshSave()
    {
        //Will return true if did well or false if it did not go well
        //Will make this file a brand new save (Changes values does not create a new holder_Information)
        return false;
    }

    public bool resetSave()
    {
        //Will return true if did well or false if it did not go well
        //This method will create a new scritableHolderInformation. Then when this method is called it will set its information to the scritableHolderInformation information


        return false;
    }


}