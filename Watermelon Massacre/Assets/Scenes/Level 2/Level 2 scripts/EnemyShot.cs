using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShot : bullet_base
{
    //public Text hpText;
    //public int playerHealth = 100;
    //public int stepsTillVoid = 0;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
            Destroy(this.gameObject);
        PlayerManager.health = PlayerManager.health - damage;
        }
     
        
    }

    public override void effect_bullet()
    {
        
    }
}
