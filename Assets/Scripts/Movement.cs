using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;
    public float horiz;
    public float vert;
    public float dodgeForce = 0;

    public float waitTime = 1f;
    public float timeRemain = 5f;
    public float dodgeCooldown = 5f;

    public UnityEvent OnBegin, OnDone;

    public UiManager uiManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

            horiz = Input.GetAxis("Horizontal");
            vert = Input.GetAxis("Vertical");

            //shift key dodge
            if (Input.GetKeyDown(KeyCode.LeftShift) && timeRemain >= dodgeCooldown)
            {
                timeRemain = 0f;
                rb.AddForce(rb.velocity.normalized * dodgeForce, ForceMode2D.Impulse);
                OnBegin.Invoke();
                StartCoroutine(dodge());
            }

        //dodge cooldown
        if(timeRemain < dodgeCooldown)
        {
            timeRemain += Time.deltaTime;
            uiManager.stam = timeRemain / dodgeCooldown;
            
        }
    }

    //dodge script within Enum as to use a timer
    IEnumerator dodge()
    {
        Debug.Log("shift down");
        this.GetComponent<CircleCollider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().color = Color.green;

        timeRemain = 0;

        yield return new WaitForSeconds(waitTime);


        OnDone.Invoke();

        this.GetComponent<CircleCollider2D>().enabled = true;
        this.GetComponent<SpriteRenderer>().color = Color.white;
        
    }

    private void FixedUpdate()
    {
        //general movement
        rb.velocity = new Vector3(horiz, vert, 0) * Time.deltaTime * speed;
    }
}
