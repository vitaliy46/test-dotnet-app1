namespace Kis.Base.Dao
{
    /// <summary>
    /// Используется для перехвата sql команд и логирования их содержимого для определения 
    /// эффективности генерируемых запросов
    /// https://cmatskas.com/logging-and-tracing-with-entity-framework-6/
    /// http://habrahabr.ru/post/221681/ - Профайлер для Entity Framework
    /// </summary>
    //[Service(typeof(UniversalDbCommandInterseptor))]
    //public class UniversalDbCommandInterseptor : IDbCommandInterceptor
    //{
    //    public ILoggingService Logger { get; set; }

    //    private readonly Stopwatch _stopwatch = new Stopwatch();

    //    private readonly bool _needStackTrace = bool.Parse(ConfigurationManager.AppSettings["NeedStackTraceInSqlCommandLog"]);

    //    private readonly int _lengthLimit = int.Parse(ConfigurationManager.AppSettings["LengthLimitationSqlCommandLog"]);

    //    private readonly int _timeLimit = int.Parse(ConfigurationManager.AppSettings["TimeLimitationSqlCommandLog"]);

    //    public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    //    {
    //        _stopwatch.Restart();
            
    //    }

       
    //    public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    //    {
    //        _stopwatch.Stop();

    //        _writeLog(command.CommandText, interceptionContext);

            
    //    }

    //    public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    //    {
    //        _stopwatch.Restart();


    //   }

    //    public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    //    {
    //        _stopwatch.Stop();

    //        _writeLog(command.CommandText, interceptionContext);

    //    }

    //    public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    //    {
    //        _stopwatch.Restart();

    //    }

    //    public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    //    {
    //        _stopwatch.Stop();

    //        _writeLog(command.CommandText, interceptionContext);

    //    }
    //    private void _writeLog<T>(string text, DbCommandInterceptionContext<T> interceptionContext)
    //    {
    //        //Считаем подозрительными и логируем запросы у которых sql команда длиной более указаного к-ва символов
    //        if (text.Length >= _lengthLimit || _stopwatch.ElapsedMilliseconds >= _timeLimit)
    //        {
    //            //var formating = "\r\n-------------------------------------------------\r\n";
    //            //выбираются все вызова исключительно системы Urish 
                
    //            var satckTrace = String.Join("\r\n", new System.Diagnostics.StackTrace()
    //                .GetFrames().Where(f=>f.GetMethod().DeclaringType!=null)
    //                .Where(f => f.GetMethod().DeclaringType.FullName.Contains("Urish"))
    //                //последние два вызова пропускаются, т.к. относятся к текущему классу
    //                .Skip(2)
    //                //Более ранние вызова неинтересны
    //                .Take(4)
    //                .Select(f =>
    //                {
    //                    var method = f.GetMethod();
    //                    return method.DeclaringType + "."
    //                           + method.Name
    //                           + "("+String.Join(",", method.GetParameters().Select(p => p.Name))+")";

    //                }).ToList());
    //            Logger.Debug<DbContext>(string.Format("Sql.Length:{0} char, Sql.Time:{1} mls \r\n {2} \r\n\r\n",
    //                text.Length,
    //                _stopwatch.ElapsedMilliseconds,
    //                _needStackTrace?satckTrace:string.Empty
    //                //formating,
    //                ));
    //        }
    //    }
    //}
}
