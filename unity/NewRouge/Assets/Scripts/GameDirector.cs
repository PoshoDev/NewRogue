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
					switch(line[i]) {
						case ' ':
						break;
						
						case '.':
							spawn(floor, (float)i, (float)0.0, (float)count);
						break;
						
						case '|':
						case '-':
							spawn(paredes, (float)i, (float)0.5, (float)count);
						break;
						
						default:
							spawn(getType(line[i]), (float)i, (float)0.0, (float)count);
							spawn(floor, (float)i, (float)0.0, (float)count);
						break;
					}
				
                count++;
            }
        }
    }
	
	void spawn(GameObject obj, float _x, float _y, float _z) {
		GameObject a = Instantiate(obj);
        a.transform.parent = transform;
        a.transform.localPosition = new Vector3(_x, _y, _z);
	}

    GameObject getType(char ch)
    {
        switch (ch)
        {
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