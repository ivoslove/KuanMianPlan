using System.ComponentModel;

/// <summary>
/// 多语言枚举类
/// </summary>
public class LanguageEnumData {

    //语言类型
    public enum LanguageType
    {
        [Description("汉语")]
        Chinese=0,
        [Description("英语")]
        English
    }
}
