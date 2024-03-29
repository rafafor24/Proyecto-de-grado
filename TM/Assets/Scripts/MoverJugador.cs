﻿using System.Collections;
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

    private EsperarJugador ej;

    private GameObject avisoEsperarJugador;

    private DecisionesTomadas decisionesTomadas;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        coords = ml.getCoords();
        ej = ml.GetEsperarJugador();
        decisionesTomadas = ml.GetDecisionesTomadas();
        ej.jugar[0] = false;
        ej.jugar[1] = false;

        avisoEsperarJugador = GameObject.Find("EsperaJugador");

        avisoEsperarJugador.transform.localScale = new Vector3(0, 0, 0);

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
        avisoEsperarJugador = GameObject.Find("EsperaJugador");
        

        if (ej.mostrarAviso)
        {
            if (ej.jugar[0] && ej.jugar[1])
            {
                ej.mostrarAviso = false;

                if (decisionesTomadas.pos == -1)
                {
                    PhotonNetwork.LoadLevel("Decision #1");
                    PhotonNetwork.LeaveRoom();
                }
                else if (decisionesTomadas.pos == 0)
                {
                    PhotonNetwork.LoadLevel("Decision #1");
                    PhotonNetwork.LeaveRoom();
                }
                else if (decisionesTomadas.pos == 1)
                {
                    PhotonNetwork.LoadLevel("Decision #2");
                    PhotonNetwork.LeaveRoom();
                }
                else if (decisionesTomadas.pos == 2)
                {
                    PhotonNetwork.LoadLevel("Decision #3");
                    PhotonNetwork.LeaveRoom();
                }
            }
        }

        if (id== coords.estId)
        {
            Mover();
            coords.estId = -1;
            ml.updateCoords(coords);
        }
        if (moving)
        {
            float step = speed * Time.deltaTime;
            Vector3 newvector = ml.player1?new Vector3(-1, 0, 0): new Vector3(1, 0, 0);
                
            jugador.transform.position = Vector3.MoveTowards(jugador.transform.position, transform.position+newvector, step);            

            if (Vector3.Distance(jugador.transform.position, transform.position+newvector) < 0.001f)
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

        if ((coords.x == stationId.idX && ((coords.y == (stationId.idY + 1)) || (coords.y == (stationId.idY - 1))))
            || (coords.y == stationId.idY && ((coords.x == (stationId.idX + 1)) || (coords.x == (stationId.idX - 1)))))
        {
            animator.SetBool("parpadear", true);
        }
        else
        {
            animator.SetBool("parpadear", false);

        }
    }

    public void Mover()
    {
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
        }

    public void Click()
    {
        if (((coords.x == stationId.idX && ((coords.y == (stationId.idY + 1)) || (coords.y == (stationId.idY - 1))))
            || (coords.y == stationId.idY && ((coords.x == (stationId.idX + 1)) || (coords.x == (stationId.idX - 1))))) && ml.allowClick)
        {

            seleccionado = true;
            ej.jugar[0] = true;
            ml.allowClick = false;
                        

            if (ej.jugar[0] && !ej.jugar[1])

            {
                ej.mostrarAviso = true;
                avisoEsperarJugador.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (ej.jugar[0] && ej.jugar[1])
            {
                ej.mostrarAviso = false;
                StartCoroutine(EsperarCambio());
            }

            
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

    IEnumerator EsperarCambio()
    {
        yield return new WaitForSeconds(1);
        if (decisionesTomadas.pos==-1)
        {
            PhotonNetwork.LoadLevel("Decision #1");
            PhotonNetwork.LeaveRoom();
        } else if (decisionesTomadas.pos == 0)
        {
            PhotonNetwork.LoadLevel("Decision #1");
            PhotonNetwork.LeaveRoom();
        }
        else if (decisionesTomadas.pos == 1)
        {
            PhotonNetwork.LoadLevel("Decision #2");
            PhotonNetwork.LeaveRoom();
        }
        else if (decisionesTomadas.pos == 2)
        {
            PhotonNetwork.LoadLevel("Decision #3");
            PhotonNetwork.LeaveRoom();
        }

    }
}
