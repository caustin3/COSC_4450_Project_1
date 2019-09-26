using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Drawing : MonoBehaviour
{
    
    public Material mat;
    Vector3 WorldPoint = new Vector3();
    Vector3 last_point = new Vector3();
    bool start, drawing_, check_line;
    int type = 0;
    int color=0;
    Color brush_color = new Color();
    // Start is called before the first frame update
    void Start()
    {
        drawing_ = false;
        start = false;
        check_line = false;
        mat = GetComponent<Renderer>().material;
        brush_color = Color.black;

    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetMouseButton(0))
        {
            float help_x = Camera.main.pixelWidth;
            float help_y = Camera.main.pixelHeight;
            WorldPoint = new Vector3((Input.mousePosition.x - help_x), (Input.mousePosition.y - help_y), Camera.main.nearClipPlane);
            Debug.Log("world pt at: x:" + WorldPoint.x + " and y:" + WorldPoint.y);
            drawing_ = true;
        }
        check_brush();
        check_color();
        check_eraser();
    }

    void OnPostRender()
    {
        if (start !=true) {
            GL.Clear(false, true, Color.white, 0.0f);
            start = true;
        }
        if (drawing_ == true)
        {
            if(type != 0)
            {
                check_line =false;
            }
            Draw_(WorldPoint);
        }
        drawing_ = false;
    }

    void Draw_a_Line(Color new_color, Vector3 center) {
        if (check_line == false)
        {
            last_point = center;
            check_line = true;
            return; 
        }
        GL.PushMatrix();
        mat.SetPass(0);
        GL.Begin(GL.LINES);
        GL.Color(new_color);        
        GL.Vertex3(last_point.x, last_point.y, last_point.z);
        GL.Vertex3(center.x, center.y, center.z); 
        GL.End();
        GL.PopMatrix();
        last_point = center;
    }

    void Draw_a_circle(int radis, Color new_color, Vector3 center)
    {
        int check = 0;
        GL.PushMatrix();

        mat.SetPass(0);

        GL.Begin(GL.TRIANGLE_STRIP);

        GL.Color(new_color);
        for (int a = 0; a < 361; a += 360 / 360)
        {
            if (check != 2)
            {
                double heading = (a * 3.1415926535) / 180;
                float x_1 = (float)Math.Cos(heading) * radis;
                float y_1 = (float)Math.Sin(heading) * radis;
                GL.Vertex3(center.x + x_1, center.y + y_1, center.z);
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
        mat.SetPass(0);
        GL.Begin(GL.QUADS);
        GL.Color(new_color);
        GL.Vertex3(center.x - offset, center.y - offset, center.z);
        GL.Vertex3(center.x + offset, center.y - offset, center.z);
        GL.Vertex3(center.x + offset, center.y + offset, center.z);
        GL.Vertex3(center.x - offset, center.y + offset, center.z);
        GL.End();
        GL.PopMatrix();
    }

    void Draw_a_triangle(int length, Color new_color, Vector3 center)
    {
        float offset_x = (length / 2);
        float offset_y = (float)((length * Math.Sqrt(3)) / 2) / 2;
        GL.PushMatrix();
        mat.SetPass(0);
        GL.Begin(GL.TRIANGLES);
        GL.Color(new_color);
        GL.Vertex3(center.x, center.y - offset_y, center.z);
        GL.Vertex3(center.x + offset_x, center.y + offset_y, center.z);
        GL.Vertex3(center.x - offset_x, center.y + offset_y, center.z);
        GL.End();
        GL.PopMatrix();
    }

    //changes the brush base on what was picked
    void check_brush()
    {        
        if (Input.GetKeyDown("1")) {
            type = 1;
        }

        if (Input.GetKeyDown("2"))
        {
            type = 2;
        }

        if (Input.GetKeyDown("3"))
        {
            type = 3;
        }

        if (Input.GetKeyDown("4"))
        {
            type = 4;
        }

        if (Input.GetKeyDown("5"))
        {
            type = 5;
        }

        if (Input.GetKeyDown("6"))
        {
            type = 6;
        }

        if (Input.GetKeyDown("7"))
        {
            type = 7;
        }

        if (Input.GetKeyDown("8"))
        {
            type = 8;
        }

        if (Input.GetKeyDown("9"))
        {
            type = 9;
        }

        if (Input.GetKeyDown("0"))
        {
            type = 0;
        }

    }

    void check_color()
    {
        if (Input.GetKeyDown("r"))
        {
            brush_color = Color.red;
        }

        if (Input.GetKeyDown("g"))
        {
            brush_color = Color.green;
        }

        if (Input.GetKeyDown("b"))
        {
            brush_color = Color.blue;
        }

        if (Input.GetKeyDown("y"))
        {
            brush_color = Color.yellow;
        }

        if (Input.GetKeyDown("l"))
        {
            brush_color = Color.black;
        }
    }

    void check_eraser() {
        if (Input.GetKeyDown("q"))
        {
            type = 10;
            
        }
        if (Input.GetKeyDown("w"))
        {
            type = 11;
            
        }
        if (Input.GetKeyDown("e"))
        {
            type = 12;
            
        }
    }

     
    void Draw_(Vector3 mouse)
    {

        if (type == 0)
        {
            Draw_a_Line(brush_color, mouse);
        }
        if (type == 1)
        {
            Draw_a_circle(30, brush_color, mouse);
        }

        if (type == 2)
        {
            Draw_a_square(50, brush_color, mouse);
        }

        if (type == 3)
        {
            Draw_a_triangle(50, brush_color, mouse);
        }

        if (type == 4)
        {
            Draw_a_circle(50, brush_color, mouse);
        }

        if (type == 5)
        {
            Draw_a_square(100, brush_color, mouse);
        }

        if (type == 6)
        {
            Draw_a_triangle(100, brush_color, mouse);
        }

        if (type == 7)
        {
            Draw_a_circle(100, brush_color, mouse);
        }

        if (type == 8)
        {
            Draw_a_square(200, brush_color, mouse);
        }

        if (type == 9)
        {
            Draw_a_triangle(200, brush_color, mouse);
        }

        if (type ==10)
        {
            Draw_a_circle(40, Color.white, mouse);
        }

        if (type == 11)
        {
            Draw_a_circle(60, Color.white, mouse);
        }

        if (type == 12)
        {
            Draw_a_circle(70, Color.white, mouse);
        }
    }


}
