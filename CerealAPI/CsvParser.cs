namespace CerealAPI;

public class CsvParser
{
    private readonly CerealDbContext _db;
    public CsvParser(CerealDbContext db)
    {
        _db = db;
    }

    public void Parse(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found", filePath);
        
        var lines = File.ReadAllLines(filePath);

        if (lines.Length <= 2)
            return; // No Data
        
        var cereals = new List<CerealClass>();
        
        // Skips header & type rows (Hence the Skip(2))
        foreach (var line in lines.Skip(2))
        {
            if(string.IsNullOrWhiteSpace(line)) continue;
            
            var fields = line.Split(';').Select(x => x.Trim()).ToArray();

            try
            {
                var cereal = CerealFactory.CreateFromCsv(fields);
                cereals.Add(cereal);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Line skipped due to; {e.Message}");
            }
        }
            _db.AddRange(cereals);
            _db.SaveChanges();
    }
}