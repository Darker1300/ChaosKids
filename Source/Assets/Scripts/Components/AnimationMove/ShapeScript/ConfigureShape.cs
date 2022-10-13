using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
namespace AnimationLibrary
{
    enum ShapeType
    {
        Triangle, Circle, Quad, Polygon, Rectangle, RegularPolygon, Line
    }



    public class ConfigureShape : MonoBehaviour
    {
        [SerializeField]
        private ShapeType WhatShape;
        public float radius;
        [SerializeField]

        public List<Vector3> v3Verticies = new List<Vector3>();
        [SerializeField]
        public List<Vector2> v2Verticies;
        public List<Vector2> v2VerticiesPoly;

        // public ShapeRenderer ShapeRenderer;
        Triangle triangle;
        Disc circle;
        Quad quad;
        Polygon polygon;
        Rectangle rectangle;
        RegularPolygon regularPolygon;
        Line line;
        public ShapeRendererEditor shapeRendererEditor;


        // Start is called before the first frame update
        void Start()
        {

            GetShapeScaleVerticies();
        }

        // Update is called once per frame
        void Update()
        {

        }

        // on enable lets get all the shapes verticies if hasnt all ready 
        // which will give us our starting values 
        //if its did it before the lerp we would have exponetial scale increase which is bad so so storing a default is good

        // at start we get and store all relevent(non zero) scale verticies and store them here that way when we lerp its always between this cached original value and our new amount.
        //storing all the verticies may require identifying what shape it is as in if circle or anything that usies a radius to scale grab current radius,else make a list of the vertices that are not zero so we know to scale them values
        //

        // how are we going to handle this if the top animation constructor does it we are going to have a lot of cross over
        //if the component itself does it, its still going to have cross over because every single component will call this regardless of if it has been set before
        //if the components where dragable thing it then the dragged component will only have one script instead of multiple for different animations.
        //if the script is contained on the object will it allow less customization with color because u set the color on that component
        //solution would be the color component stays which holds a reff to a shape information script, 
        //shape information script will hold the core information that will stay the same and wont be customized for the animation transform component
        //so we slap a shape info script which establishes itself for that object only once at the start of aplication, which will have an enum to identify shape this is a disc , this is a triangle. 
        //functions once set up and called by the scale script all it needs to have the scale passed in and and it will adjust for that 

        //STEP 1 
        public void GetShapeScaleVerticies()
        {


            //ShapesAssets


            //ShapeRenderer.GetType();

            Debug.Log("contains one");
            SpecificShapeInfo();
        }

        public void SpecificShapeInfo()
        {
            switch (WhatShape)
            {
                case ShapeType.Triangle:

                    //if (GetComponent<triangle>().Equals(null))
                    //{
                    //    return;
                    //}

                    //else 
                    v3Verticies = new List<Vector3>();

                    triangle = GetComponent<Triangle>();

                    for (int i = 0; i < 3; i++)
                    {

                        v3Verticies.Add(triangle.GetTriangleVertex(i));


                    }
                    //GetComponent<Triangle>().GetTriangleVertex;



                    break;
                case ShapeType.Circle:
                    circle = GetComponent<Disc>();
                    radius = circle.Radius;

                    break;
                case ShapeType.Quad:

                    v3Verticies = new List<Vector3>();

                    quad = GetComponent<Quad>();

                    for (int i = 0; i < 4; i++)
                    {
                        //v3Verticies.Add
                        v3Verticies.Add(quad.GetQuadVertex(i));

                    }
                    break;
                case ShapeType.Polygon:

                    //v3Verticies = new List<Vector3>();

                    polygon = GetComponent<Polygon>();

                    v2Verticies = new List<Vector2>();


                    //v3Verticies.Add
                    // v3Verticies.Add(quad.GetQuadVertex(i));
                    // List<>
                    v2Verticies = polygon.points;


                    v2Verticies = polygon.points;

                    for (int i = 0; i < v2Verticies.Count; i++)
                    {
                        v2VerticiesPoly.Add(v2Verticies[i]);
                    }






                    break;
                case ShapeType.Rectangle:

                    v3Verticies = new List<Vector3>();

                    rectangle = GetComponent<Rectangle>();
                    v3Verticies.Add(new Vector3(rectangle.Width, rectangle.Height, 0));

                    break;
                case ShapeType.RegularPolygon:

                    regularPolygon = GetComponent<RegularPolygon>();
                    radius = regularPolygon.Radius;
                    break;
                case ShapeType.Line:

                    v3Verticies = new List<Vector3>();
                    line = GetComponent<Line>();
                    v3Verticies.Add(line.Start);
                    v3Verticies.Add(line.End);


                    break;

                default:
                    break;
            }



        }

        public void ScaleShape(float Scale)
        {
            switch (WhatShape)
            {
                case ShapeType.Triangle:

                    //if (GetComponent<triangle>().Equals(null))
                    //{
                    //    return;
                    //}

                    //else 


                    for (int i = 0; i < 3; i++)
                    {
                        triangle.SetTriangleVertex(i, v3Verticies[i] * Scale);



                    }
                    //GetComponent<Triangle>().GetTriangleVertex;



                    break;
                case ShapeType.Circle:

                    circle.Radius = Scale * radius;


                    break;
                case ShapeType.Quad:



                    for (int i = 0; i < 4; i++)
                    {
                        //v3Verticies.Add
                        quad.SetQuadVertex(i, v3Verticies[i] * Scale);


                    }
                    break;

                case ShapeType.Polygon:

                    //polygon.meshOutOfDate = false;
                    //v3Verticies = new List<Vector3>();
                    //polygon.meshOutOfDate = true;
                    for (int i = 0; i < polygon.Count; i++)
                    {
                        //polygon.SetPointPosition(i,v2Verticies[i] * Scale);
                        polygon.SetPointPosition(i, v2VerticiesPoly[i] * Scale);
                    }
                    break;
                case ShapeType.Rectangle:



                    rectangle.Width = v3Verticies[0].x * Scale;
                    rectangle.Height = v3Verticies[0].y * Scale;

                    break;
                case ShapeType.RegularPolygon:

                    regularPolygon.Radius = radius * Scale;

                    break;
                case ShapeType.Line:


                    line.Start = v3Verticies[0] * Scale;
                    line.End = v3Verticies[1] * Scale;



                    break;

                default:
                    break;
            }



        }
    }


}
