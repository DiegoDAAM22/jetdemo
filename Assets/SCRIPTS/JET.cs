using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JET : MonoBehaviour
{
    public float speed = 25.0f;
    public float turnSpeed = 300.0f;
    public float gravedad = -30f;
    private float velocidadCaida;
    private Animator _animatorController;
    private CharacterController _characterController;
    private Rigidbody _rb;
    private bool floor = true;
    public float jumpf;
    private bool doblejump = false;
    public GameObject death;
    public GameObject canroot;
    private List<Transform> canchilds = new List<Transform>();
    private int canactiveindex;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animatorController = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        death.SetActive(false);
        for (int i= 0; i < canroot.transform.childCount; i++)
        {
            canchilds.Add(canroot.transform.GetChild(i));
            Debug.Log(canroot.transform.GetChild(i).name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);
        Vector3 camerafw = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        camerafw.y = 0;
        cameraRight.y = 0;
        Vector3 move = ( camerafw * vertical * speed  + cameraRight * horizontal * speed);
        move.y = _rb.velocity.y;
        transform.rotation = Camera.main.transform.rotation;

        if (Input.GetButtonDown("Jump") && floor) 
        {
            _animatorController.SetTrigger("jump");
            Debug.Log(Vector3.up);
            _rb.AddForce(Vector3.up * jumpf);
            floor = false;
            doblejump = true;
        }

        _rb.velocity = move;
        _animatorController.SetBool("speed", move.z != 0);
        _animatorController.SetBool("side", move.x != 0);
        _animatorController.SetBool("floor", floor);
        _animatorController.SetFloat("velocidadY", _rb.velocity.y);
 
        if (Input.GetKeyDown(KeyCode.E))
        { GameManager.Instance.CambiarCamara();}

        if (Input.GetKeyDown(KeyCode.LeftShift))
        { speed = 30; }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        { speed = 25; }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canactiveindex == canchilds.Count)
            {
                canactiveindex = -1;
            }

            for (int i = 0; i < canchilds.Count; i++)
            {
                if (i == (1+canactiveindex))
                {
                    Debug.Log("Activando:" + canchilds[i].name);
                    canchilds[i].gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("Desactivando:" + canchilds[i]);
                    canchilds[i].gameObject.SetActive(false);
                }
            }
            canactiveindex++;

        }

    }
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "floor")
        {
            floor = true;
            Debug.Log(floor);
        }

        if (collision.gameObject.layer == 6)
        { _animatorController.SetTrigger("tramp"); }

       
    }

    private void OnTriggerEnter(Collider collision)
    {
         Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "cop")
        {
            
            death.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
