namespace Kis.Base.Constant
{
    /// <summary>
    /// Всевозможные ошибки, кторые могут возникать исходя из общего функционала системы
    /// Каждый модуль может дополнять этот список, исходя из специфики привносимого им функионала
    /// </summary>
    public enum ErrorCodes
    {
        Success = 0,

        Parsing = 1,

        Validation = 2,

        Systematization = 3, 

        IncorrectData = 4,

        CodeNotExist = 5

    }

}
