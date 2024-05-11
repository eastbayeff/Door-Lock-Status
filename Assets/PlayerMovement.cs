using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Update() => movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    private void FixedUpdate() => rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
    
}
