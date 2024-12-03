using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testingba : MonoBehaviour
{
   DialogueSystem ds;
  TextArchitect architect;
    string[] lines = new string[4]
    {
        "This is a random line" ,
        "Nice to meet you, are you good?" ,
        "It is alright, how about you?" ,
        "I'm alright too, thank you."





    };

    // Start is called before the first frame update
    void Start()
    {

        ds = DialogueSystem.instance;

        if (ds != null && ds.Dialoguetext != null)
        {
          
            architect = new TextArchitect(ds.Dialoguetext,this);
            architect.buildMethod = TextArchitect.BuildMethod.typewriter;
        }
        else
            Debug.LogError("DialogueContainer or Dialoguetext is not correctly initialized.");
        {
        }
    }
        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (architect.isBuilding)
                {
                    if (!architect.Hurryup)
                        architect.Hurryup = true;
                    else
                        architect.ForceComplete();
                }
                else
                {
                    architect.Build(lines[Random.Range(0, lines.Length)]);
                }
            }

            else if (Input.GetKeyDown(KeyCode.Q))
            {
                architect.Append(lines[Random.Range(0, lines.Length)]);
            }
        }
    }
