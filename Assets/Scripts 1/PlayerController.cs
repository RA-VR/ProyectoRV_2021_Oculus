using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed;
    public float vida;
    public GameObject puerta;
    bool puertaAbierta;
    public ParticleSystem stayFX;
    public ParticleSystem enterFX;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.05f;
        vida = 10.0f;
        puertaAbierta = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Control del personaje 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 0, speed));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, 0, -speed));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed,0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed, 0, 0));
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "Item")
        {
            vida += 5.0f;
            Destroy(obj.gameObject);
        }
        if (obj.tag == "Malo")
        {
            vida += 5.0f;
            Destroy(obj.gameObject);
        }
        if (obj.tag == "Carga")
        {
            enterFX.Play();
            stayFX.Play();
        }
    }

    void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Activador_Puerta")
        {
            if (Input.GetKeyDown(KeyCode.Space) && puertaAbierta == false)
            {
                puerta.GetComponent<Animation>().Play("Abre_puerta");
                _ = puertaAbierta == true;
            }
        }
        if (obj.tag == "Carga")
        {
            vida += 0.01f;
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "Carga")
        {
            stayFX.Stop();
        }
    }

}
