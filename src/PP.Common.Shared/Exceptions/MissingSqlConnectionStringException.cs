namespace PP.Common.Shared.Exceptions
{
    public class MissingSqlConnectionStringException(string connectionName) : Exception
    {
        public override string Message => $"Missing ConnectionString {connectionName}, please ensure the connect string has been configured";
    }
}
