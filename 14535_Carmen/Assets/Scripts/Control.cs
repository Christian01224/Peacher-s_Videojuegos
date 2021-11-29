using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //manejador de escenas->subir de nivel, resetear, game over
using UnityEngine.UI; //Interfaces de Usuario
public class Control : MonoBehaviour
{
    public float Jumpv = 0.4f; // f-> fuerza o impulso
    public float altura_salto = 10;
    public Rigidbody rb;

    public int Velocidad = 0; //manipular desde unity --> en cambio una privada solamente se maneja en el script/no publico
    public float giro= 0; //evitar giros bruscos
    public float Horizontal = 0;
    public float vertical = 0; //usar en minúscula vertical

    public float limite_x = 0;
    public float limite_z = 0;

    bool esta_en_suelo;
    int death_zone = 0; //zona que mata al personaje -> pierde una vida
    public int vida;
    public Transform teleportTarget2; //teletrasportar 
    public Transform teleportTarget3;
    public Transform teleportTarget4;
    public GameObject proyectil;
    public Transform Respawn_zone; //zona de reaparicion->reseteo

    public Text Msg_game_over;
    public Text continuar;

    // Start is called before the first frame update
    void Start()
    {
        Msg_game_over.enabled = false; //ocultar
        continuar.enabled = false;
        esta_en_suelo = true; //primer estado
        rb = GetComponent<Rigidbody>(); //obtener el valor del rigibody
    }

    // Update is called once per frame
    void Update()
    {  
        /*  significado:
            && -> AND (en español "Y")
            || -> OR (en español "O") -> comparaciones*/
    
        // tecla space -> salto 
       if(Input.GetKeyDown(KeyCode.Space) && esta_en_suelo == true ){
          Jump(); 
       }

       //death_zone -> mata al personaje, # nivel
       if(death_zone == 1){
          morir1(); 
       }else if(death_zone == 2){
           morir2();
       }else if(death_zone == 3){
           morir3();
        }else if (death_zone == 4){
            morir4();
        }

        Horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * Velocidad * vertical);
        transform.Translate(Vector3.right * Time.deltaTime * giro * Horizontal);


        // LIMITAR EJE X -> POSITIVO
        if(vida > 0){
            Debug.Log(vida);
        if (transform.position.x < -limite_x || transform.position.x > limite_x ){
            vida = vida - 1;
            this.transform.position = Respawn_zone.transform.position;
            ///this -> objeto, cambie su posicion cuando sea igual a la zona de respawn
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name); -> resetear escena
            //transform.position = new Vector3(-limite_x, transform.position.y, transform.position.z);
        }
        // LIMITAR EJE Z 
        if (transform.position.z < -limite_z || transform.position.z > limite_z){
             vida = vida - 1;
            this.transform.position = Respawn_zone.transform.position;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name); -> resetear escena
            //transform.position = new Vector3(transform.position.x, transform.position.y, -limite_z);
        }
        } else
        {
            Msg_game_over.enabled=true;
                continuar.enabled= true;
             if(Input.GetKeyDown(KeyCode.T)){
            Msg_game_over.enabled =false;
            continuar.enabled= false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } 
        }
       /*Input-> activando una tecla, GetKeyDown-> Qué tecla voy a precionar,
            KeyCode->Traer el código de la tecla que presiona
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(proyectil, transform.position + new Vector3(0, 0, 3), proyectil.transform.rotation);
        }*/
    }
    
    public void Jump(){
        esta_en_suelo = false;
        rb.AddForce(0, altura_salto, 0, ForceMode.Impulse);
    }

    // colider -> el borde ("alma" del objeto) 
    /* other-> cubre todas las caras del objeto, GameObject-> se declara al objeto asignado,
        CompareTag-> comparar la etiqueta */

        // -vidas
    public void morir1(){
        death_zone = 0;
        if(vida > 0){
            Debug.Log(vida);
            vida = vida - 1;
            this.transform.position = Respawn_zone.transform.position; // si muere-> regresar al raspawn correspondiente
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //transform.position = new Vector3(transform.position.x, transform.position.y, -limite_z);
        } else{
            Msg_game_over.enabled=true; //activar game over
                continuar.enabled= true; // texto presionar tecla para continuar -> tecla T
             if(Input.GetKeyDown(KeyCode.T)){
            Msg_game_over.enabled =false;
            continuar.enabled= false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }  
        }
    }
    
    public void morir2(){
        death_zone = 0;
        if(vida > 0){
            Debug.Log(vida);
            vida = vida - 1;
            this.transform.position = teleportTarget2.transform.position;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //transform.position = new Vector3(transform.position.x, transform.position.y, -limite_z);
        } else{
            Msg_game_over.enabled=true;
                continuar.enabled= true;
             if(Input.GetKeyDown(KeyCode.T)){
            Msg_game_over.enabled =false;
            continuar.enabled= false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }  
        }
    }

    public void morir3(){
        death_zone = 0;
        if(vida > 0){
            Debug.Log(vida);
            vida = vida - 1;
            this.transform.position = teleportTarget3.transform.position;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //transform.position = new Vector3(transform.position.x, transform.position.y, -limite_z);
        } else{
            Msg_game_over.enabled=true;
                continuar.enabled= true;
             if(Input.GetKeyDown(KeyCode.T)){
            Msg_game_over.enabled =false;
            continuar.enabled= false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }  
        }
    }

    public void morir4(){
        death_zone = 0;
        if(vida > 0){
            Debug.Log(vida);
            vida = vida - 1;
            this.transform.position = teleportTarget4.transform.position;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //transform.position = new Vector3(transform.position.x, transform.position.y, -limite_z);
        } else{
            Msg_game_over.enabled=true;
                continuar.enabled= true;
             if(Input.GetKeyDown(KeyCode.T)){
            Msg_game_over.enabled =false;
            continuar.enabled= false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }  
        }
    }


    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Suelo")){
            esta_en_suelo = true;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("death_zone")){
            death_zone = 1;
        }else if(other.gameObject.CompareTag("death_zone2")){
            death_zone = 2;
        }else if(other.gameObject.CompareTag("death_zone3")){
            death_zone = 3;
        }else if(other.gameObject.CompareTag("death_zone4")){
            death_zone = 4;
        }
    }

}
