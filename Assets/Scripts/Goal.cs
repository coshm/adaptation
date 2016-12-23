using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    private const string BALL = "Ball";
    private int score = 0;

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag.Equals(BALL)) {
            col.gameObject.GetComponent<Ball>().ToggleCollider(false);
            score++;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
