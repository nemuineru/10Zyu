using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComp : MonoBehaviour {

    [SerializeField]
    GameObject Shot, Gun;
    [SerializeField]
    Vector2 mousepoint_World;

    Rigidbody2D rigidbody2;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rigidbody2 = GetComponent<Rigidbody2D>();
	}
    bool isAxislow;

    // Update is called once per frame
    void Update()
    {
        //動きのスクリプト
        Vector2 AxisInput = new Vector2(Input.GetAxisRaw("Horizontal") * 2f, 0);
        isAxislow = Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.3;
        if (!isAxislow)
        {
            VelocitysSetAlt(AxisInput, true, false);
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2.velocity.x), 1);
        }
        animator.SetBool("isWalk", rigidbody2.velocity.magnitude > 0.1);

        //マウスで射撃！
        mousepoint_World = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float Rotations = Vector2.SignedAngle(Vector2.right,mousepoint_World - (Vector2)transform.position);
        int bulletmax = 5;
        if (Input.GetButtonDown("Fire1")) {
            for (int i = 0; i < bulletmax; i++)
            {
                float randomangle = Random.Range(-2f, 2f);
                Quaternion MouseAngle = Quaternion.Euler(0f, 0f, Rotations + randomangle);
                Instantiate(Shot, transform.position, MouseAngle);
                VelocitysSetAlt((MouseAngle * new Vector2(-3f, 0f)), false, true);
            }
        }
        Gun.transform.rotation = Quaternion.Euler
            (0f, 0f, Rotations - System.Convert.ToInt16(transform.localScale.x != 1) * 180);
    }


    //===========================

    void VelocitysSet(Vector2 vector) {
        rigidbody2.velocity = new Vector2(vector.x, vector.y);
    }

    void VelocitysAdd(Vector2 vector)
    {
        rigidbody2.velocity = new Vector2(vector.x + rigidbody2.velocity.x, vector.y + rigidbody2.velocity.y);
    }

    void VelocitysSetAlt(Vector2 vector,bool RelativeHoriz, bool RelativeVerti)
    {
        if (RelativeHoriz)
        {
            rigidbody2.velocity
                = new Vector2(vector.x, rigidbody2.velocity.y);
        }
        if (RelativeVerti)
        {
            rigidbody2.velocity
                = new Vector2(rigidbody2.velocity.x, vector.y); 
                }
    }    
}
