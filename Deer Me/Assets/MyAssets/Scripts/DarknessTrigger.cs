﻿/*
 * Vince Carpino
 * 2260921
 * carpi111@mail.chapman.edu
 * CPSC 440-01
 * Deer Me
 *
 * Controls darkness stage of level.
 *     As player advances forward,
 *     world darkens; lightens when
 *     they move backwards.
 */

using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class DarknessTrigger : MonoBehaviour {

//	public float startXPos;

	public float divisor;
//	public float minVisibility;

	public GameObject player;
//	public Image darknessImage;

	public Light worldLight;

	public bool hasTorch;
	private bool hitTrigger;

	private float currPos, prevPos;

	private void Start() {
//		minVisibility /= 100f;
//		minVisibility = 1f - minVisibility;
	}

	void Update() {

		if (hitTrigger) {
            CheckPosition();
			StartCoroutine(WaitForTime());
//			printPos();
		}
	}

	void CheckPosition() {
		// FIGURE OUT BETTER WAY TO TRACK PLAYER MOVEMENT TO AFFECT WORLD LIGHT INTENSITY
		currPos = player.transform.position.x;

//		if (player.transform.position.x <= startXPos) return;

//		var tempColor = darknessImage.color;
//		tempColor.a = (player.transform.position.x - startXPos) / divisor;
//		if (tempColor.a <= minVisibility) {
//			darknessImage.color = tempColor;
//		}

		var playerDelta = player.transform.position.x - gameObject.transform.position.x;
//		print(playerDelta);

		print(currPos - prevPos);
		worldLight.intensity -= (currPos - prevPos) / divisor;

		prevPos = currPos;
	}

	void printPos() {
		print(player.transform.position.x);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (!other.CompareTag("Player")) return;

		hitTrigger = true;

		print("TRIGGER DARK");

		// CHANGE BRIGHTNESS OF WORLD LIGHT AS PLAYER MOVES FORWARD
//		worldLight.intensity = 0.5f;
	}

	public void setHasTorch(bool val) {
		hasTorch = val;
	}

	IEnumerator WaitForTime() {
		yield return new WaitForSeconds(0.2f);
	}
}
