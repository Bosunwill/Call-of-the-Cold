using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ITypewriter : MonoBehaviour
{
    Text _text;
    string writer;
    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>()!;
        if (_text != null)
        {
            writer = _text.text;
            _text.text = "";
            StartCoroutine("TypeWriter");
        }
        
    }

    IEnumerator TypeWriter()
    {
        _text.text = leadingCharBeforeDelay ? leadingChar : "";
        yield return new WaitForSeconds(delayBeforeStart);
        foreach (char c in writer)
        {
            if(_text.text.Length > 0)
            {
                _text.text = _text.text.Substring(0, _text.text.Length - leadingChar.Length);
            }
            _text.text += c;
            _text.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }
        if(leadingChar != "")
        {
            _text.text = _text.text.Substring(0, _text.text.Length - leadingChar.Length);
        }
    }
}
