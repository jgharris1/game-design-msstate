using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wavescript : MonoBehaviour
{
    public Text waveText;

    public void changeWave(int wave)
    {
        waveText.text = "Wave : " + wave.ToString();
    }
}
