using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{

    public string speaker;
    public string dialogue;
    public string commands;
    // Start is called before the first frame update


    public DialogueLines(string speaker, string dialogue, string commands)
    {
        this.speaker = speaker;
            this.dialogue = dialogue;
        this.commands = commands;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
