using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public holder_Information save1;
    public holder_Information save2;
    public holder_Information save3;
    public int level;

    public float timess;

    public holder_Information currentSaves = new holder_Information();
    void Start()
    {
        timess = Time.deltaTime;
        try
        {
            int currentSave = save1.currentSave;
            if (currentSave == 1)
            {
                save1.save(currentSaves);
            }
            else if (currentSave == 2)
            {
                save2.save(currentSaves);

            }
            else if (currentSave == 3)
            {
                save3.save(currentSaves);

            }
            else
            {
                Debug.LogError("there is not current save POOO POO FART");
            }

        }
        catch
        {

        }



    } 

    // Update is called once per frame
    void Update()
    {
        timess += Time.deltaTime;

        if(timess > 90)
        {
            SceneManager.LoadScene(level + 1);
        }    

        if(PlayerManager.health <= 0)
        {
            Debug.Log("PISSSS");
            Debug.LogError("DEADCDD");
            float timer = 0;
            timer += Time.deltaTime;
           
                int currentSave = save1.currentSave;

                if (currentSave == 1)
                {
                    currentSaves.save(save1);
                }
                else if (currentSave == 2)
                {
                    currentSaves.save(save1);

                }
                else if (currentSave == 3)
                {
                    currentSaves.save(save1);
                }

                Debug.LogError("Nooooo");
                SceneManager.LoadScene(0);
            

        }
    }
}
