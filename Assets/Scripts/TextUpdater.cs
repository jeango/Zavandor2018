﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour {

    public Text text;
    public ListenableInt value;

    private void OnEnable()
    {
        text.text = value.Value.ToString();
        value.OnChange += UpdateText;
    }
    private void OnDisable()
    {
        value.OnChange -= UpdateText;
    }
    private void UpdateText()
    {
        text.text = value.Value.ToString();
    }

}
