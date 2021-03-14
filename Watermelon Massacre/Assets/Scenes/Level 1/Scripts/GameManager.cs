using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Saves")]
    public holder_Information save1;
    public holder_Information save2;
    public holder_Information save3;

    public holder_Information currentSave;
    public static int difficulty = 5;



    private void Awake()
    {
        loadSave();
        difficulty = currentSave.difficulty;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if(PlayerManager.playerisDead == true)
       {
            playerDeath();
       }
    }



    private void playerDeath()
    {
        int curSave = save1.currentSave;

        if (curSave == 1)
        {
            currentSave.save(save1);
            goTo_mainMenu();
        }
        else if (curSave == 2)
        {
            currentSave.save(save2);
            goTo_mainMenu();

        }
        else if (curSave == 3)
        {
            currentSave.save(save3);
            goTo_mainMenu();
        }
        else
        {
            Debug.LogError("currentSave is invalid check save1 for more details");
        }
    }

    private void goTo_mainMenu()
    {
        SceneManager.LoadSceneAsync(0);//0 should be main menu
    }
    
    private void loadSave()
    {
        int curSave = save1.currentSave;

        if (curSave == 1)
        {
            save1.save(currentSave);
        }
        else if (curSave == 2)
        {
            save1.save(currentSave);
        }
        else if (curSave == 3)
        {
            save1.save(currentSave);
        }
        else
        {
            Debug.LogError("currentSave is invalid check save1 for more details");
        }

    }
}
