using UnityEditor;
using UnityEngine;

// tells us what inspector Script to draw over
[CustomPropertyDrawer(typeof(ColorPoint))]
public class ColorPointDrawer : PropertyDrawer
{

   

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property);
        Rect contentPosition = EditorGUI.PrefixLabel(position, label);
        //    ///STOP SQEWING VERTICLE WHEN EDITOR WINDOW IS SMALL 
        if (position.height > 16f)
        {
            position.height = 16f;
            EditorGUI.indentLevel += 1;
            contentPosition = EditorGUI.IndentedRect(position);
            contentPosition.y += 18f;
        }
        //this tells us that POSITION VECTOR WILL TAKE UP 0.75 PERCENT OF THIS LINE
        contentPosition.width *= 0.75f;
        //this gets rid of indentation meaning places thing to the left 
        EditorGUI.indentLevel = 0;
        //this finds the position to place   
        EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("position"), GUIContent.none);
        //Stores the rainder of space on this line 
        contentPosition.x += contentPosition.width;
        //devide remainder into 3 to fit our label(name), space , and color
        contentPosition.width /= 3f;
        //Tweak our color label width so its not fixed size 
        EditorGUIUtility.labelWidth = 14f;
        //we create another feild for our new property    
        EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("color"), new GUIContent("C"));

        EditorGUI.EndProperty();

        GetPropertyHeight(property.FindPropertyRelative("position"), GUIContent.none);

    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return Screen.width < 333 ? (16f + 18f) : 32f;
    }
    ////this is to signify the start of our property so we can copy the wole thing and have all the extra func tionality(NEEDS END)
    //label = EditorGUI.BeginProperty(position, label, property);
    //    //label
    //    Rect contentPosition =  EditorGUI.PrefixLabel(position, label);
    //    ////////////////////////////////////////////////////////////////////
    //    ///STOP SQEWING VERTICLE WHEN EDITOR WINDOW IS SMALL 
    //    //if (position.height > 16f)
    //    //{
    //    //    position.height = 16f;
    //    //    EditorGUI.indentLevel += 1;
    //    //    contentPosition = EditorGUI.IndentedRect(position);
    //    //    contentPosition.y += 18f;
    //    //}
    //    /////////////////////////////////////////////////////////////////////
    //    //this tells us that POSITION VECTOR WILL TAKE UP 0.75 PERCENT OF THIS LINE
    //    contentPosition.width = 0.75f;

    //    //this gets rid of indentation meaning places thing to the left 
    //    EditorGUI.indentLevel = 0;
    //    //this finds the position to place                                   //this V is the ref
    //    EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("position"),GUIContent.none);
    //    //Stores the rainder of space on this line 
    //    contentPosition.x += contentPosition.width;
    //    //devide remainder into 3 to fit our label(name), space , and color
    //    contentPosition.width /= 3f;
    //    //Tweak our color label width so its not fixed size 
    //    EditorGUIUtility.labelWidth = 14f;
    //    //we create another feild for our new property                                     and call it a name 
    //    EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("color"), new GUIContent("C"));

    //    //PROPERTY END
    //    EditorGUI.EndProperty();


    //public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    //{
    //    return Screen.width < 333 ? (16f + 18f) : 16f;
    //}

}