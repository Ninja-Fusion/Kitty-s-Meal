using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Fish : MonoBehaviour {

	public Text scoreText;
	private static int score;


	void Start() {
		score = 0;
		UpdateScore ();
	}

	void OnCollisionEnter2D(Collision2D col) {
		Destroy (gameObject);
		AddScore ();
	}

	public void AddScore() {
		score += 10;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score.ToString ();
	}
}
