using System;
using System.Reflection;

namespace AchaRentzBLL.Interfaces.ReusableLogics
{
    public class ReusableCodeSnippets : IReusableCodeSnippets
    {
        public void SaveDataTemp<T>(T existingData, T NewData) where T : class
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                // Get the value of the property in newData
                var newValue = property.GetValue(NewData);

                // Update the property in existingData if the new value is non-null
                if (newValue != null)
                {
                    property.SetValue(existingData, newValue);
                }
            }
        }
    }
}
