using Microsoft.AspNetCore.Mvc;

namespace CerealAPI;

public class CerealController : ControllerBase
{
    private readonly CerealDbContext _db;
    
    public CerealController(CerealDbContext db)
    {
        _db = db;
    }
    
    // Add a method to get all

    // Returns if a specific cereal exists based on the ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cereal = _db.Cereals.Find(id);
        if(cereal == null) return NotFound("No cereal exists with that ID.");
        return Ok(cereal);
    }

    // Allows the creation of a new cereal
    [HttpPost]
    public IActionResult Create(CerealClass cerealClass)
    {
        if (cerealClass.Id != 0 && _db.Cereals.Any(c => c.Id == cerealClass.Id))
        {
            return BadRequest("A cereal already exists with this ID.");
        }
        
        _db.Cereals.Add(cerealClass);
        _db.SaveChanges();
        return CreatedAtAction(nameof(GetById), new {id = cerealClass.Id}, cerealClass);
    }
    
    // Allows the user to update a preexisting cereal through it's ID
    [HttpPut("{id}")]
    public IActionResult Update(int id, CerealClass cerealClass)
    {
        // Checks if the cereal actually exists 
        // Else it returns a NotFound
        var existing = _db.Cereals.Find(id);
        if (existing == null) return NotFound("The cereal you are trying to update does not exist.");

        // Updates the cereal based on the given data
        // Currently requires all parameters be filled 
        existing.Name = cerealClass.Name;
        existing.Mfr = cerealClass.Mfr;
        existing.Type = cerealClass.Type;
        existing.Calories = cerealClass.Calories;
        existing.Protein = cerealClass.Protein;
        existing.Fat = cerealClass.Fat;
        existing.Sodium = cerealClass.Sodium;
        existing.Fiber = cerealClass.Fiber;
        existing.Carbo = cerealClass.Carbo;
        existing.Sugars = cerealClass.Sugars;
        existing.Potass = cerealClass.Potass;
        existing.Vitamins = cerealClass.Vitamins;
        existing.Shelf = cerealClass.Shelf;
        existing.Weight = cerealClass.Weight;
        existing.Cups = cerealClass.Cups;
        existing.Rating = cerealClass.Rating;
        
        // Saves the changes and returns a response code 
        _db.SaveChanges();
        return Ok(existing);
    }

    // Allows the deletion of a specific cereal based on ID
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var cereal = _db.Cereals.Find(id);
        if (cereal == null) return NotFound("No cereal exists with that ID.");
        
        _db.Remove(cereal);
        _db.SaveChanges();
        return NoContent();
    }
}