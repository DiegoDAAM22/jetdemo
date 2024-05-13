using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JET : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 300.0f;
    public float gravedad = -9.81f;
    private float velocidadCaida;
    private Animator _animatorController;
    private CharacterController _characterController;
    private bool floor = true;
    public float jumpf;
    

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);
        Vector3 move = (Camera.main.transform.forward * vertical  + Camera.main.transform.right * horizontal)/2;
        transform.rotation = Camera.main.transform.rotation;

        if (_characterController.isGrounded == false)
        {
           velocidadCaida  += gravedad * Time.deltaTime;
        }
        else if (_characterController.isGrounded && velocidadCaida < 0.0f)
        {
            velocidadCaida = -1.0f;
        }

        move.y = velocidadCaida;

        if (Input.GetButtonDown("Jump") && _characterController.isGrounded)
        {
            // TODO: REVISAR ESTO YA QUE ACTIVA LA ANIMACIN CUANDO NO HACE FALTA
            _animatorController.SetTrigger("jump");
            // TODO
            velocidadCaida += jumpf ;
            floor = false;
        }

          _characterController.Move(move);
        _animatorController.SetBool("speed", move.z != 0);
        _animatorController.SetBool("floor", _characterController.isGrounded);
        _animatorController.SetFloat("velocidadY", move.y);
        Debug.Log(_characterController.isGrounded);
        // si pulso la e...
        if (Input.GetKeyDown(KeyCode.E))
        { GameManager.Instance.CambiarCamara();}

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            floor = true;
            Debug.Log(floor);
            //_animatorController.SetBool("jump", false);
        }

    }
}
