using System.Globalization;

namespace CerealAPI;

public class CerealFactory
{
    public static CerealClass CreateFromCsv(string[] fields)
    {
        return new CerealClass
        {
            Name = fields[0],
            Mfr = fields[1],
            Type = fields[2],
            Calories = int.Parse(fields[3]),
            Protein = int.Parse(fields[4]),
            Fat = int.Parse(fields[5]),
            Sodium = int.Parse(fields[6]),
            Fiber = float.Parse(fields[7].Replace(",", "."), CultureInfo.InvariantCulture),
            Carbo = float.Parse(fields[8].Replace(",", "."), CultureInfo.InvariantCulture),
            Sugars = int.Parse(fields[9]),
            Potass = int.Parse(fields[10]),
            Vitamins = int.Parse(fields[11]),
            Shelf = int.Parse(fields[12]),
            Weight = float.Parse(fields[13].Replace(",", "."), CultureInfo.InvariantCulture),
            Cups = float.Parse(fields[14].Replace(",", "."), CultureInfo.InvariantCulture),
            Rating = float.Parse(fields[15].Replace(",", "."), CultureInfo.InvariantCulture)
        };
    }
}