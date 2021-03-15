using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attack_single_gun : enemyBase
{
    public GameObject my_bullet;
    private void Awake()
    {
        currentTime = Time.deltaTime;
        coolDownTime = coolDownTime / levelOfAttack;
        health = 40 + (20 * levelOfAttack);


    }
    private void Update()
    {

        Attack();
    }

    public override void Attack()
    {
        currentTime += Time.deltaTime;

        if (coolDownTime < currentTime)
        {
            this.gameObject.GetComponent<Rigidbody>().Sleep();
            //this.transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z));


            GameObject bullet = Instantiate(my_bullet, transform.position, transform.rotation) as GameObject;
            Rigidbody rb = bullet.AddComponent<Rigidbody>();
            bullet.transform.LookAt(new Vector3(player.position.x, player.position.y, player.transform.position.z));
            rb.useGravity = false;
            rb.AddForce(bullet.transform.forward * 90 * 100);
            Destroy(bullet, 2.5f);
            bullet.GetComponent<bullet_base>().effect_bullet();


            doTheActionTime += coolDownTime;
            currentTime = 0;
        }
        //throw new System.NotImplementedException();
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

                this.gameObject.SetActive(false);
            }
        }
    }

   

   
  

}
