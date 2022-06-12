using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    [SerializeField] GameObject paperPrefab;
    public Vector2Int size = new Vector2Int(100, 100);
    public float printSpeed = 2f;

    public GameObject IGSEvidence;
    public GameObject DNAEvidence;
    public GameObject WitnessReport1;
    public GameObject WitnessReport2;
    public GameObject DoctorsNote;
    public GameObject FlaggelationDoc;
    public GameObject GramStainDoc;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            ScreenShot();
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            Debug.Log("Printing IGS Evidence");
            PrintWitnessReport1();
            //Level1Events.current.DNADone();
        }
    }

    IEnumerator Print(Rigidbody rb, Vector3 dir, float dist)
    {
        yield return new WaitForFixedUpdate();

        float f = Time.fixedDeltaTime * printSpeed;

        while (dist > f)
        {
            dist -= f;
            rb.MovePosition(rb.position + dir * f);
            yield return new WaitForFixedUpdate();
            f = Time.fixedDeltaTime * printSpeed;
        }

        rb.MovePosition(rb.position + dir * dist);


        rb.isKinematic = false;
    }

    public void PrintImage(Sprite sprite)
    {
        int width = size.x;
        int height = size.y;

        Texture2D blank = new Texture2D(width, height, TextureFormat.RGB24, false);

        GameObject ss = Instantiate(paperPrefab);
        ss.tag = "Screenshot";
        ss.transform.rotation = transform.rotation;
        ss.transform.position = transform.position + transform.rotation * Vector3.up * height / 200f;

        ss.GetComponent<BoxCollider>().size = new Vector3(size.x / 100f, size.y / 100f, 0.05f);

        SpriteRenderer[] srs = ss.GetComponentsInChildren<SpriteRenderer>();
        srs[0].transform.localScale = new Vector3(width / sprite.textureRect.width, height / sprite.textureRect.height, 1);
        srs[0].sprite = sprite;
        srs[1].sprite = Sprite.Create(blank, new Rect(0, 0, width, height), Vector2.one * 0.5f);

        StartCoroutine(Print(ss.GetComponent<Rigidbody>(), transform.rotation * Vector3.down, height / 100f));
    }

    public void PrintIGS()
    {
        GameObject evidence = Instantiate(IGSEvidence, transform.position, transform.rotation * Quaternion.Euler(0, 90f, 0));
        StartCoroutine(Print(evidence.GetComponent<Rigidbody>(), evidence.transform.rotation * Vector3.down, 1f));
    }
    public void PrintDNA()
    {
        GameObject evidence = Instantiate(DNAEvidence, transform.position, transform.rotation * Quaternion.Euler(0, 90f, 0));
        StartCoroutine(Print(evidence.GetComponent<Rigidbody>(), evidence.transform.rotation * Vector3.down, 1f));
    }
    public void PrintWitnessReport1()
    {
        GameObject evidence = Instantiate(WitnessReport1, transform.position, transform.rotation * Quaternion.Euler(0, 90f, 0));
        StartCoroutine(Print(evidence.GetComponent<Rigidbody>(), evidence.transform.rotation * Vector3.down, 1f));
    }
    public void PrintWitnessReport2()
    {
        GameObject evidence = Instantiate(WitnessReport2, transform.position, transform.rotation * Quaternion.Euler(0, 90f, 0));
        StartCoroutine(Print(evidence.GetComponent<Rigidbody>(), evidence.transform.rotation * Vector3.down, 1f));
    }
    public void PrintDoctorsNote()
    {
        GameObject evidence = Instantiate(DoctorsNote, transform.position, transform.rotation * Quaternion.Euler(0, 90f, 0));
        StartCoroutine(Print(evidence.GetComponent<Rigidbody>(), evidence.transform.rotation * Vector3.down, 1f));
    }
    public void PrintFlaggelationDoc()
    {
        GameObject evidence = Instantiate(FlaggelationDoc, transform.position, transform.rotation * Quaternion.Euler(0, 90f, 0));
        StartCoroutine(Print(evidence.GetComponent<Rigidbody>(), evidence.transform.rotation * Vector3.down, 1f));
    }
    public void PrintGramStainDoc()
    {
        GameObject evidence = Instantiate(GramStainDoc, transform.position, transform.rotation * Quaternion.Euler(0, 90f, 0));
        StartCoroutine(Print(evidence.GetComponent<Rigidbody>(), evidence.transform.rotation * Vector3.down, 1f));
    }

    public void ScreenShot()
    {
        int width = size.x < size.y ? 800 : 800 * size.x / size.y;
        int height = size.x < size.y ? 800 * size.y / size.x : 800;

        Camera camera = Camera.main;
        RenderTexture tempRT = new RenderTexture(width, height, 24);
        camera.targetTexture = tempRT;
        camera.Render();
        RenderTexture.active = tempRT;
        Texture2D texture = new Texture2D(width, height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        texture.Apply();
        RenderTexture.active = null;
        camera.targetTexture = null;

        PrintImage(Sprite.Create(texture, new Rect(0, 0, width, height), Vector2.one * 0.5f, 100));
    }
}
