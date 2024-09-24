using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class shootScript : MonoBehaviour
{
    public Rigidbody2D projectile;
    public Rigidbody2D rb;
    public GameObject spawnPoint;
    public GameObject laser;

    public new GameObject camera;

    public AudioSource shot;
    public AudioSource reload;

    public score score;

    public float force, delay, reloadDelay;

    public GameObject[] blood;
    private int numberInList;

    //OUnity Events allows activation of events to be called from the inspector (really cool)
    public UnityEvent OnBegin, OnDone, OnReloadDone;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        laser.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.5f);

    }

    public void recoil()
    {
            //sets velocity to zero so the recoil is not affected by current movement
            rb.velocity = Vector3.zero;
            //applies a backwards force (using a negative force input) with unitys Impulse force mode
            rb.AddForce(transform.up * force, ForceMode2D.Impulse);
            //starts the waiting corountine
            StartCoroutine(wait());
        
    }

    //a wait function used to controll the length of the effect
    public IEnumerator wait()
    {
        //wait for seconds until player can move
        yield return new WaitForSeconds(delay);
        reload.Play();
        OnDone?.Invoke();

        //wait for seconds until player can shoot
        yield return new WaitForSeconds(reloadDelay);
        OnReloadDone?.Invoke();
        laser.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.6f);
    }

    //raycast shooting gets every enemy it hits
    public void shoot()
    {

        laser.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.0f);

        RaycastHit2D[] hits = Physics2D.RaycastAll(spawnPoint.transform.position, transform.up, 1000f);

        foreach (RaycastHit2D hit in hits)
        {

            if (hit.collider.CompareTag("enemy"))
            {
                score.setMultiplier(hits);
                Debug.Log(hit.collider.tag);

                //Blood splatter from random list
                numberInList = Random.Range(0, 2);
                Quaternion bloodRotation = Quaternion.LookRotation(blood[numberInList].transform.forward, rb.transform.right);
                Instantiate(blood[numberInList], hit.transform.position, bloodRotation);

                //destoys target
                Destroy(hit.collider.gameObject);


            }

        }
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            shot.Play();

            shoot();

            StartCoroutine(camera.GetComponent<cameraScript>().shaking());

            //called in inspector
            OnBegin?.Invoke();
            Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
            recoil();
        }

    }

}
