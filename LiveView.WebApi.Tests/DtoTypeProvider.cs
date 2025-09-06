using System;

namespace LiveView.WebApi.Tests
{
    internal static class DtoTypeProvider
    {
        public static Type GetFromControllerType(Type ctrl)
        {
            var current = ctrl;
            while (current != null)
            {
                var baseType = current.BaseType;
                if (baseType == null)
                {
                    break;
                }

                if (baseType.IsGenericType)
                {
                    var genDef = baseType.GetGenericTypeDefinition();
                    if (genDef.Name.StartsWith("ApiControllerBase", StringComparison.Ordinal))
                    {
                        var args = baseType.GetGenericArguments();
                        if (args.Length > 0)
                        {
                            return args[0];
                        }
                        break;
                    }
                }

                current = baseType;
            }

            return null;
        }
    }
}
