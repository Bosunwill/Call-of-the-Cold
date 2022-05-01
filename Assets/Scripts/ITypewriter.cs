using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ITypewriter : MonoBehaviour
{

    Text _text;
    [SerializeField] TextMeshProUGUI cassetteText;
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
        cassetteText = GetComponent<TextMeshProUGUI>();
        if (cassetteText != null)
        {
            cassetteText.text = " ";
            //StartCoroutine("TypeWriter");
        }
        
    }

    void Update()
    {
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

    public IEnumerator TrialType(string casText)
    {
        cassetteText.text = leadingCharBeforeDelay ? leadingChar : "";
        yield return new WaitForSeconds(1);
        foreach (char c in casText)
        {
            if(cassetteText.text.Length > 0)
            {
                cassetteText.text = cassetteText.text.Substring(0, cassetteText.text.Length - leadingChar.Length);
            }
            cassetteText.text += c;
            cassetteText.text += leadingChar;
            yield return new WaitForSeconds(0.07f);
        }
        if(leadingChar != "")
        {
            cassetteText.text = cassetteText.text.Substring(0, cassetteText.text.Length - leadingChar.Length);
        }
    }
}
