using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRTK;

public class PetriDish : MonoBehaviour
{
    public GameObject petri_dish;
    private int textureSize = 64;
    private int textureWidth;
    private int textureHeight;
    private int swabSize;

    private Texture2D texture2d;
    public RenderTexture texture;
    private Color[] color;

    public Color petriColor; // for allowing us to change swabcolors
    private Color originalColor;
    public bool swabComplete = false; // we'll need to know if the swab is complete for a later test
    private float pixelcount = 0f; // for checking how much has been swabbed

    private Color currentSwabColor;
    private bool touching, touchingLast;
    private float posX, posY;
    private float lastX, lastY;
    private bool swabAlreadyCompleted;

    private GameObject glow;

    private AIVoice aiVoice;

    private int testingPixel;





    // Start is called before the first frame update
    void Start()
    {
        originalColor = new Color(0.000f, 0.000f, 0.000f, 1.000f);

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = texture;
        

        glow = gameObject.transform.Find("LightSource").gameObject;
        aiVoice = FindObjectOfType<AIVoice>();
        swabAlreadyCompleted = false;

        /**
        texture2d = toTexture2D(texture);
        Color[] pixels = texture2d.GetPixels();
        for (int i = 0; i < pixels.Length; i++)
        {
            UnityEngine.Debug.Log(pixels[i].ToString());
        }
        **/
        testingPixel = 0;
    }

    // Update is called once per frame
    void Update()
    {

        int x = (int)(posX * (textureSize - (swabSize / 2)));
        int y = (int)(posY * (textureSize - (swabSize / 2)));

        if (!swabComplete)
        {
            checkIfSwabComplete(0.5f); // half-covered seems decent
        }
        
       
        /***
        if (touchingLast && !swabComplete && currentSwabColor.Equals(petriColor)) // we want to check if the swab is "correct" (we'll use color to check) //add glow...
        {
            // Debug.Log(x + " " + y + " " + gameObject.name);
            texture.SetPixels(x, y, swabSize, swabSize, color);
            //UnityEngine.Debug.Log(x.ToString() + " | " + y.ToString());

            for (float t = 0.01f; t < 1.0f; t += 0.01f)
            {
               
                int lerpX = (int)Mathf.Lerp(lastX, (float)x, t);
                int lerpY = (int)Mathf.Lerp(lastY, (float)y, t);
                //UnityEngine.Debug.Log(lerpX.ToString() + " | " + lerpY.ToString());
                texture.SetPixels(lerpX, lerpY, swabSize, swabSize, color);
                texture.Apply();
            }

            
        }
        
        */
        if (swabComplete && !swabAlreadyCompleted)
        {
            glow.GetComponent<Light>().color = petriColor;
            glow.SetActive(true);
            swabAlreadyCompleted = true;
        }

        lastX = (float)x;
        lastY = (float)y;

        touchingLast = touching;
        
    }
    
    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        RenderTexture.active = null;
        return tex;
    }
    

    /**
    public Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D dest = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
        dest.Apply(false);
        Graphics.CopyTexture(rTex, dest);
        return dest;
    }
    **/

    public void setSwabSize(int swabTipSize)
    {
        swabSize = swabTipSize;
    }

    private void checkIfSwabComplete(float desiredRatio) 
    {
        // this updates the swabComplete bool above
        // by iterating through all the pixels and checking
        // if it is above a certain ratio
        texture2d = toTexture2D(texture);
        Color[] pixels = texture2d.GetPixels();
        //UnityEngine.Debug.Log("Pixel " + testingPixel.ToString() + " value: " + pixels[testingPixel].ToString());
        for (int i = 0; i < pixels.Length; ++i)
        {
            float colorRatio = pixelcount / (float)pixels.Length;
            
            if (colorRatio > desiredRatio)
            {

                swabComplete = true;
                petri_dish.tag = "DNA";
                Level1Events.current.PetriSwabbed();
                aiVoice.ReadVoiceClip(75);
                MakeMovable();
            }

            // Debug.Log(pixels[i].ToString() + "" + petriColor.ToString());

            Color currentPixel = pixels[i];
            //  && currentPixel.g < 1.000f && currentPixel.b < 1.000f
            if (currentPixel.r > 0.010f)
            {
                //UnityEngine.Debug.Log("Pixel passed"); MAY BE THE CAUSE FOR THE CRASH
                pixelcount += 1.0f;
            }

            
        }

        /*
        testingPixel++;
        if (testingPixel >= pixels.Length)
        {
            testingPixel = 0;
        }
        */
        pixelcount = 0.0f;
        
    }


    public void ToggleSwab(bool touching)
    {
        this.touching = touching;
    }

    public void SetTouchPosition(float x, float y)
    {
        UnityEngine.Debug.Log(x.ToString() + " | " + y.ToString());
        this.posX = x;
        this.posY = y;

    }

    public void SetColor(Color swabColor)
    {
        currentSwabColor = swabColor;
        color = Enumerable.Repeat<Color>(swabColor, swabSize * swabSize).ToArray<Color>();
    }


    // Due to bugs related to moving the dish while trying to swab it, it is locked in place until it is completed
    // To lock it in place, it was amde kinematic and gravity was turened off
    private void MakeMovable()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        VRTK_InteractableObject obj = gameObject.GetComponent<VRTK_InteractableObject>();
        obj.isGrabbable = true;
    }
}
