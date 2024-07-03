using System.Collections;
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
            if (_isButtonPressed == true)
            {
                _isButtonPressed = false;
            }
            else
            {
                _isButtonPressed = true;
                StartCoroutine(IncreaseScoreOverTime());
            }
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
