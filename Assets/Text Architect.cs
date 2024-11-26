using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
public class TextArchitect : MonoBehaviour
{
    public Text Text_UI;
    public Text Text_world;
    public Text text => Text_UI != null ? Text_UI : Text_world;

    public string currentText => text.text;
    public string targettext { get; private set; } = "";
    public string pretext { get; private set; } = "";
    private int TextLength = 0;
    public string Fulltargettext => pretext + targettext;
    public enum BuildMethod { instant, typewriter, fade}
    public BuildMethod buildMethod = BuildMethod.typewriter;
    public Color textcolor { get { return text.color; } set { text.color = value; } }
    public float speed { get { return Basespeed * Speedmultiplier; } set { Speedmultiplier = value; } }
    private const float Basespeed = 1;
    private float Speedmultiplier = 1;

    public int  CharacterPerCycle { get { return speed <= 2f ? Charactermultiplier : speed <= 2.5f ? Charactermultiplier * 2 : Charactermultiplier * 3; } }
    private int Charactermultiplier = 1;
    public bool Hurryup = false;

    public TextArchitect()
    {
        Text_UI = Text_UI ?? Text_world;
    }
  
    public Coroutine Build(string text)
    {
        pretext = "";
        targettext = text;
        Stop();
            buildProcess = StartCoroutine(Building());
        return buildProcess;
    }

    public Coroutine Append(string text)
    {
        pretext = text;
        targettext = text;
        Stop();
        buildProcess = StartCoroutine(Building());
        return buildProcess;
    }

    private Coroutine buildProcess = null;
    public bool isBuilding => buildProcess != null;
    public void Stop()
    {
        if (!isBuilding)
            return;
        StopCoroutine(buildProcess);
        buildProcess = null;

    }
   private  IEnumerator Building()
    {
        Prepare();
        switch (buildMethod)
        {
            case BuildMethod.typewriter:
                yield return Build_Typewriter();
                break;
            case BuildMethod.fade:
                yield return Build_Fade();
                break;



        }
        Oncomplete();
    }

    private void Oncomplete()
    {
        buildProcess = null;
        Hurryup = false;
    }
    public void ForceComplete()
    {
        switch (buildMethod)
        {
            case BuildMethod.typewriter:
                text.text = Fulltargettext;
                break;
            case BuildMethod.fade:
                text.color = new Color(textcolor.r, textcolor.g, textcolor.b, 1);
                break;
        }
        Stop();
        Oncomplete();
    }
    private void Prepare()
    {
        switch (buildMethod)
        {
            case BuildMethod.instant:
                Prepare_Instant();
                break;
            case BuildMethod.typewriter:
                Prepare_Typewriter();
                break;
            case BuildMethod.fade:
                Prepare_Fade();
                break;

        }
    }
    private void Prepare_Instant()
    {
        text.text = Fulltargettext;
        text.color = text.color;

    }
    private void Prepare_Typewriter()
    {
        text.text = pretext;
       
    }
    private void Prepare_Fade()
    {
        text.text = pretext + targettext;
        text.color = new Color(textcolor.r, textcolor.g, textcolor.b, 0);
    }
    private IEnumerator Build_Typewriter()
    {
        text.text = pretext;
        int charIndex = 0;
        while (charIndex < targettext.Length)
        {
            text.text = pretext + targettext.Substring(0, charIndex + 1);
            charIndex++;
            yield return new WaitForSeconds(0.015f / speed);
        }
    }
    private IEnumerator Build_Fade()
    {
        text.text = pretext + targettext;       
            
       float fadespeed = ((Hurryup ? CharacterPerCycle * 5 : CharacterPerCycle)* speed) * 4f ;
        Color startColor = new Color(textcolor.r, textcolor.g, textcolor.b, 0);
        Color targetColor = new Color(textcolor.r, textcolor.g, textcolor.b, 1);


        float currentAlpha = 0f;
        while (currentAlpha < 1f)
        {
            currentAlpha += fadespeed * Time.deltaTime;
            currentAlpha = Mathf.Clamp01(currentAlpha);
            text.color = new Color(textcolor.r, textcolor.g, textcolor.b, currentAlpha);
            yield return new WaitForEndOfFrame();
        }
        textcolor = targetColor;
        }
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
