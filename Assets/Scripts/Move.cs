using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float speed;                //Floating point variable to store the player's movement speed.
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    [SerializeField] float padding = 1f;
    [SerializeField] float moveSpeed = 10f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Use this for initialization
    void Start() {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        //rb2d = GetComponent<Rigidbody2D>();
        SetUpMoveBoundaries();
    }

    private float MoveX(bool positive) {
        if (positive) {
            return transform.position.x + 0.1f;

        } else {
            return transform.position.x - 0.1f;
        }
    }

    private float MoveY(bool positive) {
        if (positive) {
            return transform.position.y + 0.1f;

        } else {
            return transform.position.y - 0.1f;
        }
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void Update() {
        MoveOn();
        //float moveX = transform.position.x;
        //float moveY = transform.position.y;

        //if (Input.GetButton("Horizontal")) {
        //    if (Input.GetAxisRaw("Horizontal") > 0) {
        //        moveX = MoveX(true);
        //    } else {
        //        moveX = MoveX(false);
        //    }
        //}
        //if (Input.GetButton("Vertical")) {
        //    if (Input.GetAxisRaw("Vertical") > 0) {
        //        moveY = MoveY(true);
        //    } else {
        //        moveY = MoveY(false);
        //    }
        //}

        //if (moveX != transform.position.x || moveY != transform.position.y) {
        //    Vector2 paddlePos = new Vector2(moveX, moveY);
        //    //paddlePos.x = Mathf.Clamp(moveX, 1, 15); // limitar para o tamanho desejado

        //    transform.position = paddlePos;
        //}

    }

    private void MoveOn() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
