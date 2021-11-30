using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeAnimacion : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;

    private Animator anim;
    public float x, y;


    public Rigidbody rb;
    public float FuerzaSalto = 8f;
    public bool puedoSaltar;

    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();  
    }


    void FixedUpdate()
    {

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
    }
    // Update is called once per frame

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);

        if (!puedoSaltar) 
        { 
        
            if (Input.GetKeyDown(KeyCode.Space)) 
               
            {

                anim.SetBool("salto", true);
                rb.AddForce(new Vector3(0, FuerzaSalto, 0), ForceMode.Impulse);

            }

            anim.SetBool("suelo", true);
        }
        else
        {
            estoyCayendo();
        }
    }

    public void estoyCayendo() 

    {
        anim.SetBool("suelo", false);
        anim.SetBool("salto", false);
    }
}
