using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Отрисовщик атрибута <see cref="TypeRestrictionAttribute"/>.
/// Проверяет тип поля и если он не соответствует, то пытается найти нужный объект или сбрасывает значение.
/// </summary>
[CustomPropertyDrawer(typeof(TypeRestrictionAttribute))]
public class TypeRestrictionAttributeDrawer : PropertyDrawer
{
    /// <summary>
    /// Отрисовывает GUI для свойства с учетом ограничений типа.
    /// </summary>
    /// <param name="_rect">Прямоугольник, в котором будет отрисовано свойство.</param>
    /// <param name="_property">Сериализованное свойство, которое будет отрисовано.</param>
    /// <param name="_label">Метка для свойства.</param>
    public override void OnGUI(Rect _rect, SerializedProperty _property, GUIContent _label)
    {
        // Проверяем, является ли тип свойства ссылкой на объект
        if (_property.propertyType != SerializedPropertyType.ObjectReference)
            return; // Выходим, если тип не соответствует

        // Проверяем, является ли атрибут корректным
        if (!(attribute is TypeRestrictionAttribute restriction))
            return; // Выходим, если атрибут не является TypeRestrictionAttribute

        EditorGUI.BeginChangeCheck(); // Начинаем отслеживание изменений

        // Отображаем поле для выбора объекта
        Object referenceValue = EditorGUI.ObjectField(_rect, _label, _property.objectReferenceValue, typeof(Object),
            restriction.AllowSceneObjects);

        // Проверяем, были ли изменения в поле
        if (EditorGUI.EndChangeCheck())
        {
            if (referenceValue != null) // Если выбрано значение
            {
                Object oldValue = referenceValue; // Сохраняем старое значение
                Type type = referenceValue.GetType(); // Получаем тип выбранного объекта

                // Проверяем, соответствует ли тип ограничениям
                if (!restriction.Type.IsAssignableFrom(type))
                {
                    // Если это GameObject, пытаемся получить компонент нужного типа
                    if (referenceValue is GameObject gameObject)
                    {
                        referenceValue = gameObject.GetComponent(restriction.Type);
                    }
                    // Если это компонент, пытаемся получить компонент из его игрового объекта
                    else if (referenceValue is Component component)
                    {
                        referenceValue = component.gameObject.GetComponent(restriction.Type);
                    }
                    else
                    {
                        referenceValue = null; // Если тип не соответствует, сбрасываем значение
                    }
                }

                // Если значение не найдено и не разрешено сбрасывать на null
                if (referenceValue == null && !restriction.SetToNull)
                {
                    referenceValue = oldValue; // Возвращаем старое значение
                }
            }

            // Устанавливаем новое значение в сериализованное свойство
            _property.objectReferenceValue = referenceValue;
        }
    }
}
