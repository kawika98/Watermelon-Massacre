using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Transform player;
   // public Transform shotSpawn;
   // public GameObject shot;
   float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 75f)
        {
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, .2f);
        }
        /*if (Vector3.Distance(transform.position, player.position) < 5f)
        //{
           // float shotDelay = .5f;
            timer += Time.deltaTime;
            if (timer > shotDelay)
            {
                GameObject newShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
                Destroy(newShot, 5f);
                timer = 0;
            }

        }
        */
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            PlayerManager.health = PlayerManager.health - 30;
        }
    }

}
