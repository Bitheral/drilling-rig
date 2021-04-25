using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Splash : MonoBehaviour
{
    public Image panel;
    Color alpha = new Color(1, 1, 1, 0);

    private void Start()
    {
        StartCoroutine(Splashscreen(Color.white, alpha, 2f, 4f));
    }

    IEnumerator Splashscreen(Color start, Color end, float duration, float delay)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            panel.material.color = Color.Lerp(start, end, normalizedTime);
            yield return null;
        }
        panel.material.color = end; //without this, the value will end at something like 0.9992367

        yield return new WaitForSeconds(delay);

        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            panel.material.color = Color.Lerp(end, start, normalizedTime);
            yield return null;
        }
        panel.material.color = start; //without this, the value will end at something like 0.9992367
        SceneManager.LoadScene(1);
    }

}
