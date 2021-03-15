using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack_melee : enemyBase
{
    private void Awake()
    {
        currentTime = Time.deltaTime;
        coolDownTime = coolDownTime / levelOfAttack;
        health = 60 + (20 * levelOfAttack);

    }
    public override void Attack()
    {
      
        currentTime += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

          if (doTheActionTime < currentTime)
          {
                this.gameObject.GetComponent<Rigidbody>().Sleep();
                this.transform.LookAt(new Vector3(player.transform.position.x + Random.Range(0, 20), player.transform.position.y + Random.Range(0, 20), this.transform.position.z));
                this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 1000 * ((GameManager.difficulty/5) + 3));


                doTheActionTime += coolDownTime;
          }     
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            this.gameObject.transform.Translate(new Vector3(Random.Range(-10f, 10f), Random.Range(-10, 10), 0));

        }
        else if (other.tag == "Bullet")
        {
            health = health - other.GetComponent<bullet_base>().damage;
            Destroy(other.gameObject);


            if (health <= 0)
            {
                Debug.Log(other.gameObject);

                this.gameObject.SetActive(false);
            }
        }
        else if (other.gameObject.tag == "player")
        {
           // GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().player1_health_change(-5);
        }
    

    }




}
