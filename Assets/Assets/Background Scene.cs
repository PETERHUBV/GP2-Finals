using UnityEngine;
using UnityEngine.UI;
public class BackgroundScene : MonoBehaviour
{
    public Image backgroundImage;   
    public Sprite[] backgrounds;    

    private int currentBackgroundIndex = 0; 

    void Start()
    {
        
        if (backgrounds.Length > 0)
        {
            backgroundImage.sprite = backgrounds[currentBackgroundIndex];
        }
        else
        {
            Debug.LogError("No backgrounds assigned.");
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleBackground();
        }
    }

    void ToggleBackground()
    {
        
        currentBackgroundIndex = (currentBackgroundIndex + 1) % backgrounds.Length;

       
        backgroundImage.sprite = backgrounds[currentBackgroundIndex];
    }
}
