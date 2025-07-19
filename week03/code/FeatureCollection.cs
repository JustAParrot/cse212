public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

// Classes I added for support (I'm not sure if I should create another class but it was the only
// way that came to my mind to keep it faster and avoid the errors and "failed" that were killing me) 
public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public double? Mag { get; set; }
    public string Place { get; set; }
}
