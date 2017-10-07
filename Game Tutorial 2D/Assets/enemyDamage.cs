using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {
    public float damage;
    public float damageRate;
    public float pushbackForce;

    float nextDamge;

	// Use this for initialization
	void Start () {
        nextDamge = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && nextDamge < Time.time)
        {
            playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamge = Time.time + damageRate;
            pushBack(other.transform);

        }
        
    }
    void pushBack (Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection = pushDirection * pushbackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
