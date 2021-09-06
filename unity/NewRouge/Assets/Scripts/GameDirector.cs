using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameDirector : MonoBehaviour
{
    public TextAsset textFile;
    // Start is called before the first frame update

    public void ReadString()
    {
        string text = textFile.text;  //this is the content as string
        //Debug.Log(text);
        using (StringReader sr = new StringReader(text)) 
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length - 1; i++) 
                {
                    print(line[i]);
                }
                        
            }
        }
    }
    // Update is called once per frame
    void Start()
    {
        ReadString();
    }
}
