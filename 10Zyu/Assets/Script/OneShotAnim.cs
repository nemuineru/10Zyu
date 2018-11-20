using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotAnim : MonoBehaviour {

    Animator Anims;

	// Use this for initialization
	void Start () {
    Anims = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Anims.GetCurrentAnimatorStateInfo(1).length > 1) {
            Destroy(gameObject);
        }
	}
}
