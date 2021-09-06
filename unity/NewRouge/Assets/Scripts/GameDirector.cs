using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Diagnostics;
 
public class GameDirector : MonoBehaviour
{
    public GameObject player;
    public GameObject paredes;
    public GameObject error;
    public GameObject floor;
    public TextAsset textFile;
    public Sprite rogue;
    public Sprite bat;
    public Sprite emu;
    public Sprite food;
    public Sprite gold;
    public Sprite hobgoblin;
    public Sprite icemonster;
    public Sprite kestrel;
    public Sprite potion;
    public Sprite scroll;
    public Sprite snake;
    public Sprite stairs;
    public Sprite sword;
    public Sprite unknown;
    public TMP_Text texto;
    public TMP_Text texto2;
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
                if (count == 0)
                {
                    texto.text = line;
                } 
                else if(count ==23)
                {
                texto2.text = line;
                }
                else
                {
                    for (int i = 0; i < line.Length; i++)
                        switch (line[i])
                        {
                            case ' ':
                                break;

                            case '.':
                            case '#':
                            case '+':
                                spawn(floor, (float)i, (float)0.0, (float)count);
                                break;

                            case '|':
                            case '-':
                                spawn(paredes, (float)i, (float)0.5, (float)count);
                                break;

                            default:
                                GameObject a = spawn(player, (float)i, (float)0.0, (float)count);
                                a.GetComponent<SpriteRenderer>().sprite = getType(line[i]);
                                spawn(floor, (float)i, (float)0.0, (float)count);
                                break;
                        }
                }
                count++;
            }
        }
    }
	
	GameObject spawn(GameObject obj, float _x, float _y, float _z) {
		GameObject a = Instantiate(obj);
        a.transform.parent = transform;
        a.transform.localPosition = new Vector3(_x, _y, _z);
        return a;
	}

    Sprite getType(char ch)
    {
		
		
        switch (ch)
        {
            case '@': return rogue;	break;
            case 'B': return bat; break;
            case 'E': return emu; break;
            case 'H': return hobgoblin; break;
            case 'I': return icemonster; break;
            case 'K': return kestrel; break;
            case 'S': return snake; break;
            case '?': return scroll; break;
            case '*': return gold; break;
            case ':': return food; break;
            case '!': return potion; break;
            case ')': return sword; break;
            case '%': return stairs; break;
            default: return unknown; break;
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