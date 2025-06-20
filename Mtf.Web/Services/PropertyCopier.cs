using System;

namespace LiveView.Web.Services
{
    public static class PropertyCopier
    {
        public static void CopyMatchingProperties<TSource, TTarget>(TSource source, TTarget target)
        {
            if (source == null || target == null)
            {
                return;
            }

            var sourceProps = typeof(TSource).GetProperties();
            var targetProps = typeof(TTarget).GetProperties();

            foreach (var sourceProp in sourceProps)
            {
                if (!sourceProp.CanRead)
                    continue;

                var targetProp = Array.Find(targetProps, p =>
                    p.Name == sourceProp.Name &&
                    p.CanWrite &&
                    p.PropertyType == sourceProp.PropertyType);

                if (targetProp != null)
                {
                    var value = sourceProp.GetValue(source);
                    targetProp.SetValue(target, value);
                }
            }
        }
    }
}
