using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    static public Hero S;

    [Header("Set in Introspector")]
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    // This variable hold a resference to the last triggering GameObject
    private GameObject lastTriggerGo = null;

    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Debug.LogError("Hero.Awake - Attempted to assign second Hero,S!");
        }
    }

    void Update() {
        // Pull in infomation from the Input Class
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // Change tranform.position based on the axis
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        // Rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        if (go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;

        if (go.tag == "Enemy")  // If the enemy hits the Hero
        {
            Destroy(go);
            Destroy(this.gameObject);        // Destory the enemy and itself
        }
        else
        {
            print("Trigger by non-Enemy: " + go.name);
        }
    }
}
