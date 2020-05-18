using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PetriDish : MonoBehaviour
{
    private int textureSize = 64;
    private int textureWidth;
    private int textureHeight;
    private int swabSize;

    private Texture2D texture;
    private Color[] color;

    public Color petriColor; // for allowing us to change swabcolors
    public bool swabComplete = false; // we'll need to know if the swab is complete for a later test
    private float pixelcount = 0f; // for checking how much has been swabbed

    private Color currentSwabColor;
    private bool touching, touchingLast;
    private float posX, posY;
    private float lastX, lastY;

    private GameObject glow;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        texture = new Texture2D(textureSize, textureSize);
        renderer.material.mainTexture = texture;

        glow = gameObject.transform.Find("LightSource").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        int x = (int)(posX * textureSize - (swabSize / 2));
        int y = (int)(posY * textureSize - (swabSize / 2));


        checkIfSwabComplete(0.5f); // half-covered seems decent
       
        
        if (touchingLast && !swabComplete && currentSwabColor.Equals(petriColor)) // we want to check if the swab is "correct" (we'll use color to check) //add glow...
        {
            // Debug.Log(x + " " + y + " " + gameObject.name);
            texture.SetPixels(x, y, swabSize, swabSize, color);

            for (float t = 0.01f; t < 1.0f; t += 0.01f)
            {
                int lerpX = (int)Mathf.Lerp(lastX, (float)x, t);
                int lerpY = (int)Mathf.Lerp(lastY, (float)y, t);
                texture.SetPixels(lerpX, lerpY, swabSize, swabSize, color);
                texture.Apply();
            }

            
        }
        
        
        if (swabComplete)
        {
            glow.GetComponent<Light>().color = petriColor;
            glow.SetActive(true);
        }

        lastX = (float)x;
        lastY = (float)y;

        touchingLast = touching;
        
    }

    public void setSwabSize(int swabTipSize)
    {
        swabSize = swabTipSize;
    }

    private void checkIfSwabComplete(float desiredRatio) 
    {
        // this updates the swabComplete bool above
        // by iterating through all the pixels and checking
        // if it is above a certain ratio
        Color[] pixels = texture.GetPixels();
        
        for (int i = 0; i < pixels.Length; ++i)
        {
            float colorRatio = pixelcount / (float)pixels.Length;
            
            if (colorRatio > desiredRatio)
            {
                swabComplete = true;
            }

            // Debug.Log(pixels[i].ToString() + "" + petriColor.ToString());

            if (pixels[i].Equals(petriColor))
            {
                
                pixelcount += 1.0f;
            }

            
        }
        Debug.Log(pixelcount / (float)pixels.Length);
      



        pixelcount = 0.0f;
        
    }


    public void ToggleSwab(bool touching)
    {
        this.touching = touching;
    }

    public void SetTouchPosition(float x, float y)
    {
        this.posX = x;
        this.posY = y;

    }

    public void SetColor(Color swabColor)
    {
        currentSwabColor = swabColor;
        color = Enumerable.Repeat<Color>(swabColor, swabSize * swabSize).ToArray<Color>();
    }
}
