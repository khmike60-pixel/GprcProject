global using Form = GrpcWinForms.Controls.FormTemplate.Form;

public static class GlobalConfig
{
    /// <summary> True - использовать систему прав. </summary>
    public static bool Enabled = true;

    /// <summary> Имя локальной БД. </summary>    
    public static string LocalDataBase = string.Empty;

    /// <summary> Имя глобальной БД. </summary>
    public static string GlobalDataBase = string.Empty;

    /// <summary> Идентификатор субъекта. </summary>
    public static int SubjectId;
}