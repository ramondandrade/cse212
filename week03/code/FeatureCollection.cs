using System.Text.Json.Serialization;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }

    public FeatureCollection()
    {
        Features = new List<Feature>();
    }
}

public class Feature
{
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }

    [JsonPropertyName("geometry")]
    public Geometry Geometry { get; set; }

    public Feature()
    {
        Properties = new Properties();
        Geometry = new Geometry();
    }
}

public class Properties
{
    [JsonPropertyName("place")]
    public string Place { get; set; } = "";

    [JsonPropertyName("mag")]
    public double? Mag { get; set; }
}

public class Geometry
{
    [JsonPropertyName("coordinates")]
    public List<double> Coordinates { get; set; }

    public Geometry()
    {
        Coordinates = new List<double>();
    }
}