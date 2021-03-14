using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_nonBoss : MonoBehaviour
{
    public GameObject gun = null;//Must change this later to the base weaponsClass
    public GameObject enemy;
    public Transform player;//Target that it will attack
    public int difficulty = 5;//Default is 5 goes from 1(BrainDead) to 10(Epic Gamer)

    //NOTE : Remeber to (if you do it) change the move values/attackvalues/attackspeed values depending on the current Relics

    public void move(float range)
    {
        //This method moves the enemy to the player depending on difficulty and best range to be from player

        float t_distance = distance(enemy.transform, player);

        //Now that you know the distance find where the enemy should move depending on its range
        //Such as a raw value of 5 units tword the player (Calucated by doing math with range)

        //Now calucate the speed at which the enemy moves tword the player (Done with base move speed and diffuclty together)

        //Now use the command LookAtPlayer

        //Now use Random.Range(-Diffuclty,Diffucly) then save that values

        //Find which direction the player went the most in the last 0.2 seconds

        //Once you know the direction the player went the most in the last 0.2 seconds use the Range values to add or subtract from the rotational value

        //Move the enemy with setting its velocity to the speed (make sure it can't move on the third axis)

        //Make sure the enemy moves with the calucated theta direction

        //Profit     
    }

    public float distance(Transform Enemy, Transform player)
    {
        return 0.0f;//This returns the distance from the Enemy to the player NOTE: Must always be postive and never 0
    }

    public void attack()
    {
        //Attacks the player in range by using the use() method on the weapon
        //Firing speed is changed by diffucilty
        //All in all this should be basic due to the cacluations being done in move already

    }



}
