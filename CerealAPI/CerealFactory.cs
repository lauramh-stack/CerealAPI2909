using System.Globalization;

namespace CerealAPI;

public class CerealFactory
{
    public static CerealClass CreateFromCsv(string[] fields)
    {
        if (fields.Length != 16) 
            throw new FormatException("The number of fields must be exactly 16");
        
        return new CerealClass
        {
            Name = fields[0],
            Mfr = fields[1],
            Type = fields[2],
            Calories = ParseInt(fields[3]),
            Protein = ParseInt(fields[4]),
            Fat = ParseInt(fields[5]),
            Sodium = ParseInt(fields[6]),
            Fiber = ParseDouble(fields[7]),
            Carbo = ParseDouble(fields[8]),
            Sugars = ParseInt(fields[9]),
            Potass = ParseInt(fields[10]),
            Vitamins = ParseInt(fields[11]),
            Shelf = ParseInt(fields[12]),
            Weight = ParseDouble(fields[13]),
            Cups = ParseDouble(fields[14]),
            Rating = ParseDouble(fields[15])
        };
    }

    // Parses the int and makes sure the result is a valid integer
    private static int ParseInt(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return 0;
        if (!int.TryParse(input.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture,
                out var result))
            return 0;
        return result;
    }
    
    // Parses the double and makes sure the result is a valid double
    private static double ParseDouble(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return 0;
        if (!double.TryParse(input.Replace(",", ".").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture,
                out var result))
            return 0;
        return result;
    }
}