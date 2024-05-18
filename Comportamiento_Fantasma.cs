using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comportamiento_Fantasma : MonoBehaviour
{   
    public Animator miAnimacion;
    
    // Start is called before the first frame update
    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
       
        


    }

    public void Mostrar(){
        miAnimacion.Play("msf1");
        miAnimacion.Play("msf2");
        miAnimacion.Play("msf3");
        miAnimacion.Play("msf4");
        miAnimacion.Play("msf5");
        miAnimacion.Play("msf6");
        miAnimacion.Play("msf7");
        miAnimacion.Play("msf8");
        miAnimacion.Play("msf9");
        
        
        //Debug.Log("Mostro el personaje");
    }

    public void Esconder(){
        miAnimacion.Play("msf1 0");
        miAnimacion.Play("msf2 0");
        miAnimacion.Play("msf3 0");
        miAnimacion.Play("msf4 0");
        miAnimacion.Play("msf5 0");
        miAnimacion.Play("msf6 0");
        miAnimacion.Play("msf7 0");
        miAnimacion.Play("msf8 0");
        miAnimacion.Play("msf9 0");
        
        //Debug.Log("Escondido Personaje");
    
    }
    public void Esperar (){
        miAnimacion.Play("esf1");
        miAnimacion.Play("esf2");
        miAnimacion.Play("esf3");
        miAnimacion.Play("esf4");
        miAnimacion.Play("esf5");
        miAnimacion.Play("esf6");
        miAnimacion.Play("esf7");
        miAnimacion.Play("esf8");
        miAnimacion.Play("esf9");

        //Debug.Log("Esperanding");
    }
    
}
