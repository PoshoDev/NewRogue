using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameDirector : MonoBehaviour
{
    public GameObject player;
    public GameObject paredes;
    public GameObject error;
    public TextAsset textFile;
    // Start is called before the first frame update

    public void ReadString()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        string text = textFile.text;  //this is the content as string
        //Debug.Log(text);
        using (StringReader sr = new StringReader(text))
        {
            int count = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                for (int i  = 0; i < line.Length - 1; i++)
                    if (line[i] != ' '&& line[i]!= '.')
                    {
                        float _x = (float)i;
                        float _y = (float)0.5;
                        float _z = -(float)count;
                        GameObject a = Instantiate(getType(line[i]));
                        a.transform.parent = transform;
                        a.transform.localPosition = new Vector3(_x, _y, _z);
                    }
                count++;
            }
        }
    }

    GameObject getType(char ch)
    {
        switch (ch)
        {
            case '|':
            case '-': return paredes; break;
            case '@': return player; break;
            default:    return error; break;
        }
    }

    // Update is called once 
    void Start()
    {
        ReadString();
    }
}