using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpillIntoWord : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerEnter;
    [SerializeField] private TextMeshProUGUI answerText;
    
    string[] separators = { ",", ".", "!", "?", ";", ":", " " };

    private Dictionary<string, string> Answers = new Dictionary<string, string>();
   

    private void Start()
    {
        Answers.Add("MOTHER","Mother has died several days ago.");
        Answers.Add("ME","I have Delusional Disorder.");
        Answers.Add("NIGHT","Delusional Disorder happens in the middle of the night");
        Answers.Add("CLOTHES","She is me.");
        Answers.Add("BLOOD","My hand was hurt by the fragments of the mirror.");
        Answers.Add("ANSWERS","My mother passed away a few days ago. " +
                              "The death of my mother had a great blow to me, so that I had hallucinations and sleepwalking." +
                              "Mom gave me perfume before she was alive, and chatted with her in front of her cemetery. " +
                              "When I looked in the mirror that day, I imagined myself in the mirror as my mother, " +
                              "and I argued with her, but I accidentally pushed the mirror down, " +
                              "and the mirror shattered all over the floor. Blood flowed out.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SpillSentence();
        }
    }

    void SpillSentence()
    {
        Debug.Log("Hit Return");
        string enter = playerEnter.text;
            
        string[] words = enter.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            //Debug.Log(word);

            // when we are comparing a string with anothe string, we better use Equals
            // if (word.ToUpper().Trim().Equals("MOTHER"))
            // {
            //     Debug.Log("Mother has died several days ago.");
            // }

            string keyWord = word.ToUpper().Trim();
            
            if (Answers.ContainsKey(keyWord))
            {
                Debug.Log(Answers[word]);
                answerText.text = Answers[word];
            }
            else
            {
                Debug.Log(word.ToUpper());
            }
        }

        foreach(string key in Answers.Keys){
            Debug.Log(key);
        }
        }
    }
    
    
