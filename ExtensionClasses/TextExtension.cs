using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Extensions
{
    public static class TextExtension
    {
        public static IEnumerator CountTo(this Text text, string s, Action OnCountComplete = null)
        {
            int n;
            bool parsedFin = int.TryParse(s, out n);
            if (parsedFin)
            {
                yield return text.CountTo(n, 0.01f, OnCountComplete);
            }
            else
            {
                yield return null;
                text.text = "...";
            }
        }
        public static IEnumerator CountTo(this Text text, int n,float time = 0.01f, Action OnComplete = null)
        {
            int n_init;
            bool parsedInit = int.TryParse(text.text.ToString(), out n_init);
            WaitForSeconds milli = new WaitForSeconds(time);
            if (parsedInit)
            {
                if(n > n_init) 
                {
                    for (int i = 1; i <= n - n_init; i++)
                    {
                        text.text = (n_init + i).ToString();
                        yield return milli;
                    }
                }
                else 
                {
                    for (int i = 1; i <= n_init - n; i++)
                    {
                        text.text = (n_init - i).ToString();
                        yield return milli;
                    }
                }
            }
            else
            {
                yield return null;
                text.text = n.ToString();
            }
            OnComplete?.Invoke();
        }

    }
}
