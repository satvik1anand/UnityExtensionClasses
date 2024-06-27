using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Extensions
{
    public static class TextTMPExtension
    {
        public static IEnumerator CountTo(this TextMeshProUGUI text, string s, Action OnCountComplete = null, bool isPercent = false)
        {
            int n;
            bool parsedFin = int.TryParse(s, out n);
            if (parsedFin)
            {
                yield return text.CountTo(n, 0.01f, OnCountComplete, isPercent);
            }
            else
            {
                yield return null;
                text.text = "...";
            }
        }
        public static IEnumerator CountTo(this TextMeshProUGUI text, int n,float time = 0.01f, Action OnComplete = null, bool isPercent = false)
        {
            int n_init;
            if (isPercent)
            {
                n_init = int.Parse(text.text.Trim('%').ToString());
            }
            else
            {
                n_init = int.Parse(text.text.ToString());
            }
            WaitForSeconds milli = new WaitForSeconds(time);
            if(n > n_init) 
            {
                for (int i = 1; i <= n - n_init; i++)
                {
                    text.text = isPercent? (n_init + i).ToString() + "%" : (n_init + i).ToString();
                    yield return milli;
                }
            }
            else 
            {
                for (int i = 1; i <= n_init - n; i++)
                {
                    text.text = isPercent ? (n_init + i).ToString() + "%" : (n_init + i).ToString();
                    yield return milli;
                }
            }
            OnComplete?.Invoke();
        }
        public static IEnumerator DoFadeTextTMP(this TextMeshProUGUI text, float endVal, float duration, Action OnCompleted = null)
        {
            float elapsed = 0f;
            while (elapsed < duration)
            {
                text.alpha = Mathf.SmoothStep(text.alpha, endVal, elapsed / duration );
                elapsed += Time.deltaTime;
                yield return null;
            }
            text.alpha = endVal;
            yield return null;
            OnCompleted?.Invoke();
        }

        /// <summary>
        /// Change the alpha value of text color
        /// </summary>
        /// <param name="alpha">value b/w 0-1</param>
        public static void ChangeTextAlpha(this TMP_Text text,float alpha)
        {
            var color = text.color;
            text.color = new Color(color.r,color.g,color.b,alpha);
        }
    }
}
