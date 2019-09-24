using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Drawing : MonoBehaviour
{
    
    public Material mat;
    Vector3 Vertex_1, Vertex_2;       

    // Start is called before the first frame update
    void Start()
    {
        Vertex_1 = new Vector3(0, 0, 0);
        Vertex_2 = new Vector3(0, 0, 0);
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Vector3 WorldPoint = new Vector3();
            Vector3 work_ = new Vector3();
            WorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            work_ = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0f);
            Vertex_1 = WorldPoint;
            Debug.Log("and point" + WorldPoint.x + " and y:" + WorldPoint.y);

            Draw_a_circle(10, Color.black, work_);
        }
       
    }
    void OnPostRender()
    {

        GL.PushMatrix();
        //GL.Viewport(new Rect(.5f, 0, 1, 1));
        mat.SetPass(0);

        GL.Begin(GL.QUADS);
        GL.Color(new Color(0, 0, 1f));
        GL.Vertex3(0, 5f, 0);
        GL.Color(new Color(0.25f, 0, 0.75f));
        GL.Vertex3(5f, 10, 0);
        GL.Color(new Color(0.50f, 0, .50f));
        GL.Vertex3(10, 5f, 0);
        GL.Color(new Color(0.75f, 0, .25f));
        GL.Vertex3(5f, 0, 0);
        GL.End();
               
        GL.PopMatrix();        
        
    }

    void Draw_a_circle(int radis, Color new_color, Vector3 center)
    {
        Debug.Log("Draw_a_circle");
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

}
