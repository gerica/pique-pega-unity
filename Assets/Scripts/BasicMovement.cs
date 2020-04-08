using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {
    [SerializeField] Animator animator;
    [SerializeField] float moveSpeed = 10f;
    private bool stopWallDown = false;
    private bool stopWallUp = false;
    private bool stopWallLeft = false;
    private bool stopWallRight = false;
    private bool stopPique = false;
    //private Rigidbody2D rb;

    private void Start() {
        //rb = GetComponent<Rigidbody2D>();
        // Moves the GameObject using it's transform.
        //rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update() {
        Moviment();
    }

    private void Moviment() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        checkCanWalk(x, y);

        if (stopWallDown || stopWallUp) {
            y = 0;
        }

        if (stopWallLeft || stopWallRight) {
            x = 0;
            //movement = Vector3.zero;
        }
        Vector3 movement = new Vector3(x, y, 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
        transform.position = transform.position + movement * moveSpeed * Time.deltaTime;
        //rb.position = transform.position + movement * moveSpeed * Time.deltaTime;

    }

    private void checkCanWalk(float x, float y) {
        if (stopWallDown && y > 0) {
            stopWallDown = false;
        } else if (stopWallUp && y < 0) {
            stopWallUp = false;
        }

        if (stopWallLeft && x > 0) {
            stopWallLeft = false;
        } else if (stopWallRight && x < 0) {
            stopWallRight = false;
        }


    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        //Debug.Log(otherCollider.tag);
        if (otherCollider.gameObject.name == "ParedeBaixo") {
            stopWallDown = true;
        }
        if (otherCollider.gameObject.name == "ParedeAlto") {
            stopWallUp = true;
        }
        if (otherCollider.gameObject.name == "ParedeEsquerda") {
            stopWallLeft = true;
        }
        if (otherCollider.gameObject.name == "ParedeDireita") {
            stopWallRight = true;
        }
        if (otherCollider.tag == "Pique") {
            StopAllWalk();
        }

    }

    private void StopAllWalk() {
        stopWallDown = true;
        stopWallUp = true;
        stopWallLeft = true;
        stopWallRight = true;
    }

    // Usar quando o rigidbody tipo for dynamic
    //private void OnCollisionEnter2D(Collision2D otherCollider) {
    //    Debug.Log(otherCollider.gameObject);
    //    Debug.Log("colidiu");
    //    if (otherCollider.gameObject.CompareTag("Pique")) {
    //    }

    //    this.rb.velocity = Vector2.zero;
    //    this.rb.angularVelocity = 0.0f;
    //    this.rb.Sleep();
    //}
}
