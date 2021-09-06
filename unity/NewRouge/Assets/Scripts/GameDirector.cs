using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Diagnostics;
 
public class GameDirector : MonoBehaviour
{
    public GameObject player;
    public GameObject paredes;
    public GameObject error;
    public GameObject floor;
    public TextAsset textFile;
    // Start is called before the first frame update
    private void Start()
    {
        RefreshScreen();
    }
    public void RefreshScreen()
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
                for (int i = 0; i < line.Length; i++)
                    if (line[i] != ' ' && line[i] != '.')
                    {
                        float _x = (float)i;
                        float _y = (float)0.5;
                        float _z = -(float)count;
                        GameObject a = Instantiate(getType(line[i]));
                        a.transform.parent = transform;
                        a.transform.localPosition = new Vector3(_x, _y, _z);
                    }
                    else if (line[i] == '.') 
                    {
                        float _x = (float)i;
                        float _y = 0;
                        float _z = -(float)count;
                        GameObject a = Instantiate(floor);
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
            default:  return error; break;
        }
    }

    // Update is called once 
    private void Update()
    {
		string root = "C:\\Users\\green\\Desktop\\NewRogue\\python\\";
        if (Input.GetKeyDown(KeyCode.UpArrow))
			CallPy(root + "input_up.py");
		else if (Input.GetKeyDown(KeyCode.DownArrow))
			CallPy(root + "input_down.py");
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
			CallPy(root + "input_left.py");
        else if (Input.GetKeyDown(KeyCode.RightArrow))
			CallPy(root + "input_right.py");
			
       
    }
	
	private void CallPy (string fname) {
		Process foo = new Process();
		foo.StartInfo.FileName = fname;
		foo.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		foo.Start();
        RefreshScreen();
    }
}