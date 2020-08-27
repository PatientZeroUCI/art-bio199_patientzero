using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    [SerializeField] GameObject paperPrefab;
    public Vector2Int size = new Vector2Int(100, 100);
    public float printSpeed = 2f;

    //public Sprite test;

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Z)) {
            ScreenShot();
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            PrintImage(test);
        }*/
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
        int height = 50;
        int width = 50;
        int length = 50;

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.rotation = transform.rotation;
        cube.transform.position = transform.position + transform.rotation * Vector3.up * height / 200f;
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<BoxCollider>().size = new Vector3(height / 100f, width / 100f, length / 100f);
        StartCoroutine(Print(cube.GetComponent<Rigidbody>(), transform.rotation * Vector3.down, height / 100f));
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
