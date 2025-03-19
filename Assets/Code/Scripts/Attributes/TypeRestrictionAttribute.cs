using System;
using UnityEngine;

/// <summary>
/// Атрибут, который ограничивает тип значений поля для объектов, производных от <see cref="UnityEngine.Object"/>.
/// Позволяет задать конкретный тип, разрешить или запретить объекты со сцены, а также определить поведение при несоответствии типа.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class TypeRestrictionAttribute : PropertyAttribute
{
    /// <summary>
    /// Тип, которому должно соответствовать значение поля.
    /// </summary>
    public readonly Type Type;

    /// <summary>
    /// Флаг, указывающий, разрешаются ли объекты, находящиеся на сцене.
    /// Если true, то объекты со сцены будут включены в выборку.
    /// </summary>
    public readonly bool AllowSceneObjects;

    /// <summary>
    /// Флаг, указывающий, нужно ли сбрасывать значение поля в null, если текущее значение не соответствует указанному типу.
    /// Если true, то при несоответствии типа значение будет автоматически установлено в null.
    /// </summary>
    public readonly bool SetToNull;

    /// <summary>
    /// Конструктор атрибута TypeRestriction.
    /// </summary>
    /// <param name="_type">Требуемый тип значения поля.</param>
    /// <param name="_allowSceneObjects">Флаг, разрешающий использование объектов со сцены. По умолчанию true.</param>
    /// <param name="_setToNull">Флаг, указывающий, нужно ли сбрасывать значение в null при несоответствии типа. По умолчанию true.</param>
    public TypeRestrictionAttribute(Type _type, bool _allowSceneObjects = true, bool _setToNull = true)
    {
        // Инициализация полей атрибута переданными параметрами
        Type = _type;
        AllowSceneObjects = _allowSceneObjects;
        SetToNull = _setToNull;
    }
}
