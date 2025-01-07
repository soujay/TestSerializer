# TestSerializer


This is a test project to check if starting in .NET 9, JsonSerializer has (limited) support for non-nullable reference type enforcement in both serialization and deserialization.
For reference  see the following
- https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/nullable-annotations
- https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.respectnullableannotations?view=net-9.0#system-text-json-jsonserializeroptions-respectnullableannotations

# Walkthrough
This project contains a Person class with properties 'Name', 'Age' and 'Email'. The simple program class serializes and deserializes an instance of this class.
The 'Name' property is non-nullable - the value cannot be null. But in .net 8 and .net 9, this is not enforced strictly and so even if a value is not set for 'Name', it will continue to serialize and deserialize as expected. This can be seen if you run the project as it is.

Starting with .net 9, we can enforce this check by using the 'RespectNullableAnnotations' options. To test this, uncomment out line 38 and run the project. An exception is seen in console. 
