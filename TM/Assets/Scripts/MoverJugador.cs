using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoverJugador : MonoBehaviour
{

    private GameObject jugador;
    public float speed = 10.0f;
    private bool moving;
    private StationsId stationId;


    public const string ARRIBA = "arriba";
    public const string ABAJO = "abajo";
    public const string IZQUIERDA = "izquierda";
    public const string DERECHA = "derecha";
    public const string QUIETO = "quieto";

    public int id;
    public bool seleccionado;
    public CoordsPlayer coords;

    // Start is called before the first frame update
    void Start()
    {
        seleccionado = false;
        jugador = GameObject.FindGameObjectsWithTag("Player")[0];
        moving = false;
        stationId= (StationsId)GetComponent("StationsId");
    }

    public void setId(int i)
    {
        id = i;
    }
    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Playerprefs: idEst: " + PlayerPrefs.GetInt("idEst") + " Este es el id de la estacion: " + id);

        }*/

        if (id== coords.estId)
        {
            print("WDF"+ coords.estId + " Este es el id: "+id);
            Mover();
            coords.estId = -1;
        }
        if (moving)
        {
            print("Entra a if moving update");
            float step = speed * Time.deltaTime;

            jugador.transform.position = Vector3.MoveTowards(jugador.transform.position, transform.position, step);
            
            if (Vector3.Distance(jugador.transform.position, transform.position) < 0.001f)
            {
                jugador.GetComponent<MoveCharacter>().ChangeTrigger(QUIETO);
                moving = false;
                coords.x = stationId.idX;
                coords.y = stationId.idY;
            }
        }
    }

    public void Mover()
    {
        
        print("Entra a Mover");
        if ((coords.x == stationId.idX && ((coords.y == (stationId.idY + 1)) || (coords.y == (stationId.idY - 1))))
            || (coords.y == stationId.idY && ((coords.x == (stationId.idX + 1)) || (coords.x == (stationId.idX - 1)))))
        {
            if (Mathf.Sqrt(Mathf.Pow((jugador.transform.position.x - transform.position.x), 2)) >
                               Mathf.Sqrt(Mathf.Pow((jugador.transform.position.y - transform.position.y), 2)))
            {
                if (jugador.transform.position.x > transform.position.x)
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
    public void Click()
    {
        seleccionado = true;
        print("cid" + coords.estId + "id" + id);
        SceneManager.LoadScene(3);        
    }

    void OnDisable()
    {
        if (seleccionado)
        {
            coords.estId = id;
            coords.decisionId = -1;
        }
    }

    void OnEnable()
    {
        
    }
}
