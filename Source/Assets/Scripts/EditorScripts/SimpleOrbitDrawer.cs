using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//namespace AnimationLibrary
//{
//    [CustomPropertyDrawer(typeof(OrbitData))]
//public class SimpleOrbitDrawer : PropertyDrawer
//{
//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//        float space = 45.4f;
//        EditorGUI.BeginProperty(position, label, property);
//        int indent = EditorGUI.indentLevel;
//        EditorGUI.indentLevel = 0;
//        Rect rectFoldout = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);

//        int lines = 0;
//        Rect ActivateRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.18f,
//                                position.y + lines * EditorGUIUtility.singleLineHeight,
//                                position.width * 0.25f,
//                                 EditorGUIUtility.singleLineHeight);

//        Rect ClampedRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.21f,
//                                  position.y + lines * EditorGUIUtility.singleLineHeight,
//                                  position.width * 0.2f,
//                                   EditorGUIUtility.singleLineHeight);

//        Rect OrbitTypeRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.5f,
//                             position.y + lines * EditorGUIUtility.singleLineHeight,
//                             position.width * 0.2f,
//                              EditorGUIUtility.singleLineHeight);

//        Rect RotationCurveRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.80f,
//                                            position.y + lines * EditorGUIUtility.singleLineHeight,
//                                            position.width * 0.1f,
//                                             EditorGUIUtility.singleLineHeight);
//        EditorGUIUtility.labelWidth = 45f;
//        SerializedProperty ActiveProp = property.FindPropertyRelative("Active");
//        EditorGUI.PropertyField(ActivateRect, ActiveProp, GUIContent.none);




//        SerializedProperty typProp = property.FindPropertyRelative("thisRotationLerpType");
//        EditorGUI.PropertyField(ClampedRect, typProp, GUIContent.none);

//        SerializedProperty OrbitTypProp = property.FindPropertyRelative("thisOrbitType");
//        EditorGUI.PropertyField(OrbitTypeRect, OrbitTypProp, GUIContent.none);


//        EditorGUIUtility.labelWidth = 32f;
//        SerializedProperty RotationCurveProp = property.FindPropertyRelative("animationCurve");
//        EditorGUI.PropertyField(RotationCurveRect, RotationCurveProp, new GUIContent("curve"));

//        property.isExpanded = EditorGUI.Foldout(rectFoldout, property.isExpanded, label);
//        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);


//        if (property.isExpanded)
//        {




//            //Tweak our color label width so its not fixed size 

//            lines += 2;

//            Rect TimedRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
//                                position.y + lines * EditorGUIUtility.singleLineHeight,
//                                position.width * 0.2f,
//                                 EditorGUIUtility.singleLineHeight);
//            //lines++;

//            EditorGUIUtility.labelWidth = 90f;
//            SerializedProperty TimedProp = property.FindPropertyRelative("Timed");


//            //EditorGUIUtility.wid = 20f;
//            EditorGUI.PropertyField(TimedRect, TimedProp, new GUIContent("Make Timed"));
//            if (TimedProp.boolValue == true)
//            {
//                SerializedProperty TimedDurationProp = property.FindPropertyRelative("TimedDuration");
//                Rect DurationRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.25f,
//                                 position.y + lines * EditorGUIUtility.singleLineHeight,
//                                 position.width * 0.2f,
//                                  EditorGUIUtility.singleLineHeight);
//                EditorGUI.PropertyField(DurationRect, TimedDurationProp, new GUIContent("TimeDuration"));

//            }
//            //draw new lable and calculate new position 

//            lines++;
//            EditorGUI.indentLevel = 0;

//            Rect StartposFirstRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
//                                    position.y + lines * EditorGUIUtility.singleLineHeight,
//                                    position.width * 0.45f,
//                                     EditorGUIUtility.singleLineHeight);

//            Rect StartposSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.525f,
//                                    position.y + lines * EditorGUIUtility.singleLineHeight,
//                                    position.width * 0.15f,
//                                     EditorGUIUtility.singleLineHeight);

//            Rect StartMultiplierSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.69f,
//                                      position.y + lines * EditorGUIUtility.singleLineHeight,
//                                      position.width * 0.2f,
//                                       EditorGUIUtility.singleLineHeight);




//            EditorGUIUtility.labelWidth = 80f;
//            SerializedProperty startFirstProp = property.FindPropertyRelative("StartDirection");
//            //EditorGUIUtility.fieldWidth = 80f;
//            SerializedProperty startSecondProp = property.FindPropertyRelative("StartVector");
//            SerializedProperty startMultiplierProp = property.FindPropertyRelative("StartMultiplier");
//            EditorGUI.PropertyField(StartMultiplierSecondRect, startMultiplierProp, new GUIContent("Start Length"));
//            EditorGUI.PropertyField(StartposFirstRect, startFirstProp, new GUIContent("Start Position"));
//            if (startFirstProp.enumValueIndex.Equals(0))
//            {
//                EditorGUI.PropertyField(StartposSecondRect, startSecondProp, GUIContent.none);
//            }



//            lines++;
//            Rect EndPosFirstRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
//                                    position.y + lines * EditorGUIUtility.singleLineHeight,
//                                    position.width * 0.45f,
//                                     EditorGUIUtility.singleLineHeight);


