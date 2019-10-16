using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField] public float runSpeed;
    float horizontalMove = 0f;
    bool jump = false;
    public CharacterController2D controller;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("horizontalMove", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
       
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

}
