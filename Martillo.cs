using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Martillo : MonoBehaviour
{   
    public Animator aniMartillo;
    public Transform[] posiciones;
    public Transform inicioMar;
    public GameObject ControlFantasmas;
    public ParticleSystem[] estrellas;
    private int NumEst;
    public int pt=0;
    public TextMeshProUGUI pts;
    public AudioSource[] golpeSound;
    
    


    // Start is called before the first frame update
    public void Start()
    {   
        
        pt = PlayerPrefs.GetInt("Puntuacion", 0);

        if (pt > 0)
        {
            pt = 0;
            PlayerPrefs.SetInt("Puntuacion", pt);
        }
        pts.text = pt.ToString() + "pts";

    }

    // Update is called once per frame
    public void Update()
    {

        
        if(Input.GetKeyDown(KeyCode.Keypad1)){
            golpear(1);
        }
        if(Input.GetKeyDown(KeyCode.Keypad2)){
            golpear(2);
        }
        if(Input.GetKeyDown(KeyCode.Keypad3)){
            golpear(3);
        }
        if(Input.GetKeyDown(KeyCode.Keypad4)){
            golpear(4);
        }
        if(Input.GetKeyDown(KeyCode.Keypad5)){
            golpear(5);
        }
        if(Input.GetKeyDown(KeyCode.Keypad6)){
            golpear(6);
        }
        if(Input.GetKeyDown(KeyCode.Keypad7)){
            golpear(7);
        }
        if(Input.GetKeyDown(KeyCode.Keypad8)){
            golpear(8);
        }
        if(Input.GetKeyDown(KeyCode.Keypad9)){
            golpear(9);
        }
        
    }
    public void golpear(int p){
        
        NumEst=p;
        transform.position = posiciones[p].position;
        
        aniMartillo.Play("MarMov");
        
        
         

        Invoke("VolverInicio", 0.30f);

        
    }

    public void VolverInicio(){
        

        Debug.Log("Teletransportando a: " + inicioMar.position);
            transform.localPosition = inicioMar.localPosition;

            Debug.Log("Objeto teletransportado correctamente.");

    }

    public void ActivarEstrellas(){
        
        estrellas[NumEst].Play();
        
        if(NumEst == ControlFantasmas.GetComponent<ControlFantasmas>().ValAleatorio){
            Debug.Log("-----------------Sumar Punto");
            pt = pt + 100;
            pts.text = pt +"pts";
            PlayerPrefs.SetInt("Puntuacion", pt);
            AudioSource sonidoAleatorio = golpeSound[Random.Range(0, golpeSound.Length)];
            sonidoAleatorio.Play();
        }
        
    }
}
