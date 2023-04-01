using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float horizontal;
    private Animator anim; 

    [SerializeField] private float speed = 0;
    [SerializeField] private float jumpForce = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        GameManager.OnChangeLevel += ResetPosition;
        GameManager.OnGameOver += HandleDestroy;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);

        if (horizontal > 0)
        {
            anim.SetBool("RunR", true);
        }
        else if (horizontal < 0)
        {
            anim.SetBool("RunL", true);
        }
        else
        {
            anim.SetBool("RunR", false);
            anim.SetBool("RunL", false);
        }

        if (Input.GetKey(KeyCode.Space) && Mathf.Abs(rb.velocity.y)< 0.0001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void ResetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    private void HandleDestroy()
    {
        Invoke(nameof(DelayDestroy), 0.009f);
    }

    private void DelayDestroy()
    {
        Destroy(gameObject);
    }
    
    private void OnDestroy()
    {
        GameManager.OnChangeLevel -= ResetPosition;
        GameManager.OnGameOver -= HandleDestroy;
    }
}
