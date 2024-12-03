using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text Dialoguetext;
   [SerializeField] private DialogueContainer dialogueContainer = new DialogueContainer();
    public static DialogueSystem instance;
   // private ConversationManager conversationManager = new ConversationManager();
 
   
   // public bool isRunningConversation => conversationManager.isRunning;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    public void Say(string speaker, string dialogue)
    {
        List<string> conversation = new List<string>() { $"{speaker}/*{dialogue}/*" };
        Say(conversation);
    }
    public void Say(List<string> conversation)
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
