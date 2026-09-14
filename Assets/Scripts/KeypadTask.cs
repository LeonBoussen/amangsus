using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeypadTask : MonoBehaviour
{
    public Text _cardCode;
    public Text _inputCode;

    public GameObject Task;

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

    }

    private void Update()
    {
        Check();
    }

     private IEnumerator ResetCode()
     {
        _inputCode.text = "fail!";
        _isResetting = true;

        yield return new WaitForSeconds(_codeRestTimeInSeconds);

        _inputCode.text = string.Empty;
        _isResetting = false;
     }

    private void Check()
    {

        if (_inputCode.text.Length == _codeLength)
        {
            if (_inputCode.text == _cardCode.text)
            {
                print("W");
                Win();
            }
            else
            {
                print("L");
                ResetCode();
            }
        }
    }

    private IEnumerator Win()
    {
        _inputCode.text = "Correct!";
        yield return new WaitForSeconds(_codeRestTimeInSeconds);
        Task.SetActive(false);
    }
}

