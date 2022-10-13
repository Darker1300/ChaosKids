using UnityEditor;
using UnityEngine;
namespace AnimationLibrary { 
[CustomPropertyDrawer(typeof(LerpTransformData))]
public class LerpPositionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        float space = 45.4f;
        EditorGUI.BeginProperty(position, label, property);
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        
        Rect rectFoldout = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);

        int lines = 0;
        Rect ActivateRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.18f,
                                position.y + lines * EditorGUIUtility.singleLineHeight,
                                position.width * 0.25f,
                                 EditorGUIUtility.singleLineHeight);

        Rect ClampedRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.21f,
                                  position.y + lines * EditorGUIUtility.singleLineHeight,
                                  position.width * 0.2f,
                                   EditorGUIUtility.singleLineHeight);

        EditorGUIUtility.labelWidth = 45f;
        SerializedProperty ActiveProp = property.FindPropertyRelative("Active");
        EditorGUI.PropertyField(ActivateRect, ActiveProp,GUIContent.none);

        SerializedProperty typProp = property.FindPropertyRelative("type");

        //EditorGUIUtility.wid = 20f;
        EditorGUI.PropertyField(ClampedRect, typProp, GUIContent.none);
        property.isExpanded = EditorGUI.Foldout(rectFoldout, property.isExpanded, label);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
       

        if (property.isExpanded)
        {

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


            //Tweak our color label width so its not fixed size 

            
            //draw new lable and calculate new position 

          
            EditorGUI.indentLevel = 0;

            Rect StartposFirstRect = new Rect(EditorGUI.indentLevel + space + position.width *0.025f,
                                    position.y + lines * EditorGUIUtility.singleLineHeight,
                                    position.width * 0.3f,
                                     EditorGUIUtility.singleLineHeight);

            Rect StartposSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.35f,
                                    position.y + lines * EditorGUIUtility.singleLineHeight,
                                    position.width * 0.15f,
                                     EditorGUIUtility.singleLineHeight);





           
            EditorGUIUtility.labelWidth = 80f;
            SerializedProperty startFirstProp = property.FindPropertyRelative("StartDirection");
            //EditorGUIUtility.fieldWidth = 80f;
            SerializedProperty startSecondProp = property.FindPropertyRelative("StartVector");
           
          
            EditorGUI.PropertyField(StartposFirstRect, startFirstProp, new GUIContent("Start Position"));
            if (startFirstProp.enumValueIndex.Equals(0))
            {
                EditorGUI.PropertyField(StartposSecondRect, startSecondProp, GUIContent.none);
                Rect EndMultiplierSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.515f,
                               position.y + lines * EditorGUIUtility.singleLineHeight,
                               position.width * 0.2f,
                                EditorGUIUtility.singleLineHeight);
                SerializedProperty EndMultiplier = property.FindPropertyRelative("EndMultiplier");
                EditorGUI.PropertyField(EndMultiplierSecondRect, EndMultiplier, new GUIContent("Start Length"));
            }
            else
            {
                    Rect EndMultiplierSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.35f,
                                   position.y + lines * EditorGUIUtility.singleLineHeight,
                                   position.width * 0.2f,
                                    EditorGUIUtility.singleLineHeight);
                    SerializedProperty EndMultiplier = property.FindPropertyRelative("StartMultiplier");
                    EditorGUI.PropertyField(EndMultiplierSecondRect, EndMultiplier, new GUIContent("Start Length"));
                }
            

           


            lines++;
            Rect MultiplierTypeRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.035f,
                                    position.y + lines * EditorGUIUtility.singleLineHeight,
                                    position.width * 0.35f,
                                     EditorGUIUtility.singleLineHeight);
            //lines++;


           

            EditorGUIUtility.labelWidth = 80f;
            SerializedProperty MultiplierTypeProp = property.FindPropertyRelative("multiplierTypeX");
            EditorGUI.PropertyField(MultiplierTypeRect, MultiplierTypeProp, new GUIContent("AlterSpeed:"));

            if (!MultiplierTypeProp.enumValueIndex.Equals(0))
            {


                if (MultiplierTypeProp.enumValueIndex.Equals(1))
                {
                    lines++;
                    Rect multiplierRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.15f,
                                  position.y + lines * EditorGUIUtility.singleLineHeight,
                                  position.width * 0.45f,
                                   EditorGUIUtility.singleLineHeight);
                    lines++;
                    SerializedProperty MultiplierProp = property.FindPropertyRelative("xMultiplier");
                    EditorGUI.PropertyField(multiplierRect, MultiplierProp, GUIContent.none);
                }
                else if (MultiplierTypeProp.enumValueIndex.Equals(2))
                {
                    lines++;
                    Rect multiplierRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.22f,
                                  position.y + ((lines) * EditorGUIUtility.singleLineHeight),
                                  position.width * 0.1f,
                                   EditorGUIUtility.singleLineHeight * 2f);

                    SerializedProperty MultiplierProp = property.FindPropertyRelative("animationCurveX");
                    EditorGUI.PropertyField(multiplierRect, MultiplierProp, GUIContent.none);
                    lines++;
                }
            }

            lines++;
            Rect EndPosFirstRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
                                    position.y + lines * EditorGUIUtility.singleLineHeight,
                                    position.width * 0.3f,
                                     EditorGUIUtility.singleLineHeight);


            Rect EndPosSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.525f,
                                    position.y + lines * EditorGUIUtility.singleLineHeight,
                                    position.width * 0.15f,
                                     EditorGUIUtility.singleLineHeight);


            EditorGUIUtility.labelWidth = 80f;
            SerializedProperty EndFirstProp = property.FindPropertyRelative("EndDirection");
            //EditorGUIUtility.fieldWidth = 80f;
            SerializedProperty EndSecondProp = property.FindPropertyRelative("EndVector");

            EditorGUI.PropertyField(EndPosFirstRect, EndFirstProp, new GUIContent("End Position"));
            if (EndFirstProp.enumValueIndex.Equals(0))
            {

                EditorGUI.PropertyField(EndPosSecondRect, EndSecondProp, GUIContent.none);
            }else
                 
                {
                    Rect EndMultiplierSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.35f,
                                   position.y + lines * EditorGUIUtility.singleLineHeight,
                                   position.width * 0.2f,
                                    EditorGUIUtility.singleLineHeight);
                    SerializedProperty EndMultiplier = property.FindPropertyRelative("EndMultiplier");
                    EditorGUI.PropertyField(EndMultiplierSecondRect, EndMultiplier, new GUIContent("End Length"));
                }


                lines++;
            Rect SpeedXRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
                                    position.y + lines * EditorGUIUtility.singleLineHeight,
                                    position.width * 0.45f,
                                     EditorGUIUtility.singleLineHeight);
            lines++;
            Rect SpeedYRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
                                    position.y + lines * EditorGUIUtility.singleLineHeight,
                                    position.width * 0.45f,
                                     EditorGUIUtility.singleLineHeight);
           
            EditorGUIUtility.labelWidth = 80f;
            SerializedProperty SpeedXProp = property.FindPropertyRelative("xMultiplier");
            EditorGUI.PropertyField(SpeedXRect, SpeedXProp, new GUIContent("X Speed"));
            //EditorGUIUtility.fieldWidth = 80f;
            SerializedProperty SpeedYProp = property.FindPropertyRelative("yMultiplier");
            EditorGUI.PropertyField(SpeedYRect, SpeedYProp, new GUIContent("Y Speed"));



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

}



