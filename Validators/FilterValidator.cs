using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CollectionsProject.data;
using CollectionsProject.Models;

namespace CollectionsProject.Validators;

public class FilterValidator
{

    public static bool IsMatchingVehicle(PropertyInfo propertyInfo, Vehicle vehicle, string name, string value)
    {
        var propertyValue = propertyInfo.GetValue(vehicle, null);
        if (propertyValue == null)
            return false;
        var propertyType = propertyInfo.PropertyType;
        if (name.Contains(':'))
        {

            var vehiclePartName = name.Split(":")[0];
            var vehiclePartParameter = name.Split(":")[1];
            if (!propertyType.Name.Equals(vehiclePartName, StringComparison.OrdinalIgnoreCase))
                return false;
            return propertyType.GetProperties()
                .Any(prop => IsMatchingPropertyValue(prop, propertyValue, vehiclePartParameter, value));
        }
        return IsMatchingPropertyValue(propertyInfo, propertyValue, name, value);
    }

    public static bool IsValidPropertyNameAndValue(string propertyName, string value)
    {
        return VehicleData.VehicleTypes.Any(vehicleType => vehicleType.GetProperties()
        .Any(prop => IsValidKeyValue(prop, propertyName, value)));
    }


    private static bool IsValidKeyValue(PropertyInfo propertyInfo, string name, string value)
    {
        var propertyType = propertyInfo.PropertyType;
        if (name.Contains(':'))
        {
            var vehiclePartName = name.Split(":")[0];
            var vehiclePartParameter = name.Split(":")[1];
            if (!propertyType.Name.Equals(vehiclePartName, StringComparison.OrdinalIgnoreCase))
                return false;

            return propertyType.GetProperties().Any(prop => IsMatchingPropertyType(prop, vehiclePartParameter, value));
        }
        return IsMatchingPropertyType(propertyInfo, name, value);
    }

    private static bool IsMatchingPropertyType(PropertyInfo propertyInfo, string name, string value)
    {
        var propertyType = propertyInfo.PropertyType;
        if (propertyType.IsPrimitive || propertyType == typeof(decimal) || propertyType == typeof(string))
            return propertyInfo.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                && TypeDescriptor.GetConverter(propertyInfo.PropertyType).IsValid(value);
        return false;
    }

    private static bool IsMatchingPropertyValue(PropertyInfo propertyInfo, object obj, string name, string value)
    {
        var propertyType = propertyInfo.PropertyType;
        var propertyValue = propertyInfo.GetValue(obj, null);
        if (propertyValue == null)
            return false;
        if (propertyType.IsPrimitive || propertyType == typeof(decimal) || propertyType == typeof(string))
            return propertyInfo.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                propertyValue.ToString().Equals(value, StringComparison.OrdinalIgnoreCase);
        return false;
    }
}