//            Rect EndPosSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.525f,
//                                    position.y + lines * EditorGUIUtility.singleLineHeight,
//                                    position.width * 0.15f,
//                                     EditorGUIUtility.singleLineHeight);

//            Rect EndMultiplierSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.69f,
//                                      position.y + lines * EditorGUIUtility.singleLineHeight,
//                                      position.width * 0.2f,
//                                       EditorGUIUtility.singleLineHeight);

//            SerializedProperty EndMultiplier = property.FindPropertyRelative("EndMultiplier");
//            EditorGUI.PropertyField(EndMultiplierSecondRect, EndMultiplier, new GUIContent("Start Length"));
//            EditorGUIUtility.labelWidth = 80f;
//            SerializedProperty EndFirstProp = property.FindPropertyRelative("EndDirection");
//            //EditorGUIUtility.fieldWidth = 80f;
//            SerializedProperty EndSecondProp = property.FindPropertyRelative("EndVector");

//            EditorGUI.PropertyField(EndPosFirstRect, EndFirstProp, new GUIContent("End Position"));
//            if (EndFirstProp.enumValueIndex.Equals(0))
//            {

//                EditorGUI.PropertyField(EndPosSecondRect, EndSecondProp, GUIContent.none);
//            }

//            lines++;
//            Rect SpeedXRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
//                                    position.y + lines * EditorGUIUtility.singleLineHeight,
//                                    position.width * 0.45f,
//                                     EditorGUIUtility.singleLineHeight);

//            lines++;
//            Rect StartCenterRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
//                               position.y + lines * EditorGUIUtility.singleLineHeight,
//                               position.width * 0.45f,
//                                EditorGUIUtility.singleLineHeight);
//            lines++;
//            Rect TakeXRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
//                               position.y + lines * EditorGUIUtility.singleLineHeight,
//                               position.width * 0.45f,
//                                EditorGUIUtility.singleLineHeight);
//            //lines++;
//            //Rect SpeedYRect = new Rect(EditorGUI.indentLevel + position.width * 0.025f,
//            //                        position.y + lines * EditorGUIUtility.singleLineHeight,
//            //                        position.width * 0.45f,
//            //                         EditorGUIUtility.singleLineHeight);

//            EditorGUIUtility.labelWidth = 80f;
//            SerializedProperty SpeedXProp = property.FindPropertyRelative("OrbitMultiplier");
//            EditorGUI.PropertyField(SpeedXRect, SpeedXProp, new GUIContent("Orbit Speed"));


//            if (OrbitTypProp.enumValueIndex.Equals(1))
//            {
//                EditorGUIUtility.labelWidth = 80f;
//                SerializedProperty ToCenterProp = property.FindPropertyRelative("StartFromCentre");
//                EditorGUI.PropertyField(StartCenterRect, ToCenterProp, new GUIContent("StartFromCentre"));
//            }


//            EditorGUIUtility.labelWidth = 80f;
//            SerializedProperty TakeXProp = property.FindPropertyRelative("TakeX");
//            EditorGUI.PropertyField(TakeXRect, TakeXProp, new GUIContent("OrbitXDirection?"));


//            //EditorGUIUtility.fieldWidth = 80f;
//            // SerializedProperty SpeedYProp = property.FindPropertyRelative("yMultiplier");
//            //EditorGUI.PropertyField(SpeedYRect, SpeedYProp, new GUIContent("Y Speed"));



//        }





//        //Rect rectFoldout = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);
//        //property.isExpanded = EditorGUI.Foldout(rectFoldout, property.isExpanded, label);

//        //int lines = 1;
//        //if (property.isExpanded)
//        //{
//        //    Rect rectType = new Rect(position.min.x, position.min.y + lines++ * EditorGUIUtility.singleLineHeight, position.size.x, EditorGUIUtility.singleLineHeight);
//        //    EditorGUI.PropertyField(rectType, property.FindPropertyRelative("type"));
//        //    Rect StartPos = new Rect(position.min.x, position.min.y + lines++ * EditorGUIUtility.singleLineHeight, position.size.x, EditorGUIUtility.singleLineHeight);

//        //    StartPos.width *= 0.5f;
//        //    EditorGUI.indentLevel = 0;
//        //    EditorGUI.PropertyField(StartPos, property.FindPropertyRelative("StartDirection"), new GUIContent("Start Position"));

//        //    //Stores the rainder of space on this line 
//        //    StartPos.x += StartPos.width;
//        //    //devide remainder into 3 to fit 
//        //    StartPos.width /= 2f;
//        //    EditorGUIUtility.labelWidth = 46f;

//        //    //Tweak our color label width so its not fixed size 
//        //    //EditorGUIUtility.labelWidth = 14f;

//        //    EditorGUI.PropertyField(StartPos, property.FindPropertyRelative("StartVector"), new GUIContent("Custom"));

//        //}


//        EditorGUI.EndProperty();
//    }

//    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//    {
//        int totalLines = 2;

//        if (property.isExpanded)
//        {
//            totalLines += 5;
//        }

//        return EditorGUIUtility.singleLineHeight * totalLines + EditorGUIUtility.standardVerticalSpacing * (totalLines - 1);
//    }


//}
//}
