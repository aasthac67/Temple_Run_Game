using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private Animator anim;
    Vector3 lastpos;
    [SerializeField]
    GameObject platform;
    [SerializeField]
    Transform firstobject;
    int lengthzaxis;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f, 0f, speed);
        lastpos = firstobject.transform.position;
        InvokeRepeating("spawning",0f,0.5f);
    }
    private void spawning()
    {
        lengthzaxis = Random.Range(7, 15);
        GameObject obj = Instantiate(platform) as GameObject;
        obj.transform.position = lastpos + new Vector3(0f, 0f, lengthzaxis);
        lastpos = obj.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(0f, 1f, 0f, ForceMode.Impulse);
            anim.Play("jumping");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wave")
        {
            gameover();
        }
    }
    private void gameover()
    {
        Debug.Log("GAME OVER !!!!");
    }
}