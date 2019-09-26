using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public Dialogue dialogue;


    private Queue<string> sentences;

    private MenuLogic ml;

    private DecisionesTomadas decisiones;

    // Use this for initialization
    void Start()
    {
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        decisiones = ml.GetDecisionesTomadas();
        sentences = new Queue<string>();
        StartDialogue();
    }

    public void StartDialogue()
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        //PhotonNetwork.LoadLevel("Decision #1");
        Debug.Log(decisiones.pos);
        if (decisiones.pos == -1)
        {
            PhotonNetwork.LoadLevel("Decision #1");
        }
        else if(decisiones.pos == 0)
        {
            PhotonNetwork.LoadLevel("Decision #1");
        }
        else if (decisiones.pos == 1)
        {
            PhotonNetwork.LoadLevel("Decision #2");
        }
        else if (decisiones.pos == 2)
        {
            PhotonNetwork.LoadLevel("Decision #3");
        }
    }

}