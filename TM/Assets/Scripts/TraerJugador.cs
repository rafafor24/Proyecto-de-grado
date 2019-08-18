using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraerJugador : MonoBehaviour
{
    
    private GameObject jugador;
    public  bool moving;
    public float speed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        jugador= GameObject.FindGameObjectsWithTag("Player")[0];
        print("init");
        print(jugador.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
            if (moving)
            {
                float step = speed * Time.deltaTime;
                jugador.transform.position = Vector3.MoveTowards(jugador.transform.position, transform.position, step);
                if (Vector3.Distance(jugador.transform.position, transform.position) < 0.001f)
                {
                    moving = false;
                jugador.GetComponent<Move>().toggleWalk();

            }
        }
        
    }

    public void OnMouseDown()
    {
        moving = true;
        jugador.GetComponent<Move>().toggleWalk();
    }
}
