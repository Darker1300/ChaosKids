using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LerpColor))]
public class LerpColorDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        float space = 45.4f;
        EditorGUI.BeginProperty(position, label, property);
       
        
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;


        Rect rectFoldout = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);

        int lines = 0;
        Rect ActivateRect = new Rect(EditorGUI.indentLevel + position.width * 0.28f ,
                                position.y + lines * EditorGUIUtility.singleLineHeight,
                                position.width * 0.25f,
                                 EditorGUIUtility.singleLineHeight);

        Rect ClampedRect = new Rect(EditorGUI.indentLevel + position.width * 0.31f,
                                  position.y + lines * EditorGUIUtility.singleLineHeight,
                                  position.width * 0.2f,
                                   EditorGUIUtility.singleLineHeight);


        EditorGUIUtility.labelWidth = 45f;
        SerializedProperty ActiveProp = property.FindPropertyRelative("Active");
        EditorGUI.PropertyField(ActivateRect, ActiveProp, GUIContent.none);




        SerializedProperty typProp = property.FindPropertyRelative("type");
        EditorGUI.PropertyField(ClampedRect, typProp, GUIContent.none);


        property.isExpanded = EditorGUI.Foldout(rectFoldout, property.isExpanded, label);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);


        if (property.isExpanded)
        {
                //Tweak our color label width so its not fixed size 

                lines += 2;

            Rect TimedRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.035f,
                                position.y + lines * EditorGUIUtility.singleLineHeight,
                                position.width * 0.2f,
                                 EditorGUIUtility.singleLineHeight);
            //lines++;
            Rect DurationRect = new Rect(EditorGUI.indentLevel + position.width * 0.35f,
                                   position.y + lines * EditorGUIUtility.singleLineHeight,
                                   position.width * 0.2f,
                                    EditorGUIUtility.singleLineHeight);
            EditorGUIUtility.labelWidth = 90f;
            SerializedProperty TimedProp = property.FindPropertyRelative("Timed");
            SerializedProperty TimedDurationProp = property.FindPropertyRelative("TimedDuration");

            //EditorGUIUtility.wid = 20f;
            EditorGUI.PropertyField(TimedRect, TimedProp, new GUIContent("Make Timed"));
            if (TimedProp.boolValue == true)
            {
                EditorGUI.PropertyField(DurationRect, TimedDurationProp, new GUIContent("Duration"));

            }
            //draw new lable and calculate new position 

            lines++;
            EditorGUI.indentLevel = 0;


            if (typProp.enumValueIndex.Equals(0))
            {


                Rect StartColorFirstRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.035f,
                                        position.y + lines * EditorGUIUtility.singleLineHeight,
                                        position.width * 0.2f,
                                         EditorGUIUtility.singleLineHeight);

                Rect StartColorSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.15f,
                                        position.y + lines * EditorGUIUtility.singleLineHeight,
                                        position.width * 0.2f,
                                         EditorGUIUtility.singleLineHeight);


                Rect StartColorThirdRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.315f,
                                        position.y + lines * EditorGUIUtility.singleLineHeight,
                                        position.width * 0.2f,
                                         EditorGUIUtility.singleLineHeight);



                EditorGUI.LabelField(StartColorFirstRect, new GUIContent("Start Color:"));
                // EditorGUI.LabelField(StartposFirstRect, new GUIContent("using Current Color"));
                EditorGUIUtility.labelWidth = 80f;
                SerializedProperty startSecondProp = property.FindPropertyRelative("StartCurrentColor");
                //EditorGUIUtility.fieldWidth = 80f;
                SerializedProperty startThirdProp = property.FindPropertyRelative("myColorStart");

                EditorGUI.PropertyField(StartColorSecondRect, startSecondProp, new GUIContent("Use Current"));
                if (startSecondProp.boolValue != true)
                {
                    EditorGUI.PropertyField(StartColorThirdRect, startThirdProp, new GUIContent("Custom"));
                }
                //else //EditorGUI.PropertyField(StartposSecondRect, , new GUIContent("Custom"));



                lines++;

                Rect EndColorFirstRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.035f,
                                        position.y + lines * EditorGUIUtility.singleLineHeight,
                                        position.width * 0.2f,
                                         EditorGUIUtility.singleLineHeight);

                Rect EndColorSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.15f,
                                        position.y + lines * EditorGUIUtility.singleLineHeight,
                                        position.width * 0.2f,
                                         EditorGUIUtility.singleLineHeight);


                Rect EndColorThirdRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.315f,
                                        position.y + lines * EditorGUIUtility.singleLineHeight,
                                        position.width * 0.2f,
                                         EditorGUIUtility.singleLineHeight);



                EditorGUI.LabelField(EndColorFirstRect, new GUIContent("End Color:"));
                // EditorGUI.LabelField(StartposFirstRect, new GUIContent("using Current Color"));
                EditorGUIUtility.labelWidth = 80f;
                SerializedProperty EndSecondProp = property.FindPropertyRelative("EndCurrentColor");
                //EditorGUIUtility.fieldWidth = 80f;
                SerializedProperty EndThirdProp = property.FindPropertyRelative("myColorEnd");

                EditorGUI.PropertyField(EndColorSecondRect, EndSecondProp, new GUIContent("Use Current"));
                if (EndSecondProp.boolValue != true)
                {
                    EditorGUI.PropertyField(EndColorThirdRect, EndThirdProp, new GUIContent("Custom"));
                }
                //else //EditorGUI.PropertyField(StartposSecondRect, , new GUIContent("Custom"));


                //Rect EndPosFirstRect = new Rect(EditorGUI.indentLevel + position.width * 0.035f,
                //                        position.y + lines * EditorGUIUtility.singleLineHeight,
                //                        position.width * 0.45f,
                //                         EditorGUIUtility.singleLineHeight);


                ////Rect EndPosSecondRect = new Rect(EditorGUI.indentLevel + position.width * 0.525f,
                ////                        position.y + lines * EditorGUIUtility.singleLineHeight,
                ////                        position.width * 0.5f,
                ////                         EditorGUIUtility.singleLineHeight);


                //EditorGUIUtility.labelWidth = 80f;
                //SerializedProperty EndFirstProp = property.FindPropertyRelative("myColorEnd");
                ////EditorGUIUtility.fieldWidth = 80f;
                ////SerializedProperty EndSecondProp = property.FindPropertyRelative("myColorEnd");

                //EditorGUI.PropertyField(EndPosFirstRect, EndFirstProp, new GUIContent("End Color"));
                ////if (EndFirstProp.enumValueIndex.Equals(0))
                ////{

                ////    EditorGUI.PropertyField(EndPosSecondRect, EndSecondProp, GUIContent.none);
                ////}
            }
            else
            {
                Rect StartColorFirstRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.035f,
                                      position.y + lines * EditorGUIUtility.singleLineHeight,
                                      position.width * 0.2f,
                                       EditorGUIUtility.singleLineHeight);
                Rect StartColorSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.15f,
                                       position.y + lines * EditorGUIUtility.singleLineHeight,
                                       position.width * 0.2f,
                                        EditorGUIUtility.singleLineHeight);
                EditorGUI.LabelField(StartColorFirstRect, new GUIContent("Gradient: "));
                // EditorGUI.LabelField(StartposFirstRect, new GUIContent("using Current Color"));
                EditorGUIUtility.labelWidth = 80f;
                SerializedProperty startSecondProp = property.FindPropertyRelative("colorGradient");
                EditorGUI.PropertyField(StartColorSecondRect, startSecondProp, GUIContent.none);
            }
            lines++;
            lines++;
            Rect MultiplierTypeRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.035f,
                                    position.y + lines * EditorGUIUtility.singleLineHeight,
                                    position.width * 0.35f,
                                     EditorGUIUtility.singleLineHeight);
            //lines++;
           


            EditorGUIUtility.labelWidth = 80f;
            SerializedProperty MultiplierTypeProp = property.FindPropertyRelative("multiplierType");
            EditorGUI.PropertyField(MultiplierTypeRect, MultiplierTypeProp, new GUIContent("AlterSpeed:"));

            if (!MultiplierTypeProp.enumValueIndex.Equals(0))
            {
               

                if (MultiplierTypeProp.enumValueIndex.Equals(1))
                {
                    Rect multiplierRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.55f,
                                  position.y + lines * EditorGUIUtility.singleLineHeight,
                                  position.width * 0.45f,
                                   EditorGUIUtility.singleLineHeight);

                    SerializedProperty MultiplierProp = property.FindPropertyRelative("LerpMultiplier");
                    EditorGUI.PropertyField(multiplierRect, MultiplierProp, GUIContent.none);
                }
             else if (MultiplierTypeProp.enumValueIndex.Equals(2))
                {
                    Rect multiplierRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.55f,
                                  position.y + ((lines) * EditorGUIUtility.singleLineHeight) - EditorGUIUtility.singleLineHeight,
                                  position.width * 0.1f,
                                   EditorGUIUtility.singleLineHeight *2f);

                    SerializedProperty MultiplierProp = property.FindPropertyRelative("animationCurve");
                    EditorGUI.PropertyField(multiplierRect, MultiplierProp, GUIContent.none);
                }
            }
           

            

        
            //EditorGUIUtility.fieldWidth = 80f;
            // SerializedProperty SpeedYProp = property.FindPropertyRelative("yMultiplier");
            //EditorGUI.PropertyField(SpeedYRect, SpeedYProp, new GUIContent("Y Speed"));
            lines++;
            lines++;
            Rect ReturnColorRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.035f,
                                   position.y + lines * EditorGUIUtility.singleLineHeight,
                                   position.width * 0.41f,
                                    EditorGUIUtility.singleLineHeight);
            Rect ReturnColorSelectRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.455f,
                                  position.y + lines * EditorGUIUtility.singleLineHeight,
                                  position.width * 0.2f,
                                   EditorGUIUtility.singleLineHeight);
            
            
            //lines++;
            //Rect SpeedYRect = new Rect(EditorGUI.indentLevel + position.width * 0.025f,
            //                        position.y + lines * EditorGUIUtility.singleLineHeight,
            //                        position.width * 0.45f,
            //                         EditorGUIUtility.singleLineHeight);

            EditorGUIUtility.labelWidth = 80f;
            SerializedProperty ReturnColor = property.FindPropertyRelative("colorReturn");
            EditorGUI.PropertyField(ReturnColorRect, ReturnColor, new GUIContent("Return Color?"));
            SerializedProperty returnColorProp = property.FindPropertyRelative("whichColorEnd");
            EditorGUI.PropertyField(ReturnColorSelectRect, returnColorProp, GUIContent.none);

            if (!returnColorProp.enumValueIndex.Equals(0))
            {
                Rect ReturnThisColor = new Rect(EditorGUI.indentLevel + space + position.width * 0.665f,
                                  position.y + lines * EditorGUIUtility.singleLineHeight,
                                  position.width * 0.1f,
                                   EditorGUIUtility.singleLineHeight);
                //default
                if (returnColorProp.enumValueIndex.Equals(1))
                {

                    SerializedProperty OurColor = property.FindPropertyRelative("DefaultColor");
                    EditorGUI.PropertyField(ReturnThisColor, OurColor, GUIContent.none);
                }
                else if (returnColorProp.enumValueIndex.Equals(2))
                {
                    SerializedProperty OurColor = property.FindPropertyRelative("myColorStart");
                    EditorGUI.PropertyField(ReturnThisColor, OurColor, GUIContent.none);
                }
                else if (returnColorProp.enumValueIndex.Equals(3))
                {
                    SerializedProperty OurColor = property.FindPropertyRelative("myColorEnd");
                    EditorGUI.PropertyField(ReturnThisColor, OurColor, GUIContent.none);
                }


                
            }
           
            lines++;
            
           
        }





        //Rect rectFoldout = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);
        //property.isExpanded = EditorGUI.Foldout(rectFoldout, property.isExpanded, label);

        //int lines = 1;
        //if (property.isExpanded)
        //{
        //    Rect rectType = new Rect(position.min.x, position.min.y + lines++ * EditorGUIUtility.singleLineHeight, position.size.x, EditorGUIUtility.singleLineHeight);
        //    EditorGUI.PropertyField(rectType, property.FindPropertyRelative("type"));
        //    Rect StartPos = new Rect(position.min.x, position.min.y + lines++ * EditorGUIUtility.singleLineHeight, position.size.x, EditorGUIUtility.singleLineHeight);

        //    StartPos.width *= 0.5f;
        //    EditorGUI.indentLevel = 0;
        //    EditorGUI.PropertyField(StartPos, property.FindPropertyRelative("StartDirection"), new GUIContent("Start Position"));

        //    //Stores the rainder of space on this line 
        //    StartPos.x += StartPos.width;
        //    //devide remainder into 3 to fit 
        //    StartPos.width /= 2f;
        //    EditorGUIUtility.labelWidth = 46f;

        //    //Tweak our color label width so its not fixed size 
        //    //EditorGUIUtility.labelWidth = 14f;

        //    EditorGUI.PropertyField(StartPos, property.FindPropertyRelative("StartVector"), new GUIContent("Custom"));

        //}

        // Your wrapped code here
       
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int totalLines = 2;

        if (property.isExpanded)
        {
            totalLines += 8;
        }

        return EditorGUIUtility.singleLineHeight * totalLines + EditorGUIUtility.standardVerticalSpacing * (totalLines - 1);
    }


}