using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject my_bullet;
    public Transform bullet_spawn;
    public AudioSource shotSound;
  
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
         
            Attack();
        }
       
    }

    public void Attack()
    {    
            GameObject bullet = Instantiate(my_bullet, bullet_spawn.transform.position, transform.rotation) as GameObject;
            Rigidbody rb = bullet.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(transform.forward * 100 * 100);
            Destroy(bullet, 2f);
        shotSound.Play();
        //bullet.GetComponent<bullet_base>().effect_bullet();

     
        //throw new System.NotImplementedException();
    }
}
