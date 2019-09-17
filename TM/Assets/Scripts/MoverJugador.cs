using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    

    public GameObject meta;
    public bool metaBool=false;

    public int id;
    public bool seleccionado;

    private CoordsPlayer coords;

    private MenuLogic ml;
    // Start is called before the first frame update
    void Start()
    {
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        coords = ml.getCoords();
        seleccionado = false;
        moving = false;
        stationId= (StationsId)GetComponent("StationsId");
    }

    public void setId(int i)
    {
        id = i;
    }

    public void estadoMeta(bool state)
    {
        meta.SetActive(state);
    }

    // Update is called once per frame
    void Update()
    {
        jugador = GameObject.FindGameObjectWithTag("Player") ? GameObject.FindGameObjectWithTag("Player") : new GameObject();
        
        if (id== coords.estId)
        {
            Mover();
            coords.estId = -1;
            ml.updateCoords(coords);
        }
        if (moving)
        {
            float step = speed * Time.deltaTime;

            jugador.transform.position = Vector3.MoveTowards(jugador.transform.position, transform.position, step);
            
            if (Vector3.Distance(jugador.transform.position, transform.position) < 0.001f)
            {
                jugador.GetComponent<MoveCharPhoton>().ChangeTrigger(QUIETO);
                moving = false;
                #if UNITY_EDITOR
                EditorUtility.SetDirty(coords);
                #endif
                coords.x = stationId.idX;
                coords.y = stationId.idY;
                ml.updateCoords(coords);


            }
        }
    }

    public void Mover()
    {
        //if ((coords.x == stationId.idX && ((coords.y == (stationId.idY + 1)) || (coords.y == (stationId.idY - 1))))
        //    || (coords.y == stationId.idY && ((coords.x == (stationId.idX + 1)) || (coords.x == (stationId.idX - 1))))){
            if (Mathf.Sqrt(Mathf.Pow((jugador.transform.position.x - transform.position.x), 2)) >
                               Mathf.Sqrt(Mathf.Pow((jugador.transform.position.y - transform.position.y), 2)))
            {
                if (jugador.transform.position.x > transform.position.x)
                {
                    jugador.GetComponent<MoveCharPhoton>().ChangeTrigger(IZQUIERDA);
                }
                else
                {
                    jugador.GetComponent<MoveCharPhoton>().ChangeTrigger(DERECHA);
                }
            }
            else
            {
                if (jugador.transform.position.y > transform.position.y)
                {
                    jugador.GetComponent<MoveCharPhoton>().ChangeTrigger(ABAJO);
                }
                else
                {
                    jugador.GetComponent<MoveCharPhoton>().ChangeTrigger(ARRIBA);
                }
            }
            moving = true;
       // }
        }
    public void Click()
    {
        if ((coords.x == stationId.idX && ((coords.y == (stationId.idY + 1)) || (coords.y == (stationId.idY - 1))))
            || (coords.y == stationId.idY && ((coords.x == (stationId.idX + 1)) || (coords.x == (stationId.idX - 1)))))
        {
            seleccionado = true;
            PhotonNetwork.LoadLevel("Instr. #1");
            PhotonNetwork.LeaveRoom();
        }
    }

    void OnDisable()
    {
        if (seleccionado)
        {
            #if UNITY_EDITOR
            EditorUtility.SetDirty(coords);
            #endif
            coords.estId = id;
            coords.decisionId = -1;
            ml.updateCoords(coords);
        }
    }

    void OnEnable()
    {
        
    }
}
