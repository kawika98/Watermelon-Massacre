/*using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private int howManyPlayers;
    private string path;
    public int level_on;
    public float speed = 5f;
    public Camera camera;
    public spawn_InformationHolder spawn_data;



    [Header("Player 1")]
    //Identifier
    private int player1_identifier_Password;
    private string player1_identifier_Name;
    public GameObject player1_gameObject;
    private Rigidbody player1_rigidbody;
    public ParticleSystem[] player1_thrusters;

    private float player1_zPostion_start;
    private GameObject player1_partner;
    private GameObject player1_inventory_textlastText = null;

    //Controls
    private int player1_controls_MouseOrKeyboard;//0 is mouse, 1 is keyboard
    private KeyCode player1_controls_Forward;
    private KeyCode player1_controls_Backward;
    private KeyCode player1_controls_Left;
    private KeyCode player1_controls_Right;
    private KeyCode player1_controls_Fire1;
    private KeyCode player1_controls_RotateLeft;
    private KeyCode player1_controls_RotateRight;

    private KeyCode player1_controls_inventory_use1;
    private KeyCode player1_controls_inventory_use2;
    private KeyCode player1_controls_inventory_use3;
    private KeyCode player1_controls_inventory_use4;
    private KeyCode player1_controls_inventory_user_CloseAndOpen;

    //Inventory
    private LinkedList<GameObject> player1_inventory_Inventory = new LinkedList<GameObject>();
    public GameObject player1_inventory_currentItem;
    public GameObject[] player1_inventory_show;

    //Level
    static public int player1_level_Level;

    //Health
    private double player1_health;
    public TextMesh player1_health_text;

    //Score
    private double player1_score_Score;

    //ScreenOptions
    static public float player1_screenOptions_BackRoundMusicVolume;
    private bool player1_screenOptions_FullScreenedOrBordered;
    static public float player1_screenOptions_SFXvolume;
    private string player1_screenOptions_ShadowQuailty;

    [Header("Player 2")]
    //Identifier
    private int player2_identifier_Password;
    private string player2_identifier_Name;
    public GameObject player2_gameObject;
    private Rigidbody player2_rigidbody;


  //  private float player2_health;
    private float player2_zPostion_start;
    private GameObject player2_partner;
    private GameObject player2_inventory_textlastText = null;



    //Controls
    private int player2_controls_MouseOrKeyboard;
    private KeyCode player2_controls_Forward;
    private KeyCode player2_controls_Backward;
    private KeyCode player2_controls_Left;
    private KeyCode player2_controls_Right;
    private KeyCode player2_controls_Fire1;
    private KeyCode player2_controls_RotateLeft;
    private KeyCode player2_controls_RotateRight;

    private KeyCode player2_controls_inventory_use1;
    private KeyCode player2_controls_inventory_use2;
    private KeyCode player2_controls_inventory_use3;
    private KeyCode player2_controls_inventory_use4;
    private KeyCode player2_controls_inventory_user_CloseAndOpen;

    //Inventory
    private LinkedList<GameObject> player2_inventory_Inventory = new LinkedList<GameObject>();
    public GameObject player2_inventory_currentItem;
    public GameObject[] player2_inventory_show;



    //Level
    private int player2_level_Level;

    //Health
    private double player2_health;

    //Score
    private double player2_score_Score;

    //ScreenOptions
    private float player2_screenOptions_BackRoundMusicVolume;
    private bool player2_screenOptions_FullScreenedOrBordered;
    private float player2_screenOptions_SFXvolume;
    private string player2_screenOptions_ShadowQuailty;


    private enum Level
    {
        level_oneStarting,
        level_twoHell,
        level_threeDeadlyFlowers,
        level_fourPig,
        level_fiveBoss,
        level_shop
    }
    void Start()
    {
        player1_defaultSettings();
        load_ProfileData(1);
        //LoadLevel(player1_level_Level);

      

        player_inventory_Load(1);
        player1_level_Level = level_on;
            

        
 
      




        //Load users controll type
        //Change SFX and backround volume to what user wants
        //


        //player2_rigidbody = player2_gameObject.GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        player_move(player1_gameObject, player1_rigidbody, 1, true);
        player_inventory_checkForInventoryButtonPress(1);
        player_useInventory(1);
        // Debug.Log(player1_inventory_show[3].GetComponent<TextMeshProUGUI>().text.Length);

        amIdead();

        if(Input.GetKeyDown(player1_controls_inventory_user_CloseAndOpen))
        {
            if(player1_inventory_show[0].activeSelf == true)
            {
                player1_inventory_show[0].SetActive(false);

            }
            else if(player1_inventory_show[0].activeSelf == false)
            {
                player1_inventory_show[0].SetActive(true);
            }
        }





    }

    public void amIdead()
    {
        if(player1_health <= 0 && player2_health <= 0)
        {
            quitTheGame();

        }
    }

    public void quitTheGame()
    {
                   saveProfile();
         SceneManager.LoadScene(1);



    }

    public void saveProfile()
    {
        
            //1st Part Of The code will make a StreamWriter and StreamReader with each their own files (temp.txt is delated if it is there)
            string path = Application.dataPath + "/StreamingAssets/data.txt";
            string data = File.ReadAllText(path);
            StreamReader reader = new StreamReader(path);


            if (File.Exists(Application.dataPath + "/StreamingAssets/temp.txt"))
            {
                File.Delete(Application.dataPath + "/StreamingAssets/temp.txt");
            }

            StreamWriter writer = new StreamWriter(Application.dataPath + "/StreamingAssets/temp.txt");
            string temp = "";

        Debug.Log("IT RANNS");


            //Will check if the password exits and that data.txt exists
            if (System.IO.File.Exists(path) == true)
            {
                if (data.Contains(player1_identifier_Password.ToString()))
                {
                    //Debug.Log(profile_password);
                    //2nd Part Of Code Will Copy all the contents of the data file to the temp file untill it hits the correct password
                    bool equalsOnce = true;
                    bool tempStop = false;
                    while (tempStop == false)
                    {
                        temp = reader.ReadLine();
                        Debug.Log(temp);
                        if (temp == null || temp == "")
                        {
                            if (equalsOnce == true)
                            {
                                temp = "=" + player1_identifier_Password.ToString();
                                equalsOnce = false;
                            }
                        }
                        else if (temp[0] == '=')
                        {
                            if (equalsOnce == true)
                            {
                                temp = "=" + player1_identifier_Password.ToString();
                                equalsOnce = false;
                            }
                        }
                        else if (temp.Contains(player1_identifier_Password.ToString()))
                        {
                            tempStop = true;
                        }
                        writer.WriteLine(temp);
                    }


                    tempStop = false;

                    //This Loop will readThePofile data from data.txt and copy that into temp.txt
                    while (tempStop == false)
                    {
                        temp = reader.ReadLine();
                        Debug.Log(temp);

                        if (temp == null || temp == "")
                        {
                            writer.WriteLine("");
                        }
                        else if(temp.Contains("Inventory"))
                        {
                        writer.WriteLine("//Inventory");
                        Debug.Log("PENIS");
                        LinkedListNode<GameObject> bob = null;

                        if (player1_inventory_Inventory.Count > 0)
                        {
                            bob = player1_inventory_Inventory.First;

                        }

                        if(level_on != 0)
                        {
                            for (int i = 0; i < player1_inventory_Inventory.Count; i++)
                            {

                                switch (bob.Value.name)
                                {

                                    case ("gun_bullet_autoTarget"):
                                        //  writer.WriteLine("'gun_bullet_autoTarget',gun_bullet_autoTarget;");
                                        break;
                                    case ("gun_Bullet_growth"):
                                        //  writer.WriteLine("'gun_Bullet_growth',gun_Bullet_growth;");
                                        break;
                                    case ("gun_normal"):
                                        //writer.WriteLine("'gun_normal',gun_normal;");
                                        break;
                                    case ("health_10"):
                                        writer.WriteLine("'health_10',health_10;");
                                        break;
                                    case ("health_20"):
                                        writer.WriteLine("'health_20',health_20;");
                                        break;
                                    case ("health_30"):
                                        writer.WriteLine("'health_30',health_30;");
                                        break;
                                }

                                if (bob.Next != null)
                                {
                                    bob = bob.Next;
                                }

                            }
                        }              



                        }
                        else if (temp[0] == '\'')
                        {
                            int start = temp.IndexOf(',');
                            int end = temp.IndexOf(';');

                            end = end - start - 1;

                            readProfilsData(temp.Substring(temp.IndexOf('\'') + 1, temp.LastIndexOf('\'') - 1), temp.Substring(temp.IndexOf(',') + 1, end), ref writer);
                        }
                        else if (temp[0] == '/')
                        {
                            writer.WriteLine(temp);
                        }
                        else if (temp[0] == '?')
                        {
                            writer.WriteLine(temp);
                            tempStop = true;
                        }

                    }

                    //This code will check there is anything else in data that needs to be copyied over to temp, if there is nothing left then writer and reader will stop
                    tempStop = false;
                    if (temp == "?Done")
                    {
                        reader.ReadLine();
                        temp = reader.ReadLine();
                        if (String.IsNullOrEmpty(temp))
                        {

                            tempStop = true;
                        }
                        else
                        {
                            writer.WriteLine("");
                        }
                    }

                    //If there is stuff still to copy over it will copy the rest of it over
                    while (tempStop == false)
                    {
                        //Will check if the while loop should stop (because data is fully copied over to temp) if not it will contine to copy over data from data.txt to temp.txt
                        if (temp == "?Done")
                        {
                            writer.WriteLine("");
                            reader.ReadLine();
                            temp = reader.ReadLine();
                            if (temp == null)
                            {
                                tempStop = true;
                            }

                        }
                        else//Copies text from data to temp
                        {
                            temp = reader.ReadLine();
                            writer.WriteLine(temp);
                        }


                    }


                }
                else
                {
                Debug.Log("FUCLING CHEES");
                }


            }
            writer.Close();
            reader.Close();
            File.Delete(path);
            File.Move(Application.dataPath + "/StreamingAssets/temp.txt", path);
        
      
    }

    public void readProfilsData(string nameOfCat, string informationOfCat, ref StreamWriter writer)
    {

        switch (nameOfCat)
        {
            case ("Password"):
                break;
            case ("Player"):
                writer.WriteLine("'Player',{0};", player1_identifier_Name);
                break;
            case ("MouseOrKeyBoard"):
                writer.WriteLine("'MouseOrKeyBoard',{0};", player1_controls_MouseOrKeyboard);
                break;
            case ("forward"):
                writer.WriteLine("'forward',{0};", player1_controls_Forward);
                break;
            case ("backward"):
                writer.WriteLine("'backward',{0};", player1_controls_Backward);
                break;
            case ("left"):
                writer.WriteLine("'left',{0};", player1_controls_Left);
                break;
            case ("right"):
                writer.WriteLine("'right',{0};", player1_controls_Right);
                break;
            case ("fire1"):
                writer.WriteLine("'fire1',{0};", player1_controls_Fire1);
                break;
            case ("rotateLeft"):
                writer.WriteLine("'rotateLeft',{0};", player1_controls_RotateLeft);
                break;
            case ("rotateRight"):
                writer.WriteLine("'rotateRight',{0};", player1_controls_RotateRight);
                break;
            case ("inventory_use1"):
                writer.WriteLine("'inventory_use1',{0};", player1_controls_inventory_use1);
                break;
            case ("inventory_use2"):
                writer.WriteLine("'inventory_use2',{0};", player1_controls_inventory_use2);
                break;
            case ("inventory_use3"):
                writer.WriteLine("'inventory_use3',{0};", player1_controls_inventory_use3);
                break;
            case ("inventory_use4"):
                writer.WriteLine("'inventory_use4',{0};", player1_controls_inventory_use4);
                break;
            case ("inventory_user_CloseAndOpen"):
                writer.WriteLine("'inventory_user_CloseAndOpen',{0};", player1_controls_inventory_user_CloseAndOpen);
                break;
            case ("BackRoundMusic"):
                writer.WriteLine("'BackRoundMusic',{0};", player1_screenOptions_BackRoundMusicVolume);
                break;
            case ("FullScreenOrBordered"):
                writer.WriteLine("'FullScreenOrBordered',{0};", player1_screenOptions_FullScreenedOrBordered);
                break;
            case ("SFX_volume"):
                writer.WriteLine("'SFX_volume',{0};", player1_screenOptions_SFXvolume);
                break;
            case ("ShadowQuailty"):
                writer.WriteLine("'ShadowQuailty',{0};", player1_screenOptions_ShadowQuailty);
                break;
            case ("Level"):
                writer.WriteLine("'Level',{0};", level_on);
                break;
            case ("Health"):
                writer.WriteLine("'Health',{0};", 50);
                break;
            case ("Score"):
                writer.WriteLine("'Score',{0};", 0);
                break;             
               

            case ("gun_bullet_autoTarget"):
                if(level_on != 0)
                {
                    writer.WriteLine("'gun_bullet_autoTarget',gun_bullet_autoTarget;");
                }
                break;
            case ("gun_Bullet_growth"):
                if (level_on != 0)
                {
                    writer.WriteLine("'gun_Bullet_growth',gun_Bullet_growth;");
                }
                break;
            case ("gun_normal"):
                if (level_on != 0)
                {
                    writer.WriteLine("'gun_normal',gun_normal;");
                }
                break;
            case ("health_10"):
                if (level_on != 0)
                {
                    writer.WriteLine("'health_10',health_10;");
                }
                break;
            case ("health_20"):
                if (level_on != 0)
                {
                    writer.WriteLine("'health_20',health_20;");
                }
                break;
            case ("health_30"):
                if (level_on != 0)
                {
                    writer.WriteLine("'health_30',health_30;");
                }
                break;



            default:
                Debug.LogError("NameofCat " + nameOfCat + "  informationOfCat " + informationOfCat);
                break;

        }
    }


        public void player_useInventory(int playerNumber)
        {
        if(playerNumber == 1)
        {
            if(Input.GetKeyDown(player1_controls_Fire1))
            {
                player1_inventory_useSelectedItem();
            }
        }
        else if(playerNumber == 2)
        {

        }
        else
        {
            Debug.LogError("You done goofed up");
        }
    }

    public void player_inventory_Load(int playerNumber)
    {
        bool bool_temp = true;
        LinkedListNode<GameObject> temp = null;
        TextMeshProUGUI textMesh_temp;
        if(playerNumber == 1)
        {          

            for (int i =0;i<player1_inventory_Inventory.Count;i++)
            {
                if(bool_temp == true)
                {
                    temp = player1_inventory_Inventory.First;
                    bool_temp = false;
                }
                else
                {
                    temp = temp.Next;
                }

                if (player1_inventory_show[1].GetComponent<TextMeshProUGUI>().text.IndexOf('-') == player1_inventory_show[1].GetComponent<TextMeshProUGUI>().text.Length - 1)
                {
                    textMesh_temp = player1_inventory_show[1].GetComponent<TextMeshProUGUI>();
                    textMesh_temp.text = textMesh_temp.text.Substring(0, textMesh_temp.text.IndexOf('-') + 1)+ "\n" + temp.Value.name;
                }
                else if(player1_inventory_show[2].GetComponent<TextMeshProUGUI>().text.IndexOf('-') == player1_inventory_show[2].GetComponent<TextMeshProUGUI>().text.Length - 1)
                {
                    textMesh_temp = player1_inventory_show[2].GetComponent<TextMeshProUGUI>();
                    textMesh_temp.text = textMesh_temp.text.Substring(0, textMesh_temp.text.IndexOf('-') + 1) + "\n" + temp.Value.name;
                }
                else if (player1_inventory_show[3].GetComponent<TextMeshProUGUI>().text.IndexOf('-') == player1_inventory_show[3].GetComponent<TextMeshProUGUI>().text.Length - 1)
                {
                    textMesh_temp = player1_inventory_show[3].GetComponent<TextMeshProUGUI>();
                    textMesh_temp.text = textMesh_temp.text.Substring(0, textMesh_temp.text.IndexOf('-') + 1) + "\n" + temp.Value.name;
                }
                else if (player1_inventory_show[4].GetComponent<TextMeshProUGUI>().text.IndexOf('-') == player1_inventory_show[4].GetComponent<TextMeshProUGUI>().text.Length - 1)
                {
                    textMesh_temp = player1_inventory_show[4].GetComponent<TextMeshProUGUI>();
                    textMesh_temp.text = textMesh_temp.text.Substring(0, textMesh_temp.text.IndexOf('-') + 1) + "\n" + temp.Value.name;
                }
                else if (player1_inventory_show[5].GetComponent<TextMeshProUGUI>().text.IndexOf('-') == player1_inventory_show[5].GetComponent<TextMeshProUGUI>().text.Length - 1)
                {
                    textMesh_temp = player1_inventory_show[5].GetComponent<TextMeshProUGUI>();
                    textMesh_temp.text = textMesh_temp.text.Substring(0, textMesh_temp.text.IndexOf('-') + 1) + "\n" + temp.Value.name;
                }
                else if (player1_inventory_show[6].GetComponent<TextMeshProUGUI>().text.IndexOf('-') == player1_inventory_show[6].GetComponent<TextMeshProUGUI>().text.Length - 1)
                {
                    textMesh_temp = player1_inventory_show[6].GetComponent<TextMeshProUGUI>();
                    textMesh_temp.text = textMesh_temp.text.Substring(0, textMesh_temp.text.IndexOf('-') + 1) + "\n" + temp.Value.name;
                }

            }

           
        }
        else if(playerNumber == 2)
        {
            for (int i = 0; i < player2_inventory_Inventory.Count; i++)
            {
                if (bool_temp == true)
                {
                    temp = player2_inventory_Inventory.First;
                    bool_temp = false;
                }
                else
                {
                    temp = temp.Next;
                }

                if (player2_inventory_show[1].GetComponent<TextMeshProUGUI>().text.IndexOf('-') == player2_inventory_show[1].GetComponent<TextMeshProUGUI>().text.Length - 1)
                {
                    textMesh_temp = player2_inventory_show[1].GetComponent<TextMeshProUGUI>();
                    textMesh_temp.text = textMesh_temp.text.Substring(0, textMesh_temp.text.IndexOf('-') + 1) + "\n" + temp.Value.name;
                }
                else if (player2_inventory_show[2].GetComponent<TextMeshProUGUI>().text.IndexOf('-') == player2_inventory_show[2].GetComponent<TextMeshProUGUI>().text.Length - 1)
                {
                    textMesh_temp = player2_inventory_show[2].GetComponent<TextMeshProUGUI>();
                    textMesh_temp.text = textMesh_temp.text.Substring(0, textMesh_temp.text.IndexOf('-') + 1) + "\n" + temp.Value.name;
                }
                else if (player2_inventory_show[3].GetComponent<TextMeshProUGUI>().text.IndexOf('-') == player2_inventory_show[3].GetComponent<TextMeshProUGUI>().text.Length - 1)
                {
                    textMesh_temp = player2_inventory_show[3].GetComponent<TextMeshProUGUI>();
                    textMesh_temp.text = textMesh_temp.text.Substring(0, textMesh_temp.text.IndexOf('-') + 1) + "\n" + temp.Value.name;
                }
                else if (player2_inventory_show[4].GetComponent<TextMeshProUGUI>().text.IndexOf('-') == player2_inventory_show[4].GetComponent<TextMeshProUGUI>().text.Length - 1)
                {
                    textMesh_temp = player2_inventory_show[4].GetComponent<TextMeshProUGUI>();
                    textMesh_temp.text = textMesh_temp.text.Substring(0, textMesh_temp.text.IndexOf('-') + 1) + "\n" + temp.Value.name;
                }
                else if (player2_inventory_show[5].GetComponent<TextMeshProUGUI>().text.IndexOf('-') == player2_inventory_show[5].GetComponent<TextMeshProUGUI>().text.Length - 1)
                {
                    textMesh_temp = player2_inventory_show[5].GetComponent<TextMeshProUGUI>();
                    textMesh_temp.text = textMesh_temp.text.Substring(0, textMesh_temp.text.IndexOf('-') + 1) + "\n" + temp.Value.name;
                }
                else if (player2_inventory_show[6].GetComponent<TextMeshProUGUI>().text.IndexOf('-') == player2_inventory_show[6].GetComponent<TextMeshProUGUI>().text.Length - 1)
                {
                    textMesh_temp = player2_inventory_show[6].GetComponent<TextMeshProUGUI>();
                    textMesh_temp.text = textMesh_temp.text.Substring(0, textMesh_temp.text.IndexOf('-') + 1) + "\n" + temp.Value.name;
                }

            }
        }
        else
        {
            Debug.LogError("Invalid number");
        }




    }

    public void player_inventory_Selection(int playerNumber,GameObject beSlected)
    {
        if(playerNumber == 1)
        {
            if(player1_inventory_textlastText == null)
            {
                player1_inventory_textlastText = beSlected;
                beSlected.GetComponent<TextMeshProUGUI>().color = new Color32(0, 128, 0,255);
              //  player1_inventory_currentItem = beSlected;
            }
            else
            {
                player1_inventory_textlastText.GetComponent<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);
                beSlected.GetComponent<TextMeshProUGUI>().color = new Color32(0, 128, 0, 255);
                player1_inventory_textlastText = beSlected;
                // player1_inventory_currentItem = beSlected;

            }
        }
        else if(playerNumber == 2)
        {
            if (player2_inventory_textlastText == null)
            {
                player2_inventory_textlastText = beSlected;
                beSlected.GetComponent<TextMeshProUGUI>().color = new Color32(0, 128, 0, 255);
              //  player2_inventory_currentItem = beSlected;
            }
            else
            {
                player2_inventory_textlastText.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
                beSlected.GetComponent<TextMeshProUGUI>().color = new Color32(0, 128, 0, 255);
              //  player2_inventory_currentItem = beSlected;

            }
        }
        else
        {
            Debug.LogError("Invalid player number");
        }
    }

    public void addToInventory(GameObject thingToAdd, int playerNumber)
    {
       if(playerNumber == 1 && player1_inventory_Inventory.Count < 6)
        {
            for (int i = 1; i < player1_inventory_show.Length; i++)
            {
                if (player1_inventory_show[i].GetComponent<TextMeshProUGUI>().text.Length <= 9)
                {
                    TextMeshProUGUI temp = player1_inventory_show[i].GetComponent<TextMeshProUGUI>();

                    temp.text = temp.text.Substring(0, temp.text.IndexOf('-') + 1) + "\n" + thingToAdd.name;

                    player1_inventory_Inventory.AddLast(thingToAdd);
                    return;


                }
            }
        }
       else if(playerNumber == 2)
        {

        }
       else
        {
            Debug.LogError("INDALID");
        }
    }

    public void player_inventory_checkForInventoryButtonPress(int playerNumber)
    {
        LinkedListNode<GameObject> temp = null;
        if(playerNumber == 1)
        {
            if (player1_inventory_Inventory.Count != 0)
            {
                temp = player1_inventory_Inventory.First;
            }


            if (Input.GetKeyDown(player1_controls_inventory_use1))
            {
                player_inventory_Selection(1, player1_inventory_show[1]);
                if(temp != null)
                {
                    player1_inventory_currentItem = temp.Value;
                }
            }
            else if (Input.GetKeyDown(player1_controls_inventory_use2))
            {
                player_inventory_Selection(1, player1_inventory_show[2]);
                if (temp != null)
                {
                    for(int i =0;i<1;i++)
                    {
                        if(temp.Next != null)
                        {
                            temp = temp.Next;
                        }
                    }
                    player1_inventory_currentItem = temp.Value;
                }
            }
            else if (Input.GetKeyDown(player1_controls_inventory_use3))
            {
                player_inventory_Selection(1, player1_inventory_show[3]);
                if (temp != null)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (temp.Next != null)
                        {
                            temp = temp.Next;
                        }
                    }
                    player1_inventory_currentItem = temp.Value;
                }
            }
            else if (Input.GetKeyDown(player1_controls_inventory_use4))
            {
                player_inventory_Selection(1, player1_inventory_show[4]);
                if (temp != null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (temp.Next != null)
                        {
                            temp = temp.Next;
                        }
                    }
                    player1_inventory_currentItem = temp.Value;
                }
            }

        }
        else if (playerNumber == 2)
        {

        }
        else
        {
            Debug.LogError("Invalid Player Number");
        }
    }

    public void player1_health_change(float amountToChange)
    {
        player1_health += amountToChange;     
       
       
        
        player1_health_text.text = ""+(amountToChange + Convert.ToSingle(player1_health_text.text));
    }
    public void player2_health_change(float amountToChange)
    {
        player2_health += amountToChange;
    }
    public void player1_inventory_useSelectedItem()
    {
        if (player1_inventory_currentItem == null)
        {
            Debug.LogError("There is nothing in player1s current use Item slot");
        }
        else
        {
            if (player1_inventory_currentItem.tag == "Gun")
            {
                player1_inventory_currentItem.GetComponent<gunBase>().shoot();
            }
            else if (player1_inventory_currentItem.tag == "Health")
            {
                player1_health_change(player1_inventory_currentItem.GetComponent<healthAdd>().healthToAdd);
                player1_removeFromInventory(player1_inventory_currentItem);
                player1_inventory_currentItem = null;
            }
            else
            {
                Debug.LogError("Player 1s item does not have a tag");
            }
                
        }
    }

    public void player2_inventory_useSelectedItem()
    {
        if (player2_inventory_currentItem == null)
        {
            Debug.LogError("There is nothing in player1s current use Item slot");
        }
        else
        {
            if (player2_inventory_currentItem.tag == "Gun")
            {
                player2_inventory_currentItem.GetComponent<gunBase>().shoot();
            }
            else if (player2_inventory_currentItem.tag == "Health")
            {
                player2_health_change(player2_inventory_currentItem.GetComponent<healthAdd>().healthToAdd);
                player2_removeFromInventory(player2_inventory_currentItem);
                player2_inventory_currentItem = null;
            }
            else
            {
                Debug.LogError("Player 2s item does not have a tag");
            }

        }
    }

    public void player1_removeFromInventory(GameObject itemToRemove)
    {
      
        for(int i = 1;i<player1_inventory_show.Length;i++)
        {
            if(player1_inventory_show[i].GetComponent<TextMeshProUGUI>().text.Contains(itemToRemove.name))
            {
                TextMeshProUGUI temp = player1_inventory_show[i].GetComponent<TextMeshProUGUI>();

                temp.text = temp.text.Substring(0, temp.text.IndexOf('-') + 1);
              //  temp.text = temp.text.Substring(0, temp.text.IndexOf('-') + 1) + "\n" + thingToAdd.name;

                player1_inventory_currentItem = null;

                for(int o = i + 1;o< player1_inventory_show.Length; o++)
                {
                 
                    if (player1_inventory_show[o].GetComponent<TextMeshProUGUI>().text.Length > 8)
                    {
                        temp = player1_inventory_show[o].GetComponent<TextMeshProUGUI>();
                      

                        string temper = temp.text.Substring(temp.text.IndexOf('-') + 1, temp.text.Length - temp.text.IndexOf('-') - 1);
                      
                        player1_inventory_show[o - 1].GetComponent<TextMeshProUGUI>().text = player1_inventory_show[o - 1].GetComponent<TextMeshProUGUI>().text + "-" + temper;
                       temp.text = temp.text.Substring(0, temp.text.IndexOf('-') + 1);
                    }
                   

                    //for(int z =0;z<player1_inventory_show.Length;z++)
                    //{
                    //    if(player1_inventory_show[i].GetComponent<TextMeshProUGUI>().text.Contains("-") == false)
                    //    {
                    //        TextMeshProUGUI temp3 = (player1_inventory_show[i].GetComponent<TextMeshProUGUI>());
                    //        Debug.LogError(temp3.text);
                    //        temp3.text = temp3.text.Substring(0, 8) + "-";
                    //        Debug.LogError(temp3.text);

                    //    }
                    //}



                  
                }
                player1_inventory_Inventory.Remove(itemToRemove);
                return;



            }
        }

        player1_inventory_Inventory.Remove(itemToRemove);




    }

    public void player2_removeFromInventory(GameObject itemToRemove)
    {

    }



    public void player1_defaultSettings()
    {
        player1_rigidbody = player1_gameObject.GetComponent<Rigidbody>();
        path = Application.dataPath + "/StreamingAssets/data.txt";
        player1_zPostion_start = player1_gameObject.transform.position.z;

        if(player1_screenOptions_ShadowQuailty == "VeryHigh")
        {
            QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
        }
        else if (player1_screenOptions_ShadowQuailty == "High")
        {
            QualitySettings.shadowResolution = ShadowResolution.High;

        }
        else if (player1_screenOptions_ShadowQuailty == "Medium")
        {
            QualitySettings.shadowResolution = ShadowResolution.Medium;

        }
        else if (player1_screenOptions_ShadowQuailty == "Low")
        {
            QualitySettings.shadowResolution = ShadowResolution.Low;

        }
        
        if(player1_screenOptions_FullScreenedOrBordered == true)
        {
            Screen.fullScreen = true;
        }
        else if(player1_screenOptions_FullScreenedOrBordered == false)
        {
            Screen.fullScreen = false;
        }

    }
    //Click Escape To Save\Quit Game or Add Player 2
    //Add Player 2
    // Update is called once per frame
 

    private void LoadLevel(int levelNumber)
    {

    }


    public void load_ProfileData(int player_howMany)
    {
        string temp_string;
        bool temp_bool = false;

        if (1 == player_howMany)
        {
            StreamReader reader = new StreamReader(path);
            player1_identifier_Password = Convert.ToInt32(reader.ReadLine().Substring(1));



            while (temp_bool == false)
            {
                temp_string = reader.ReadLine();

                if (temp_string.Contains(player1_identifier_Password + ""))
                {
                    temp_bool = true;
                }
            }


            temp_bool = false;

            while (temp_bool == false)
            {
                temp_string = reader.ReadLine();

                if (temp_string[0] == '\'')
                {
                    int start = temp_string.IndexOf(',');
                    int end = temp_string.IndexOf(';');

                    end = end - start - 1;
                    load_player_DataLine(temp_string.Substring(temp_string.IndexOf('\'') + 1, temp_string.LastIndexOf('\'') - 1), temp_string.Substring(temp_string.IndexOf(',') + 1, end), player_howMany);
                }
                else if (temp_string[0] == '/')
                {

                }
                else if (temp_string[0] == '?')
                {
                    temp_bool = true;
                }
                else if (temp_string[0] == '=')
                {

                }
            }
            reader.Close();




        }
        else if (2 == player_howMany)
        {

        }
        else
        {
            Debug.LogError("Player_howmany is not 1 or 2 " + player_howMany);
        }
    }

    public void load_player_DataLine(string nameOfCat, string informationOfCat, int player_howMany)
    {
        if (player_howMany == 1)
        {

            switch (nameOfCat)
            {
                case ("Password"):
                    break;
                case ("Player"):
                    player1_identifier_Name = informationOfCat;
                    //Debug.Log(profilename.GetComponent<TextMeshProUGUI>().text);
                    break;
                case ("MouseOrKeyBoard"):
                    player1_controls_MouseOrKeyboard = Int32.Parse(informationOfCat);
                    break;
                case ("forward"):
                    player1_controls_Forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("backward"):
                    player1_controls_Backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("left"):
                    player1_controls_Left = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("right"):
                    player1_controls_Right = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("fire1"):
                    player1_controls_Fire1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("rotateLeft"):
                    player1_controls_RotateLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("rotateRight"):
                    player1_controls_RotateRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;

                case ("inventory_use1"):
                    player1_controls_inventory_use1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("inventory_use2"):
                    player1_controls_inventory_use2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("inventory_use3"):
                    player1_controls_inventory_use3 = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("inventory_use4"):
                    player1_controls_inventory_use4 = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("inventory_user_CloseAndOpen"):
                    player1_controls_inventory_user_CloseAndOpen = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("BackRoundMusic"):
                    player1_screenOptions_BackRoundMusicVolume = float.Parse(informationOfCat);
                    break;
                case ("FullScreenOrBordered"):
                    player1_screenOptions_FullScreenedOrBordered = bool.Parse(informationOfCat);
                    break;
                case ("SFX_volume"):
                    player1_screenOptions_SFXvolume = float.Parse(informationOfCat);
                    break;
                case ("ShadowQuailty"):
                    player1_screenOptions_ShadowQuailty = informationOfCat;
                    switch (player1_screenOptions_ShadowQuailty)
                    {
                        case "VeryHigh":
                            QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
                            break;
                        case "High":
                            QualitySettings.shadowResolution = ShadowResolution.High;
                            break;
                        case "Medium":
                            QualitySettings.shadowResolution = ShadowResolution.Medium;
                            break;
                        case "Low":
                            QualitySettings.shadowResolution = ShadowResolution.Low;
                            break;
                        default:
                            Debug.LogError("Invalid Shadow Setting" + player1_screenOptions_ShadowQuailty);
                            break;
                    }
                    break;
                case ("Level"):
                    player1_level_Level = level_on + 2;
                    break;
                case ("Score"):
                    player1_score_Score = Convert.ToInt32(informationOfCat);
                    break;
                case ("Health"):
                    player1_health = Convert.ToInt32(informationOfCat);
                    break;

                case ("gun_bullet_autoTarget"):
                    if(level_on != 0)
                    {
                        player1_inventory_Inventory.AddFirst(spawn_data.inventory_weapons[2]);

                    }
                    break;
                case ("gun_Bullet_growth"):
                    if (level_on != 0)
                    {
                        player1_inventory_Inventory.AddFirst(spawn_data.inventory_weapons[1]);

                    }
                    break;
                case ("gun_normal"):
                    if (level_on != 0)
                    {
                        player1_inventory_Inventory.AddFirst(spawn_data.inventory_weapons[0]);

                    }
                    break;
                case ("health_10"):
                    if (level_on != 0)
                    {
                        player1_inventory_Inventory.AddLast(spawn_data.inventory_healing[0]);

                    }
                    break;
                case ("health_20"):
                    if (level_on != 0)
                    {
                        player1_inventory_Inventory.AddLast(spawn_data.inventory_healing[1]);

                    }
                    break;
                case ("health_30"):
                    if (level_on != 0)
                    {
                        player1_inventory_Inventory.AddLast(spawn_data.inventory_healing[2]);

                    }
                    break;





                default:
                    Debug.LogError("NameofCat " + nameOfCat + "  informationOfCat " + informationOfCat + " player1InfoBroke");
                    break;

            }
        }
        else if (player_howMany == 2)
        {
            switch (nameOfCat)
            {
                case ("Password"):
                    break;
                case ("Player"):
                    player2_identifier_Name = informationOfCat;
                    //Debug.Log(profilename.GetComponent<TextMeshProUGUI>().text);
                    break;
                case ("MouseOrKeyBoard"):
                    player2_controls_MouseOrKeyboard = Int32.Parse(informationOfCat);
                    break;
                case ("forward"):
                    player2_controls_Forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("backward"):
                    player2_controls_Backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("left"):
                    player2_controls_Left = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("right"):
                    player2_controls_Right = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("fire1"):
                    player2_controls_Fire1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("rotateLeft"):
                    player2_controls_RotateLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("rotateRight"):
                    player2_controls_RotateRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), informationOfCat);
                    break;
                case ("BackRoundMusic"):
                    player2_screenOptions_BackRoundMusicVolume = float.Parse(informationOfCat);
                    break;
                case ("FullScreenOrBordered"):
                    player2_screenOptions_FullScreenedOrBordered = bool.Parse(informationOfCat);
                    break;
                case ("SFX_volume"):
                    player2_screenOptions_SFXvolume = float.Parse(informationOfCat);
                    break;
                case ("ShadowQuailty"):
                    player2_screenOptions_ShadowQuailty = informationOfCat;
                    switch (player2_screenOptions_ShadowQuailty)
                    {
                        case "VeryHigh":
                            QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
                            break;
                        case "High":
                            QualitySettings.shadowResolution = ShadowResolution.High;
                            break;
                        case "Medium":
                            QualitySettings.shadowResolution = ShadowResolution.Medium;
                            break;
                        case "Low":
                            QualitySettings.shadowResolution = ShadowResolution.Low;
                            break;
                        default:
                            Debug.LogError("Invalid Shadow Setting" + player1_screenOptions_ShadowQuailty);
                            break;
                    }
                    break;
                case ("Level"):
                    player2_level_Level = Convert.ToInt32(informationOfCat);
                    break;
                case ("Score"):
                    player1_score_Score = Convert.ToInt32(informationOfCat);
                    break;
                case ("Health"):
                    player1_health = Convert.ToInt32(informationOfCat);
                    break;

                case ("gun_bullet_autoTarget"):
                    player1_inventory_Inventory.AddFirst(spawn_data.inventory_weapons[2]);
                    break;
                case ("gun_Bullet_growth"):
                    player1_inventory_Inventory.AddFirst(spawn_data.inventory_weapons[1]);
                    break;
                case ("gun_normal"):
                    player1_inventory_Inventory.AddFirst(spawn_data.inventory_weapons[0]);
                    break;
                case ("health_10"):
                    player1_inventory_Inventory.AddFirst(spawn_data.inventory_healing[0]);
                    break;
                case ("health_20"):
                    player1_inventory_Inventory.AddFirst(spawn_data.inventory_healing[1]);
                    break;
                case ("health_30"):
                    player1_inventory_Inventory.AddFirst(spawn_data.inventory_healing[2]);
                    break;
                default:
                    Debug.LogError("NameofCat " + nameOfCat + "  informationOfCat " + informationOfCat + " player1InfoBroke");
                    break;

            }
        }
        else
        {
            Debug.LogError("That player_howmany is not valid " + player_howMany);
        }
    }


    public void player_move(GameObject player, Rigidbody player_rigidbody, int player_number, bool player_view_3dOr2d)//2d is true 3d is false
    {

        Vector3 move = new Vector3(0, 0, 0);    




        if (player_number == 1)
        {
            if (player1_controls_MouseOrKeyboard == 1)//Keyboard
            {
                if (player_view_3dOr2d == true)//2d
                {
                    if (Input.GetKey(player1_controls_Forward))
                    {
                        move = player.transform.up * speed;
                    }
                    else if (Input.GetKey(player1_controls_Backward))
                    {
                        move = move + (player.transform.up * speed * -1);

                    }
                    if (Input.GetKey(player1_controls_Left))
                    {
                        move = move + (new Vector3(1, 0, 0) * speed);
                    }
                    else if (Input.GetKey(player1_controls_Right))
                    {
                        move = move + (new Vector3(1, 0, 0) * speed * -1);
                    }
                    if (Input.GetKeyDown(player1_controls_Fire1))
                    {
                       // player1_inventory_useSelectedItem();
                    }
                    player_rigidbody.velocity += (new Vector3(move.x,move.y,move.z)) * speed;
                }
                else if (player_view_3dOr2d == false)//3d Giant Child Stealing you and putting you on a space (ground level)
                {

                }
            }
            else if (player1_controls_MouseOrKeyboard == 0)//Mouse
            {
                player1_gameObject.transform.position = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.transform.position.z));
            }
            else
            {
                Debug.LogError(player1_controls_MouseOrKeyboard + " is invalid");
            }

            if(player_rigidbody.velocity.y < 0)
            {
                player1_thrusters[0].emissionRate = 50;
                player1_thrusters[1].emissionRate = 50;
               
            }
            else if (player_rigidbody.velocity.y > 0)
            {
                player1_thrusters[0].emissionRate = Mathf.Abs(player_rigidbody.velocity.y / 200) * 250 + 50;
                player1_thrusters[1].emissionRate = Mathf.Abs(player_rigidbody.velocity.y / 200) * 250 + 50;
            }
            float y = player_rigidbody.velocity.x * 15.0f * 0.8f; // might be negative, just test it
            Vector3 euler = transform.localEulerAngles;
            euler.y = Mathf.Lerp(euler.y, y, 2.0f * Time.deltaTime);
            player.transform.localEulerAngles = euler;



        }
        else if (player_number == 2)
        {

        }
        else
        {
            Debug.LogError("Player number " + player_number + " is invalid");
        }



        if (player_number == 1)
        {
            player1_gameObject.transform.position = new Vector3(player1_gameObject.transform.position.x, player1_gameObject.transform.position.y, player1_zPostion_start);
        }
        else if (player_number == 2)
        {

        }
    }
}
*/