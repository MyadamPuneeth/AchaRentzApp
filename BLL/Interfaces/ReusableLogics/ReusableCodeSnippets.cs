using System;
using System.Reflection;

namespace AchaRentzBLL.Interfaces.ReusableLogics
{
    public class ReusableCodeSnippets : IReusableCodeSnippets
    {
        public void SaveDataTemp<T>(T existingData, T newData) where T : class
        {
            if (existingData == null || newData == null)
                throw new ArgumentNullException("Both existingData and newData must be non-null.");

            // Get all public instance properties of the type T
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                // Get the value of the property in newData
                var newValue = property.GetValue(newData);

                // Update the property in existingData if the new value is non-null
                if (newValue != null)
                {
                    property.SetValue(existingData, newValue);
                }
            }
        }
    }
}
