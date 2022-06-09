using System.Globalization;

namespace Test2.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName, int idEntity) : base(CustomMessage(entityName, idEntity))
    {
    }

    private static string CustomMessage(string entityName, params object[] args)
    {
        return $"{entityName}({args}) not found";
    }
}