public class FeatureCollection
{
    // The 'features' attribute of the JSON data is an array of Feature objects.
    public Feature[] Features { get; set; } = [];
}

// The Feature class describes the 'features' attribute of the JSON data.
public class Feature
{
    // The 'properties' attribute of the JSON data is described by the Properties class.
    public Properties Properties { get; set; } = new();
}

// The Properties class describes the 'properties' attribute of the JSON data.
public class Properties
{
    // The 'place' attribute of the JSON data is a string describing the location of the earthquake.
    public string Place { get; set; } = "";

    // The 'mag' attribute of the JSON data is a number describing the magnitude of the earthquake.
    public double? Mag { get; set; }
}