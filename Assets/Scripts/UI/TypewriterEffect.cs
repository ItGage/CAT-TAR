using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text[] text;
    [SerializeField] private float characterDelay;
    [SerializeField] private float textDelay;
    [SerializeField] private float startDelay;

    private void Start()
    {
        foreach(var t in text)
        {
            t.maxVisibleCharacters = 0;
        }
        
        StartCoroutine(TypeOneByOne());
    }

    IEnumerator TypeOneByOne()
    {
        yield return new WaitForSeconds(startDelay);

        foreach (var txt in text)
        {
            txt.ForceMeshUpdate();
            int totalChars = txt.textInfo.characterCount;

            for (int i = 0; i <= totalChars; i++)
            {
                txt.maxVisibleCharacters++;
                yield return new WaitForSeconds(characterDelay);
            }

            yield return new WaitForSeconds(textDelay);
        }

    }
}
