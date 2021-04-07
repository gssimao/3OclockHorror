using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Writer : MonoBehaviour
{
    private static Writer instance;

    private List <TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }
    public static TextWriterSingle AddWriter_Static(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd, Action onComplete)
    {
        if(removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
    }
    private TextWriterSingle AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
       
    }

    public static void RemoveWriter_Static(Text uiText)
    {
        instance.RemoveWriter(uiText);
    }

    private void RemoveWriter(Text uiText)
    {
        for(int i = 0; i < textWriterSingleList.Count; i++)
        {
            if(textWriterSingleList[i].GetUIText() == uiText)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }
    private void Update()
    {
        /*
         * if(textWriterSingleList.Count > 1)
        {
            //if there is more than one text to be print in the list...
            //then finish playing number 1 
            //release number 1 and update the list (queueName.RemoveAt(0);)
            //play until there is no more text in the list
        }*/

        for (int i =0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            if(destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    public class TextWriterSingle // this is a single Writer instance
    {
        public Text uiText;
        public string textToWrite;
        public int characterIndex;
        public float timePerCharacter;
        public float timer;
        private bool invisibleCharacters;
        private Action onComplete;
        public TextWriterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            this.onComplete = onComplete;
            characterIndex = 0;
        }


        // return true on complete
        public bool Update()
        {

             timer -= Time.deltaTime;
             while (timer <= 0f) // printing text one by one according to timePerCharacter variable in "CallHouseText.cs"
             {
                  //display next character
                  timer += timePerCharacter;
                  characterIndex++;
                  string text = textToWrite.Substring(0, characterIndex);
                  if (invisibleCharacters)
                  {
                     text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>"; // change the color to transparent and gradually change it back
                  }
                  uiText.text = text;
                  if (characterIndex >= textToWrite.Length)
                  {
                    // Entire String displayed
                    if (onComplete != null) onComplete();
                       return true;
                  }
             }
            return false;
        }
        public Text GetUIText()
        {
            return uiText;
        }

        public bool isActive()
        {
            return characterIndex < textToWrite.Length;
        }
        public void WriteAndDestroy()
        {
            uiText.text = textToWrite;
            characterIndex = textToWrite.Length;
            if (onComplete != null) onComplete();
            Writer.RemoveWriter_Static(uiText);
        }
    }
}
