using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movercan : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;
    private Animator _animatorController;
    public float limiteX;
    public float limiteY;
    public float sensitivity = 8f;
    private bool movin = false;

    // Start is called before the first frame update
    void Start()
    {
        _animatorController = GetComponent<Animator>();
        _animatorController.SetBool("movin", movin);

    }

    // Update is called once per frame
    void Update()
    {
        // en que modo estamos????
        GameManager.Instance.ModoCamara();

        // si estoy en modo pintar4...

        if (GameManager.Instance.ModoCamara())
        {
            if (transform.position.x <= limiteX || transform.position.x >= -limiteX)
            {
                rotationX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            }
            else
            {
                rotationX = 0;
            }

            if (transform.position.y <= limiteY || transform.position.y >= -limiteY)
            {
                rotationY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            }
            else
            {
                rotationY = 0;
            }


            Debug.Log(rotationX + rotationY);

            transform.Translate(rotationX, rotationY, 0, Space.Self);
        }
    }
}
