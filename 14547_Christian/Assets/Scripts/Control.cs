using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Control : MonoBehaviour
{
    public float Jumpv = 0.4f;
    public float altura_salto = 10;
    public Rigidbody rb;
    public int Velocidad = 0;
    public float giro= 0;
    public float Horizontal = 0;
    public float vertical = 0;
    public float limite_x = 0;
    public float limite_z = 0;
    bool esta_en_suelo;
    int death_zone = 0;
    public int vida;
    public Transform teleportTarget2;
    public Transform teleportTarget3;
    public Transform teleportTarget4;
    public GameObject proyectil;
    public Transform Respawn_zone;

    public Text Msg_game_over;
    public Text continuar;
    // Start is called before the first frame update
    void Start()
    {
        Msg_game_over.enabled = false;
        continuar.enabled = false;
        esta_en_suelo = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {  
        /*
            && significan AND o la la palabra "Y"
            || significa OR o la palabra "O"
        */
       if(Input.GetKeyDown(KeyCode.Space) && esta_en_suelo == true ){
          Jump(); 
       }

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
        //LIMITAR EN EJE X VALOR POSITIVO
        if(vida > 0){
            Debug.Log(vida);
        if (transform.position.x < -limite_x || transform.position.x > limite_x ){
            vida = vida - 1;
            this.transform.position = Respawn_zone.transform.position;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //transform.position = new Vector3(-limite_x, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -limite_z || transform.position.z > limite_z){
             vida = vida - 1;
            this.transform.position = Respawn_zone.transform.position;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //transform.position = new Vector3(transform.position.x, transform.position.y, -limite_z);
        }
        } else{
            Msg_game_over.enabled=true;
                continuar.enabled= true;
             if(Input.GetKeyDown(KeyCode.T)){
            Msg_game_over.enabled =false;
            continuar.enabled= false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }  
        }
       /* if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(proyectil, transform.position + new Vector3(0, 0, 3), proyectil.transform.rotation);
        }*/
    }
    
    public void Jump(){
        esta_en_suelo = false;
        rb.AddForce(0, altura_salto, 0, ForceMode.Impulse);
    }

    public void morir1(){
        death_zone = 0;
        if(vida > 0){
            Debug.Log(vida);
            vida = vida - 1;
            this.transform.position = Respawn_zone.transform.position;
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
