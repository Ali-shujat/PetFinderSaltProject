import React, { useState } from "react";
import "./MapComponent.css";
import {
  MapContainer,
  TileLayer,
  Marker,
  Popup,
  useMapEvents,
} from "react-leaflet";

function MapComponent(props) {
  const [catCoords, setCatCoords] = useState([]);

  // useEffect(() => {
  //   // Fetch data from the db to get coords and other data
  // }, []);

  //TODO: Add geolocation so map centers on user location

  // The markers will be imported from the database instead
  let testingMarkers = [
    [59.273, 18.0286],
    [59.2693, 18.1686],
    [59.3293, 18.0686],
    [50, 18],
  ];

  // For selecting a point on the map, for the submission forms
  const MapClicker = () => {
    const map = useMapEvents({
      click: () => {
        map.locate();
      },
      locationfound: (location) => {
        console.log("location found:", location);
        // setCatCoords(location)
      },
    });
    return null;
  };

  return (
    <>
      <h1>Map</h1>
      <MapContainer center={[59.3293, 18.0686]} zoom={11}>
        <TileLayer
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        />
        {testingMarkers.map((x) => (
          <Marker position={x}>
            <Popup>
              <h3>Sighting</h3>
              <b>Latitude:</b> {x[0]} <br />
              <b>Longitude:</b> {x[1]} <br />
              <b>Description:</b> Blah <br />
              <i>Image Link</i>
            </Popup>
          </Marker>
        ))}
        <MapClicker />
      </MapContainer>
    </>
  );
}

export default MapComponent;
