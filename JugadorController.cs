using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class JugadorController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float velocidad;
    private int contador;
    public TMP_Text textoContador, textoGanar;
    public AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        setTextoContador();
        textoGanar.text="";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoH,0.0f,movimientoV);

        rb.AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Coleccionable")){
            audioSource.Play();
            other.gameObject.SetActive(false);
            contador = contador + 1;
            setTextoContador();
        }    
    }

    void setTextoContador(){
        textoContador.text = "Contador: "+ contador.ToString();
        if(contador>=12){
            textoGanar.text="¡Ganaste!";
            Invoke("reiniciar",5f);
        }
    }

    void reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
