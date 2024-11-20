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

    [Space(20)]
    [Header("Connecty")]
    public RawImage ZmienianieStylu;
    public Texture Stoi;
    public Texture Chód;
    public Texture Bieg;
    public Texture Kuca;
    public Texture Leży;





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

        // Ustawianie flag w zależności od stanu ruchu
        if (isCrawling)
        {
            // Gracz leży (czołga się) niezależnie od ruchu
            SetMovementState(false, false, false, false, true);
            RB.MovePosition(transform.position + (transform.forward * Vertical * CrawlSpeed) + (transform.right * Horizontal * CrawlSpeed));
            playerStat.Stamina += 20 * Time.deltaTime;
            ChangeTexture();
        }
        else if (isCrouching)
        {
            // Gracz kuca niezależnie od ruchu
            SetMovementState(false, false, false, true, false);
            RB.MovePosition(transform.position + (transform.forward * Vertical * CrouchSpeed) + (transform.right * Horizontal * CrouchSpeed));
            playerStat.Stamina += 15 * Time.deltaTime;
            ChangeTexture();
        }
        else if (!isMoving)
        {
            // Gracz stoi w miejscu
            SetMovementState(true, false, false, false, false);
            playerStat.Stamina += 10 * Time.deltaTime;
            ChangeTexture();
        }
        else if (isSprinting)
        {
            // Gracz sprintuje
            SetMovementState(false, false, true, false, false);
            RB.MovePosition(transform.position + (transform.forward * Vertical * SprintSpeed) + (transform.right * Horizontal * SprintSpeed));
            playerStat.Stamina -= 40 * Time.deltaTime;
            ChangeTexture();
        }
        else
        {
            // Gracz idzie
            SetMovementState(false, true, false, false, false);
            RB.MovePosition(transform.position + (transform.forward * Vertical * MoveSpeed) + (transform.right * Horizontal * MoveSpeed));
            playerStat.Stamina += 5 * Time.deltaTime;
            ChangeTexture();
        }

        // Obsługa skoku
        if (IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(transform.up * JumpForce);
        }




        lastPosition = transform.position;
    }

    // Funkcja pomocnicza do ustawiania stanów ruchu
    private void SetMovementState(bool isStay, bool isWalk, bool isSprint, bool isCrouch, bool isCrawl)
    {
        IsStay = isStay;
        IsWalk = isWalk;
        IsSprint = isSprint;
        IsCrouch = isCrouch;
        IsCrawl = isCrawl;
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

    public void ChangeTexture() {
        // Sprawdzamy stan ruchu gracza i przypisujemy odpowiednią teksturę
        if (IsStay)
        {
            ZmienianieStylu.texture = Stoi;  // Gracz stoi
        }
        else if (IsWalk)
        {
            ZmienianieStylu.texture = Chód;  // Gracz chodzi
        }
        else if (IsSprint)
        {
            ZmienianieStylu.texture = Bieg;  // Gracz biegnie
        }
        else if (IsCrouch)
        {
            ZmienianieStylu.texture = Kuca;  // Gracz kuca
        }
        else if (IsCrawl)
        {
            ZmienianieStylu.texture = Leży;  // Gracz leży (czołga się)
        }
    }
}