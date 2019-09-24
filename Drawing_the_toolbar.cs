using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Drawing_the_toolbar : MonoBehaviour
{
    public Material toolbar_canvas;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        start = false;
        toolbar_canvas = GetComponent<Renderer>().material;
        GL.Clear(false, true, Color.white, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnPostRender()
    {
        if (start != true)
        {
            GL.Clear(false, true, Color.white, 0.0f);
            start = true;
        }
        GL.PushMatrix();
        toolbar_canvas.SetPass(0);
        GL.Begin(GL.LINE_STRIP);
        GL.Color(Color.black);
        GL.Vertex3(30, -100, 0);
        GL.Vertex3(30, 100, 0);       
        GL.End();
        GL.PopMatrix();

        Draw_a_circle(3, Color.black, new Vector3(-33, 70, 0));
        Draw_a_circle(5, Color.black, new Vector3(-33, 60, 0));
        Draw_a_circle(10, Color.black, new Vector3(-33, 44, 0));

        Draw_a_square(5, Color.black, new Vector3(-10, 70, 0));
        Draw_a_square(10, Color.black, new Vector3(-10, 60, 0));
        Draw_a_square(20, Color.black, new Vector3(-10, 44, 0));

        Draw_a_triangle(5, Color.black, new Vector3(15, 70, 0));
        Draw_a_triangle(10, Color.black, new Vector3(15, 60, 0));
        Draw_a_triangle(20, Color.black, new Vector3(15, 44, 0));


        Draw_a_square(10, Color.red, new Vector3(-33, 0, 0));
        Draw_a_square(10, Color.green, new Vector3(-23, 0, 0));
        Draw_a_square(10, Color.blue, new Vector3(-13, 0, 0));
        Draw_a_square(10, Color.yellow, new Vector3(-3, 0, 0));
        Draw_a_square(10, Color.black, new Vector3(7, 0, 0));

        GL.PushMatrix();
        toolbar_canvas.SetPass(0);
        GL.Begin(GL.QUADS);
        GL.Color(Color.black);
        GL.Vertex3(-33, -10, 0);
        GL.Vertex3(7, -10, 0);
        GL.Vertex3(7, -11, 0);
        GL.Vertex3(-33, -11, 0);
        GL.End();
        GL.PopMatrix();

        GL.PushMatrix();
        toolbar_canvas.SetPass(0);
        GL.Begin(GL.LINE_STRIP);
        GL.Color(Color.black);
        GL.Vertex3(-33,-15 , 0);
        GL.Vertex3(-23,-15 , 0);
        GL.Vertex3(-23,-25 , 0);
        GL.Vertex3(-33,-25 , 0);
        GL.Vertex3(-33, -15, 0);
        GL.End();
        GL.PopMatrix();
    }

    void Draw_a_circle(int radis,Color new_color, Vector3 center)
    {
        int check = 0;
        GL.PushMatrix();

        toolbar_canvas.SetPass(0);

        GL.Begin(GL.TRIANGLE_STRIP);   
        
        GL.Color(new_color);       
        for (int a = 0; a < 361; a += 360 / 360)
        {
            if (check != 2)
            {
                double heading = (a * 3.1415926535) / 180;
                float x_1 = (float)Math.Cos(heading) * radis;
                float y_1 = (float)Math.Sin(heading) * radis;
                GL.Vertex3(center.x + x_1, center.y + y_1, center.z );
                check++;
            }
            else if (check == 2)
            {
                check = 0;
                GL.Vertex3(center.x, center.y, center.z);
            }
        }
        GL.End();
        GL.PopMatrix();
    }

    void Draw_a_square(int length, Color new_color, Vector3 center)
    {
        float offset = (length / 2);
        GL.PushMatrix();
        toolbar_canvas.SetPass(0);
        GL.Begin(GL.QUADS);
        GL.Color(new_color);
        GL.Vertex3(center.x - offset, center.y- offset, center.z);
        GL.Vertex3(center.x + offset, center.y - offset, center.z);
        GL.Vertex3(center.x + offset, center.y + offset, center.z);
        GL.Vertex3(center.x - offset, center.y + offset, center.z);
        GL.End();
        GL.PopMatrix();
    }

    void Draw_a_triangle(int length, Color new_color, Vector3 center)
    {
        float offset_x = (length / 2);
        float offset_y = (float) ((length* Math.Sqrt(3)) /2)/2;
        GL.PushMatrix();
        toolbar_canvas.SetPass(0);
        GL.Begin(GL.TRIANGLES);
        GL.Color(new_color);
        GL.Vertex3(center.x, center.y + offset_y, center.z);
        GL.Vertex3(center.x + offset_x, center.y - offset_y, center.z);
        GL.Vertex3(center.x - offset_x, center.y - offset_y, center.z);
        GL.End();
        GL.PopMatrix();
    }
}
