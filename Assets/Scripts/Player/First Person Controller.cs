using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Controller : MonoBehaviour
{
    Rigidbody RB;

    [Header("Player Settings")]
    public float MoveSpeed = 0.05f;
    public float SprintSpeed = 0.08f;
    public float CrouchSpeed = 0.03f;
    public float CrawlSpeed = 0.02f;
    public float JumpForce = 14000;
    public float MouseSensitivity = 2.0f;
    public float MaxRotX = 90;

    [Space(20)]
    [Header("Player Statisic")]
    public bool IsGrounded;
    public bool IsStay;
    public bool IsWalk;
    public bool IsSprint;
    public bool IsCrouch;
    public bool IsCrawl;






    float Vertical;
    float Horizontal;




    private PlayerStat playerStat;
    private Vector3 lastPosition;



    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        playerStat = GetComponent<PlayerStat>();
        lastPosition = transform.position; //
    }
    



    void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");

        // Obsługa sprintu, kucania i czołgania
        bool isMoving = (Vertical != 0 || Horizontal != 0);  // Sprawdza, czy gracz się porusza
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && isMoving;
        bool isCrouching = Input.GetKey(KeyCode.C);
        bool isCrawling = Input.GetKey(KeyCode.LeftControl);




        // Obsługa skoku
        if (IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(transform.up * JumpForce);
        }
    }



        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = false;
        }
    }


}