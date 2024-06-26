using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _score;
    private bool _isButtonPressed = true;

    private void Start()
    {
        StartCoroutine(IncreaseScoreOverTime());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isButtonPressed = !_isButtonPressed;
            StartCoroutine(IncreaseScoreOverTime());
        }
    }

    private IEnumerator IncreaseScoreOverTime()
    {
        float duration = 0.5f;
        WaitForSeconds time = new WaitForSeconds(duration);

        while (_isButtonPressed)
        {
            yield return time;
            _score++;
            _text.text = _score.ToString();
        }
    }
}
