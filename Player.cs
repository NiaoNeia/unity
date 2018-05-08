using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private bool OnGround;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;
    private Rigidbody Rbody;
    private Animator anim;
    public float movespeed;
	// Use this for initialization
	void Start () {
        OnGround = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;
        Rbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        movespeed = 2f;
        
	}
	
	// Update is called once per frame
	void Update () {
		if(OnGround)
        {
            
                Rbody.velocity = new Vector3(Input.GetAxis("Horizontal"),0f,0f)*movespeed;
            
            if(Input.GetButton("Jump"))
            {
                if(jumpPressure<maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxJumpPressure;
                }
                anim.SetFloat("JumpPressure",jumpPressure+minJump);
                anim.speed = 1f + (jumpPressure / 10f);
                //Debug.Log(jumpPressure);
            }
            else
            {
                if(jumpPressure>0f)
                {
                    jumpPressure = jumpPressure + minJump;
                    Rbody.velocity = new Vector3(jumpPressure/10f,jumpPressure,0f);
                    jumpPressure = 0f;
                    OnGround = false;
                    anim.SetFloat("JumpPressure", 0f);
                    anim.SetBool("OnGround", OnGround);
                    anim.speed = 1f;
                }
            }
        }
	}
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            OnGround = true;
            anim.SetBool("OnGround", OnGround);
        }
    }
}
