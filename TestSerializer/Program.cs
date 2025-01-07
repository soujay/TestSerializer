using System.Text.Json;

namespace NullableJsonExample
{
    // Define a class with nullable annotations
    public class Person
    {

        public string Name { get; set; } // Non-nullable property - Name cannot be null 
        public int? Age { get; set; } // Nullable integer property
        public string? Email { get; set; } // Nullable reference type (string can be null)
    }



    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of Person with some nullable values
            var person = new Person
            {
                //Name = "Jack",
                Age = 30,
                Email = null, // Explicitly null email
            };

            // Serialize the object to JSON
            string json = JsonSerializer.Serialize(person);
            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(json);

            // Deserialize the JSON back to a Person object
            try
            {
                JsonSerializerOptions options = new()
                {
                    //RespectNullableAnnotations = true

                    //if true - Configures the serializer to throw an exception when trying to serialize a null value from a non-nullable property getter,
                    //or when deserializing a null value into a non-nullable property setter or constructor parameter.
                };
                var deserializedPerson = JsonSerializer.Deserialize<Person>(json, options);
                Console.WriteLine("Deserialization was successful ");
                Console.WriteLine(deserializedPerson.Name + "," + deserializedPerson.Age.ToString() + "," + deserializedPerson.Email);

            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Exception during deserialization: {ex.Message}");
            }

        }
    }
}
