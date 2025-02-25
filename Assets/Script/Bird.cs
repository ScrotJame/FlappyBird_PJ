using System;
using UnityEngine;
using UnityEngine.UI;

public class Bird :MonoBehaviour
{
    public static Bird BirdInstance;
    public Touch touch;
    public Text MainScreenText;
    private Vector2 StartPosition, EndPositon;
    public float flag = 0;
    private GameObject spawner;
    public int score = 0;

    public bool isGrounded;
    public bool isAlive= true;
    public bool _flap;

    private Rigidbody2D birdBody;

    private Animator anim;
    [SerializeField]
    private AudioClip fly, die, pass, touchclip;
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]private float jumpForce;

    void _MakeBirdInstant()
    {
        if (BirdInstance == null)
        { BirdInstance = this; }
    }

    private void Awake()
    {
        birdBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _MakeBirdInstant();
        spawner = GameObject.Find("Spawn");
    }
    private void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y < 0 || screenPosition.y > 1)
        {
            GameController.GameControlInstant.getGameOver(score);
        }
    }
    private void FixedUpdate()
    {
        _MoveBird();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="barier")
        {
            flag = 1;
            if(isAlive)
            {
                isAlive = false;
                isGrounded = true;
                Destroy(spawner);
                audioSource.PlayOneShot(die);
                anim.SetTrigger("is_die");
                if (GameController.GameControlInstant != null)
                {
                    GameController.GameControlInstant.getGameOver(score);
                }
            }
        }
        Debug.Log("Va chạm với: " + collision.gameObject.name + " | Tag: " + collision.gameObject.tag );
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpecialPoint"))
        {
            isGrounded = false;
            audioSource.PlayOneShot(pass);
            score+=2;
            if (GameController.GameControlInstant != null)
            {
                GameController.GameControlInstant.getScore(score);
            }
        }
        else if (collision.gameObject.CompareTag("point"))
        {
            isGrounded = false;
            audioSource.PlayOneShot(pass);
            score++;
            if (GameController.GameControlInstant != null)
            {
                GameController.GameControlInstant.getScore(score);
            }
        }
    }

    void _MoveBird()
    {
        if (isAlive)
        {
            if (_flap )
            {
                _flap = false;
                birdBody.linearVelocity = new Vector2(birdBody.linearVelocity.x, jumpForce);
                audioSource.PlayOneShot(fly);
            }
        }

        if (birdBody.linearVelocity.y > 0)
        {
            float angelZ = 0;
            angelZ = Mathf.Lerp(0, 90, birdBody.linearVelocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angelZ);
        }
        else if (birdBody.linearVelocity.y == 0)
        {
            float angelZ = 0;
            angelZ = Mathf.Lerp(0, 90, birdBody.linearVelocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (birdBody.linearVelocity.y < 0)
        {
            float angelZ = 0;
            angelZ = Mathf.Lerp(0, -90, -birdBody.linearVelocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angelZ);
        }

    }
    public void FlapButt()
    {
        _flap=true;
    }
}