//    label = EditorGUI.BeginProperty(position, label, property);
//Rect contentPosition = EditorGUI.PrefixLabel(position, label);

////    ///STOP SQEWING VERTICLE WHEN EDITOR WINDOW IS SMALL 
//if (position.height > 16f)
//{
//    position.height = 16f;
//    EditorGUI.indentLevel += 1;
//    contentPosition = EditorGUI.IndentedRect(position);
//    contentPosition.y += 18f;
//}
////this tells us that POSITION VECTOR WILL TAKE UP 0.75 PERCENT OF THIS LINE
//contentPosition.width *= 0.75f;
////this gets rid of indentation meaning places thing to the left 
//EditorGUI.indentLevel = 0;

////this finds the position to place   
//EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("type"), new GUIContent("LerpType"));
//Rect startPos = EditorGUI.PrefixLabel(position, label);
//if (position.height > 16f)
//{
//    position.height = 16f;
//    EditorGUI.indentLevel += 1;
//    startPos = EditorGUI.IndentedRect(position);
//    startPos.y += 18f;
//}
//EditorGUI.PropertyField(startPos, property.FindPropertyRelative("StartVector"), new GUIContent("Start Position"));



////Stores the rainder of space on this line 
//contentPosition.x += contentPosition.width;
////devide remainder into 3 to fit our label(name), space , and color
//contentPosition.width /= 3f;
////Tweak our color label width so its not fixed size 
//EditorGUIUtility.labelWidth = 14f;
////we create another feild for our new property    
// EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("color"), new GUIContent("C"));


//we create another feild for our new property   
//EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("type"), GUIContent.none);
//}
//    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//    {
//        return Screen.width < 333 ? (16f + 18f) : 32f;
//    }
//    //if (GUI.Button(position, "Active"))
//    //{

//    //}
//}
