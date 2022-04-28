using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ITypewriter : MonoBehaviour
{
    public enum level {Morgue, Lobby, Psych, Lab}
    public level thisLevel = level.Morgue;

    Text _text;
    TextMeshProUGUI cassetteText;
    string writer;
    //[SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;

    // Start is called before the first frame update
    void Start()
    {
        //_text = GetComponent<Text>()!;
        // if (_text != null)
        // {
        //     writer = _text.text;
        //     _text.text = "";
        //     StartCoroutine("TypeWriter");
        // }
        cassetteText = GetComponent<TextMeshProUGUI>();
        if (cassetteText != null)
        {
            cassetteText.text = " ";
            //StartCoroutine("TypeWriter");
        }
        
    }

    void Update()
    {
        if(thisLevel == level.Morgue)
        {
            writer = "The human lifespan is so finite. So many discoveries could be made with just a little more time! Maybe there's someway to extend one's lifespan...";
        }
        if(thisLevel == level.Lobby)
        {
            writer = "I don't think the director's idea is feasible. I can't bring it up to him since he started firing even veteran doctors for calling the idea dangerous. Back to work I suppose...";
        }
        if(thisLevel == level.Psych)
        {
            writer = "I think my cure for mortality is almost complete! However i've noticed some undesirable side effects amonsgt my experiments. The... (Say with digust) distastful side effects seems to be spreading among the groups. Even i haven't been feelling up to par. May this not be the last the world hears from Victor Asimov";
        }
    }

    IEnumerator TypeWriter(float delayBeforeStart)
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

    public IEnumerator TrialType(float delayBeforeStart)
    {
        cassetteText.text = leadingCharBeforeDelay ? leadingChar : "";
        yield return new WaitForSeconds(delayBeforeStart);
        foreach (char c in writer)
        {
            if(cassetteText.text.Length > 0)
            {
                cassetteText.text = cassetteText.text.Substring(0, cassetteText.text.Length - leadingChar.Length);
            }
            cassetteText.text += c;
            cassetteText.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }
        if(leadingChar != "")
        {
            cassetteText.text = cassetteText.text.Substring(0, cassetteText.text.Length - leadingChar.Length);
        }
    }
}
