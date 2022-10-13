using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerBehaviour : MonoBehaviour
{
	
    private int distance;
    private float timer;
    private int max_seconds;
    public int seconds;
    public TMP_InputField input_seconds;
    public TMP_InputField input_distance;
    public TMP_InputField input_speed;
    GameObject my_cube;
    float start_z;
    bool timer_go;
    bool cube_created;
    int speed;

    // Start is called before the first frame update
    void Start()
    {
    distance=10;
    seconds=0;
    timer=0f;
    max_seconds=5;
    start_z=-20;
    timer_go=true;
    cube_created=false;
    speed=1;
    }

    // Update is called once per frame
    void Update()
    {
    max_seconds=GetInputs(input_seconds, max_seconds);
    speed=GetInputs(input_speed, speed);
    distance=GetInputs(input_distance, distance);



    if(seconds<max_seconds)
    	{
    	if(timer_go==true)
    		{
    		timer += Time.deltaTime;
        	seconds = (int)(timer % 60);
        	}	
        //Debug.Log("Seconds: " + seconds);
    	}
    else
    	{
    	timer_go=false;
    	seconds=0;
    	timer=0f;
    	cube_created=true;
    	my_cube=GameObject.CreatePrimitive(PrimitiveType.Cube);
    	my_cube.transform.position= transform.position;
    	}

    if(my_cube!=null)
    	{
    	my_cube.transform.position += new Vector3(0, 0, speed*0.01f);
    	
    	if(my_cube.transform.position.z>distance)
    		{
    		Destroy(my_cube);
    		timer_go=true;
    		cube_created=false;
    		seconds=0;
    		timer=0f;
    		}
    	
    	}

    }

   	int GetInputs(TMP_InputField my_field, int param)
   		{
   		if(my_field!=null)
	    	{
	    	int temp_param=0;
	    	int.TryParse(my_field.text, out temp_param);
	    	if(temp_param!=0)
	    		{
	    		param=temp_param;
	    		param=Mathf.Clamp(param, 0, 20);
	    		return param;	
	    		}
	    	else 
	    		{
	    		return param;
	    		}
	    	
	    	string temp_string=param.ToString();	
	    	if(my_field==input_distance)
	    		{
	    		my_field.text="Distance: "+temp_string;	
	    		}
	    	if(my_field==input_speed)
	    		{
	    		my_field.text="Speed: "+temp_string;	
	    		}
	    	if(my_field==input_seconds)
	    		{
	    		my_field.text="Timer: "+temp_string;	
	    		}
		    
	    	}
	    else
	    	{
	    	return param;	
	    	}	
   		}

}
