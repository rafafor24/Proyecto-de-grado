using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveCharacter : Photon.MonoBehaviour
{
    public Animator animator;

    public CoordsPlayer coords;

    public TextMeshProUGUI decision;

    public Dialogue dec;

    // Start is called before the first frame update
    void Start()
    {
        coords = new CoordsPlayer(3,1,-1,-1,transform.position);
        transform.position = new Vector3 (coords.x * 7, coords.y * 7,0);
        if (coords.decisionId != -1)
        {
            decision.text = "Ultima Decision: " + dec.sentences[coords.decisionId];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}
