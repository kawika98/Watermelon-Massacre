using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemyBase : MonoBehaviour
{
    //   public GameObject gun = null;//Must change this later to the base weaponsClass
    public GameObject enemy;
    public Transform player;//Target that it will attack
    public int difficulty = 5;//Default is 5 goes from 1(BrainDead) to 10(Epic Gamer)

    //NOTE : Remeber to (if you do it) change the move values/attackvalues/attackspeed values depending on the current Relics
    public float enemySpeed = 4;

    //Gun related Things
    public float coolDownTime;
    protected float currentTime;
    protected float doTheActionTime;
    public int levelOfAttack;  
    protected float doMoveTime;
    protected float yPos;

    //Health
    public float health;

    private void Awake()
    {
        yPos = transform.position.y;
    }



    public void move()
    {
        difficulty = GameManager.difficulty;

        float t_distance = distance(enemy.transform, player);
        enemySpeed = difficulty * enemySpeed;
        enemySpeed = enemySpeed * Random.Range(1, (enemySpeed / 20) + 0.01f);

        Vector3 predict_player_pos = player.transform.position + (player.transform.forward * difficulty);
        enemy.transform.LookAt(predict_player_pos);

        enemy.transform.Rotate(new Vector3(0, Random.Range(0.1f, 3), 0));
        enemy.GetComponent<Rigidbody>().velocity = transform.forward * enemySpeed;
        transform.position = new Vector3(transform.position.x,yPos,transform.position.z);


    }

    public float distance(Transform Enemy, Transform player)
    {
        return Mathf.Abs(Vector3.Distance(enemy.transform.position, player.position));
    }

    public abstract void Attack();





}
