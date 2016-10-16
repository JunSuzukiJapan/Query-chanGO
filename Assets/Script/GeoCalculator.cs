using System;

public class GeoCalculator {
	public float lat { get; set; }
	public float lon { get; set; }

	const float latitudeDiff = 0.004060f;
	const float longitudeDiff = 0.005360f;

	public GeoCalculator (float latitude, float longitude)	{
		lat = latitude;
		lon = longitude;
	}

	public GeoCalculator West(){
		return new GeoCalculator (lat, lon - longitudeDiff);
	}

	public GeoCalculator East(){
		return new GeoCalculator (lat, lon + longitudeDiff);
	}

	public GeoCalculator North(){
		return new GeoCalculator (lat + latitudeDiff, lon);
	}

	public GeoCalculator South(){
		return new GeoCalculator (lat - latitudeDiff, lon);
	}

	public GeoCalculator NorthWest(){
		return new GeoCalculator (lat + latitudeDiff, lon - longitudeDiff);
	}

	public GeoCalculator NorthEast(){
		return new GeoCalculator (lat + latitudeDiff, lon + longitudeDiff);
	}

	public GeoCalculator SouthWest(){
		return new GeoCalculator (lat - latitudeDiff, lon - longitudeDiff);
	}

	public GeoCalculator SouthEast(){
		return new GeoCalculator (lat - latitudeDiff, lon + longitudeDiff);
	}
}

