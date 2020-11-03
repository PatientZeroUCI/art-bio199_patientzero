using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class ProgressBar : MonoBehaviour {
    public Image image;
    private Camera camera_main;

    public float Value {
        get {
            return image.fillAmount;
        }

        set {
            image.fillAmount = value;
        }
    }

    public bool Visible {
        get {
            return gameObject.activeInHierarchy;
        }

        set {
            gameObject.SetActive(value);
        }
    }

    void Start() {
        Value = 0;
        camera_main = Camera.main;
    }

    void Update() {
        transform.LookAt(camera_main.transform);

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
