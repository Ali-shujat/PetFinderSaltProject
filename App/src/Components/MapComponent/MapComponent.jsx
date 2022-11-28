import React, { useState, useEffect } from "react";
import "./MapComponent.css";
import {
  MapContainer,
  TileLayer,
  Marker,
  Popup,
  useMapEvents,
} from "react-leaflet";

function MapComponent(props) {
  // let [mapCoordinate] = props;
  const [coordinate, setCoordinate] = useState([]);

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
  // const MapClicker = () => {
  //   const map = useMapEvents({
  //     click: () => {
  //       map.locate();
  //     },
  //     locationfound: (location) => {
  //       // console.log("location found:", location);
  //       console.log("📌longitude found:", location.longitude);
  //       console.log("📌latitude found:", location.latitude);
  //       let coord = [location.latitude, location.longitude];
  //       setCoordinate(coord);
  //       props.mapCoordinate(coord.join(", "));
  //     },
  //   });
  //   return null;
  // };

  // function MapClicker2() {
  //   const map = useMapEvents({
  //     click: () => {
  //       let mapClickLoc = map.mouseEventToLatLng();
  //       console.log(mapClickLoc.lat, mapClickLoc.lng);
  //     },
  //     // locationfound: (location) => {
  //     //   console.log("location found:", location);
  //     // },
  //   });
  //   return null;
  // }

  // marker.on('click', function(ev){
  //   var latlng = map.mouseEventToLatLng(ev.originalEvent);
  //   console.log(latlng.lat + ', ' + latlng.lng);
  // });

  ///////////////////////// EXPERIMENTING MAP SOLUTIONS

  const [initialPosition, setInitialPosition] = useState([0, 0]);
  const [selectedPosition, setSelectedPosition] = useState([0, 0]);

  useEffect(() => {
    navigator.geolocation.getCurrentPosition((position) => {
      const { latitude, longitude } = position.coords;
      setInitialPosition([latitude, longitude]);
    });
  }, []);

  const MarkersClick = () => {
    const map = useMapEvents({
      click(e) {
        setSelectedPosition([e.latlng.lat, e.latlng.lng]);
        props.mapCoordinate(selectedPosition.join(", "));
        console.log(selectedPosition);
      },
    });

    return selectedPosition ? (
      <Marker
        key={selectedPosition[0]}
        position={selectedPosition}
        interactive={false}
      />
    ) : null;
  };

  //////////////////////

  return (
    <>
      <h1>Map</h1>
      <MapContainer
        center={[59.3293, 18.0686]}
        zoom={11}
        onClick={(x) => console.log("🐶")}
      >
        <TileLayer
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        />
        {/* <MapClicker2 /> */}
        {testingMarkers.map((x) => (
          <Marker key={x[0] * Math.random()} position={x}>
            <Popup>
              <h3>Sighting</h3>
              <b>Latitude:</b> {x[0]} <br />
              <b>Longitude:</b> {x[1]} <br />
              <b>Description:</b> Blah <br />
              <i>Image Link</i>
            </Popup>
          </Marker>
        ))}
        <MarkersClick />
      </MapContainer>
    </>
  );
}

export default MapComponent;
