import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";

const useStyles = makeStyles((theme) => ({
  root: {
    width: "100%",
    height: "40vh",
  },
}));

// initial location on Map
const position = [59.337524, 18.015868];
// const locations = [
//   {
//     title: "Location 1",
//     description: "Description of location 1.",
//     coordinates: [59.337524, 18.015868],
//   },
//   {
//     title: "Location 2",
//     description: "Description of location 2.",
//     coordinates: [59.337524, 18.015868],
//   },
//   {
//     title: "Location 3",
//     description: "Description of location 3.",
//     coordinates: [59.337524, 18.015868],
//   },
//   {
//     title: "Location 4",
//     description: "Description of location 4.",
//     coordinates: [59.337524, 18.015868],
//   },
//   {
//     title: "Location 5",
//     description: "Description of location 5.",
//     coordinates: [59.337524, 18.015868],
//   },
// ];

const CustomMap = () => {
  const classes = useStyles();

  return (
    <MapContainer center={position} zoom={13} className={classes.root}>
      <TileLayer
        attribution='&copy <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
      />
      {/* {locations.map((item) => (
        <Marker position={item.coordinates}>
          <Popup>
            <h1>{item.title}</h1>
            <p>{item.description}</p>
          </Popup>
        </Marker>
      ))} */}
    </MapContainer>
  );
};

export default CustomMap;