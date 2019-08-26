using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{

    private GameObject jugador;
    public float speed = 10.0f;
    private bool moving;

    public const string ARRIBA = "arriba";
    public const string ABAJO = "abajo";
    public const string IZQUIERDA = "izquierda";
    public const string DERECHA = "derecha";
    public const string QUIETO = "quieto";

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectsWithTag("Player")[0];
        print("init");
        print(jugador.transform.position);
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (/*!jugador.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("moutionless") &&*/ moving)
        {
            float step = speed * Time.deltaTime;

            jugador.transform.position = Vector3.MoveTowards(jugador.transform.position, this.transform.position, step);
            
            if (Vector3.Distance(jugador.transform.position, transform.position) < 0.001f)
            {
                jugador.GetComponent<MoveCharacter>().ChangeTrigger(QUIETO);
                moving = false;
            }
        }
    }

    public void OnMouseDown()
    {

        
        if(Mathf.Sqrt(Mathf.Pow((jugador.transform.position.x - transform.position.x),2)) > 
                                Mathf.Sqrt(Mathf.Pow((jugador.transform.position.y - transform.position.y), 2)))
        {
            if (jugador.transform.position.x>transform.position.x)
            {
                jugador.GetComponent<MoveCharacter>().ChangeTrigger(IZQUIERDA);
            }
            else
            {
                jugador.GetComponent<MoveCharacter>().ChangeTrigger(DERECHA);
            }
        }
        else
        {
            if (jugador.transform.position.y > transform.position.y)
            {
                jugador.GetComponent<MoveCharacter>().ChangeTrigger(ABAJO);
            }
            else
            {
                jugador.GetComponent<MoveCharacter>().ChangeTrigger(ARRIBA);
            }
        }
        moving = true;
    }
}
