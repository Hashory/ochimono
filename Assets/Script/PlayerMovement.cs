using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    Animator animator;

    private bool IsPlayerMovement = false;

    public void PlayerMovementEnabled(bool enabled)
    {
        IsPlayerMovement = enabled;
        if (enabled)
        {
            // transform.position = new Vector3(112.628578f, 139.289276f, -118.00766f);
        }
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!IsPlayerMovement)
        {
            return;
        }

        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(x, 0, z);

        bool isMoving = x != 0 || z != 0;
        animator.SetBool("IsMove", isMoving);
    }

}
