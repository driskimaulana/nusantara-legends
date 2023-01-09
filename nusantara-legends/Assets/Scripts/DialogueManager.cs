using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    private string[] names;

    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI dialogueText;

    private int currentCharacter = 1;

    public GameObject dialogueBoxUI;
    public GameObject story1UI;
    public GameObject story2UI;
    public GameObject hintText;

    private bool isBefore = false;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new string[2];
    }


    public void StartDialogue(Dialogue dialogue, bool isBefore)
    {

        sentences.Clear();
        dialogueBoxUI.SetActive(true);
        hintText.SetActive(false);
        Time.timeScale = 0f;

        foreach ( string sentence in dialogue.sentences )
        {
            sentences.Enqueue(sentence);
        }

        this.isBefore = isBefore;

        names[0] = dialogue.name[0];
        names[1] = dialogue.name[1];

    }

    public void DisplayNextSentence()
    {

        if(sentences.Count == 1 && isBefore)
        {
            ShowStory();
        }

        if(sentences.Count == 0 && !isBefore)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        nameText.text = names[currentCharacter];
        dialogueText.text = sentence;

        if(currentCharacter == 0)
        {
            currentCharacter = 1;
        }else
        {
            currentCharacter = 0;
        }

        Debug.Log(sentence);
    }

    public void EndDialogue()
    {
        Time.timeScale = 1f;
        dialogueBoxUI.SetActive(false);
        Debug.Log("End of conversation...");
    }

    public void ShowStory()
    {
        story1UI.SetActive(true);
        dialogueBoxUI.SetActive(false);
    }

    public void NextPageStory()
    {
        story1UI.SetActive(false);
        story2UI.SetActive(true);
    }

    public void BackToConversation()
    {
        story2UI.SetActive(false);
        Dialogue dialogue = new Dialogue();
        dialogue.name = new string[] {"Penduduk", "Nusa"};
        dialogue.sentences = new string[] {
            "Lalu kenapa tidak mencoba menghancurkan bendungan itu?",
            "Hal itu sudah pernah kita coba, tetapi bendungan seakan-akan meregenerasi tubuhnya. Satu-satunya cara adalah dengan menyadarkan dan mengalahkan kemarahan dalm diri Ayus.",
            "Bagaimana caraku untuk bertemu Ayus?",
            "Ayus tinggal di kastil di hulu sungai Mahakam, dan untuk bisa masuk ke dalam kastil tersebut kamu harus mengumpulkan tiga jenis air dari tiga anak sungai Mahakam.",
            "Baiklah aku akan menemui Ayus.",
        };

        StartDialogue(dialogue, false);
        dialogueBoxUI.SetActive(true);
    }
}
