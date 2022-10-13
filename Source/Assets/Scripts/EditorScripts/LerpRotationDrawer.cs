using UnityEditor;
using UnityEngine;
namespace AnimationLibrary
{
    [CustomPropertyDrawer(typeof(RotationData))]
    public class LerpRotationDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            int lines = 0;
            lines++;
            float space = 45.4f;
            //SerializedProperty RotateComponents = property.FindPropertyRelative("rotationData");
            //if (RotateComponents.arraySize > 1 )
            //{

            //}




            //Rect lerpLast = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
            //                        position.y + lines * EditorGUIUtility.singleLineHeight,
            //                        position.width * 0.8f,
            //                         EditorGUIUtility.singleLineHeight);
            ////lines++;
            ////Rect SpeedYRect = new Rect(EditorGUI.indentLevel + position.width * 0.025f,
            ////                        position.y + lines * EditorGUIUtility.singleLineHeight,
            ////                        position.width * 0.45f,
            ////                         EditorGUIUtility.singleLineHeight);

            //EditorGUIUtility.labelWidth = 100f;
            //SerializedProperty lerpLastProp = property.FindPropertyRelative("lerpRange");
            //EditorGUI.PropertyField(lerpLast, lerpLastProp, new GUIContent("End Range Lerp"));

            lines++;

            EditorGUI.BeginProperty(position, label, property);
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            Rect rectFoldout = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);

            Rect ActivateRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.18f,
                                    position.y + lines * EditorGUIUtility.singleLineHeight,
                                    position.width * 0.25f,
                                     EditorGUIUtility.singleLineHeight);

            Rect ClampedRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.21f,
                                      position.y + lines * EditorGUIUtility.singleLineHeight,
                                      position.width * 0.2f,
                                       EditorGUIUtility.singleLineHeight);

            Rect RotationAmountRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.45f,
                                      position.y + lines * EditorGUIUtility.singleLineHeight,
                                      position.width * 0.13f,
                                       EditorGUIUtility.singleLineHeight);

            Rect RotationDirectionRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.59f,
                                     position.y + lines * EditorGUIUtility.singleLineHeight,
                                     position.width * 0.13f,
                                      EditorGUIUtility.singleLineHeight);
            Rect RotationCurveRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.80f,
                                     position.y + lines * EditorGUIUtility.singleLineHeight,
                                     position.width * 0.1f,
                                      EditorGUIUtility.singleLineHeight);


            EditorGUIUtility.labelWidth = 45f;
            SerializedProperty ActiveProp = property.FindPropertyRelative("Active");
            EditorGUI.PropertyField(ActivateRect, ActiveProp, GUIContent.none);




            SerializedProperty typProp = property.FindPropertyRelative("thisRotationLerpType");
            EditorGUI.PropertyField(ClampedRect, typProp, GUIContent.none);
            EditorGUIUtility.labelWidth = 55f;
            SerializedProperty RotationAmountProp = property.FindPropertyRelative("RotationAmount");
            EditorGUI.PropertyField(RotationAmountRect, RotationAmountProp, new GUIContent("Rotations"));
            EditorGUIUtility.labelWidth = 90f;
            SerializedProperty RotationDirectionProp = property.FindPropertyRelative("RotateForward");
            EditorGUI.PropertyField(RotationDirectionRect, RotationDirectionProp, new GUIContent("RotateForward?"));
            EditorGUIUtility.labelWidth = 32f;
            SerializedProperty RotationCurveProp = property.FindPropertyRelative("animationCurve");
            EditorGUI.PropertyField(RotationCurveRect, RotationCurveProp, new GUIContent("curve"));


            property.isExpanded = EditorGUI.Foldout(rectFoldout, property.isExpanded, label);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            if (property.isExpanded)
            {




                //Tweak our color label width so its not fixed size 

                lines += 2;

                Rect TimedRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
                                    position.y + lines * EditorGUIUtility.singleLineHeight,
                                    position.width * 0.2f,
                                     EditorGUIUtility.singleLineHeight);
                //lines++;
                Rect DurationRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.25f,
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

                Rect StartposFirstRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
                                        position.y + lines * EditorGUIUtility.singleLineHeight,
                                        position.width * 0.45f,
                                         EditorGUIUtility.singleLineHeight);

                Rect StartposSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.525f,
                                        position.y + lines * EditorGUIUtility.singleLineHeight,
                                        position.width * 0.5f,
                                         EditorGUIUtility.singleLineHeight);






                EditorGUIUtility.labelWidth = 80f;
                SerializedProperty startFirstProp = property.FindPropertyRelative("StartDirection");
                //EditorGUIUtility.fieldWidth = 80f;
                SerializedProperty startSecondProp = property.FindPropertyRelative("StartVector");

                EditorGUI.PropertyField(StartposFirstRect, startFirstProp, new GUIContent("Start Position"));
                if (startFirstProp.enumValueIndex.Equals(0))
                {
                    EditorGUI.PropertyField(StartposSecondRect, startSecondProp, GUIContent.none);
                }



                lines++;
                Rect EndPosFirstRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
                                        position.y + lines * EditorGUIUtility.singleLineHeight,
                                        position.width * 0.45f,
                                         EditorGUIUtility.singleLineHeight);


                Rect EndPosSecondRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.525f,
                                        position.y + lines * EditorGUIUtility.singleLineHeight,
                                        position.width * 0.5f,
                                         EditorGUIUtility.singleLineHeight);


                EditorGUIUtility.labelWidth = 80f;
                SerializedProperty EndFirstProp = property.FindPropertyRelative("EndDirection");
                //EditorGUIUtility.fieldWidth = 80f;
                SerializedProperty EndSecondProp = property.FindPropertyRelative("EndVector");

                EditorGUI.PropertyField(EndPosFirstRect, EndFirstProp, new GUIContent("End Position"));
                if (EndFirstProp.enumValueIndex.Equals(0))
                {

                    EditorGUI.PropertyField(EndPosSecondRect, EndSecondProp, GUIContent.none);
                }

                lines++;
                Rect SpeedXRect = new Rect(EditorGUI.indentLevel + space + position.width * 0.025f,
                                        position.y + lines * EditorGUIUtility.singleLineHeight,
                                        position.width * 0.45f,
                                         EditorGUIUtility.singleLineHeight);
                //lines++;
                //Rect SpeedYRect = new Rect(EditorGUI.indentLevel + position.width * 0.025f,
                //                        position.y + lines * EditorGUIUtility.singleLineHeight,
                //                        position.width * 0.45f,
                //                         EditorGUIUtility.singleLineHeight);

                EditorGUIUtility.labelWidth = 80f;
                SerializedProperty SpeedXProp = property.FindPropertyRelative("RotateMultiplier");
                EditorGUI.PropertyField(SpeedXRect, SpeedXProp, new GUIContent("Rotation Speed"));
                //EditorGUIUtility.fieldWidth = 80f;
                // SerializedProperty SpeedYProp = property.FindPropertyRelative("yMultiplier");
                //EditorGUI.PropertyField(SpeedYRect, SpeedYProp, new GUIContent("Y Speed"));



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
                totalLines += 6;
            }

            return EditorGUIUtility.singleLineHeight * totalLines + EditorGUIUtility.standardVerticalSpacing * (totalLines - 1);
        }


    }
}