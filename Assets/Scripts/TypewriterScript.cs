using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypewriterScript : MonoBehaviour {

	public Text uiTarget;

	public string text;
	public float lettersPerSecond = 1f;
	public float secondsPerLetter = 1f;

	[Range(0f, 1f)]
	public float turbulence = 0; // <- timePerLetter += Random( ± turbulence )
	public bool playOnAwake = false;
	public bool unscaledTime = false;

	private bool active = false;
	private float timeLeft; // Time 'til next letter

#if UNITY_EDITOR
	private float oLPS = 1f;
	private float oSPL = 1f;

	void OnValidate() {
		if (oLPS != lettersPerSecond) secondsPerLetter = 1f / lettersPerSecond;
		if (oSPL != secondsPerLetter) lettersPerSecond = 1f / secondsPerLetter;

		oLPS = lettersPerSecond;
		oSPL = secondsPerLetter;
	}
#endif

	void Awake () {
		if (playOnAwake)
			Writeout();
	}
	
	void Update () {
		if (!active)
			return;

		// Wait
		timeLeft -= unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;

		if (timeLeft <= 0f) {
			// Next letter!
			AddRemainingTime();
			uiTarget.text += text.Substring(uiTarget.text.Length, 1);
		}

		// Check if done
		if (uiTarget.text.Length == text.Length)
			active = false;
	}

	void AddRemainingTime() {
		timeLeft += Mathf.Max(0f, 1f / lettersPerSecond + Random.Range(-turbulence, turbulence));
		// 1/time to turn it into seconds per letter, i.e. time in seconds left 'til next letter
		// Max(0, time) so it doesn't remove time left
	}

	public void Writeout() {
		// Reset
		uiTarget.text = "";
		timeLeft = 0f;

		// Activate
		active = true;
		AddRemainingTime();
	}
}
