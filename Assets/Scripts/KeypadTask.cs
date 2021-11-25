using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadTask : MonoBehaviour
{
    public Text _cardCode;
    public Text _inputCode;

    public int _codeLength = 5;

    public float _codeRestTimeInSeconds = 0.5f;

    private bool _isResetting = false;


    private void OnEnable()
    {
        string code = string.Empty;

        for (int i = 0; i < _codeLength; i++)
        {
            code += Random.Range(1, 10);
        }

        _cardCode.text = code;
        _inputCode.text = string.Empty;
    }

    public void ButtonClick(int number)
    {
        if (_isResetting) { return; }

        _inputCode.text += number;

        if (_inputCode.text == _cardCode.text)
        {
            _inputCode.text = "Correct";
            StartCoroutine(ResetCode());
        }

        if(_inputCode.text.Length >= _codeLength)
        {
            _inputCode.text = "failt Task";
            StartCoroutine(ResetCode());
        }
    }

    private void Update()
    {
        print(_inputCode);
        print(_inputCode.text);
        print(_cardCode);
        print(_cardCode.text);
    }

    private IEnumerator ResetCode()
    {
        _isResetting = true;

        yield return new WaitForSeconds(_codeRestTimeInSeconds);

        _inputCode.text = string.Empty;
        _isResetting = false;
    }
}

