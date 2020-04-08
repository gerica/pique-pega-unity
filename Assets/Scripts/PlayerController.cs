using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //public int playerId;

    [Header("Input settings:")]
    [SerializeField] float BASE_SPEED = 5.0f;

    [Space]
    [Header("Character attributes:")]
    [SerializeField] Vector2 movimentDirection;
    [SerializeField] float movimentSpeed;

    [Space]
    [Header("References:")]
    [SerializeField] Rigidbody2D rg;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        ProcessInputs();
        Move();
        Animate();
    }

    void ProcessInputs() {
        movimentDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movimentSpeed = Mathf.Clamp(movimentDirection.magnitude, 0.0f, 1.0f);
        movimentDirection.Normalize();
    }

    void Move() {
        rg.velocity = movimentDirection * movimentSpeed * BASE_SPEED;
    }

    void Animate() {
        animator.SetFloat("Horizontal", movimentDirection.x);
        animator.SetFloat("Vertical", movimentDirection.y);
        animator.SetFloat("Magnitude", movimentDirection.magnitude);
    }
}
