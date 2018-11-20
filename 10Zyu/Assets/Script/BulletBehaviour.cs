using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
    
    public GameObject OneShotAnim;
    Rigidbody2D rigidbody2;
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Terrain")
       {
            Instantiate(OneShotAnim, transform.position, Quaternion.Euler(Vector3.zero));
            Destroy(gameObject);
        }
    }


    void Start () {
        rigidbody2 = GetComponent<Rigidbody2D>();
        float velocitys = 20f;
        rigidbody2.velocity = transform.right * velocitys;
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
