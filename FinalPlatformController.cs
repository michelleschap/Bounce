using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalPlatformController : MonoBehaviour {

    public Text winText;

    private BoxCollider2D platform;

    // Use this for initialization
    void Start () {
        platform = GetComponent<BoxCollider2D>();
        winText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            winText.text = "You Finished!";
    }
}
