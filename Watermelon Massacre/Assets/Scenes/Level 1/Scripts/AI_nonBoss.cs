using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_nonBoss : MonoBehaviour
{
 //   public GameObject gun = null;//Must change this later to the base weaponsClass
    public GameObject enemy;
    public Transform player;//Target that it will attack
    public int difficulty = 5;//Default is 5 goes from 1(BrainDead) to 10(Epic Gamer)

    //NOTE : Remeber to (if you do it) change the move values/attackvalues/attackspeed values depending on the current Relics
    public float enemySpeed = 4;

    public void move(float range)
    {
        difficulty = GameManager.difficulty;      

        float t_distance = distance(enemy.transform, player);   
        enemySpeed = difficulty * enemySpeed;
        enemySpeed = enemySpeed * Random.Range(1, (enemySpeed / 20) + 0.01f);

        Vector3 predict_player_pos = player.transform.position + (player.transform.forward * difficulty);
        enemy.transform.LookAt(predict_player_pos);

        enemy.transform.Rotate(new Vector3(0, Random.Range(0.1f, 3), 0));
        enemy.GetComponent<Rigidbody>().velocity = transform.forward * enemySpeed;

      
    }

    public float distance(Transform Enemy, Transform player)
    {
        return Mathf.Abs(Vector3.Distance(enemy.transform.position, player.position));
    }

    public void attack()
    {
        //Attacks the player in range by using the use() method on the weapon
        //Firing speed is changed by diffucilty
        //All in all this should be basic due to the cacluations being done in move already

    }



}
