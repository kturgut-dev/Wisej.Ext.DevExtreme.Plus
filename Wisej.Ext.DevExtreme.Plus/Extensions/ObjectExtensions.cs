using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisej.Ext.DevExtreme.Plus.Extensions
{
    public static class ObjectExtensions
    {
        public static dynamic ToDynamic(this object value)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
                expando.Add(property.Name, property.GetValue(value));

            return expando as ExpandoObject;
        }

        //https://stackoverflow.com/questions/9956648/how-do-i-check-if-a-property-exists-on-a-dynamic-anonymous-type-in-c
        public static bool DoesPropertyExist(this object settings, string name)
        {
            if (settings is ExpandoObject)
                return ((IDictionary<string, object>)settings).ContainsKey(name);

            return settings.GetType().GetProperty(name) != null;
        }

        public static bool DynamicDoesPropertyExist(dynamic settings, string name)
        {
            if (settings is ExpandoObject)
                return ((IDictionary<string, object>)settings).ContainsKey(name);

            return settings.GetType().GetProperty(name) != null;
        }

        public static object GetPropertyValue(this object data, string propertyName)
        {
            return data.GetType()?.GetProperty(propertyName)?.GetValue(data, null);
        }

        public static DataTable ObjectToDataTable(this List<object> items)
        {
            if (items == null) return null;

            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(items.FirstOrDefault());
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (object item in items)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}
