using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter(Collider other)
    { 
    
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<enemyBase>().health = other.gameObject.GetComponent<enemyBase>().health - damage;
            if (other.gameObject.GetComponent<enemyBase>().health <= 0)
            {
                Destroy(other.gameObject);
            }
        }
}
    }


    
      

