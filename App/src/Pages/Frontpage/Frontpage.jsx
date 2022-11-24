import React from "react";
import { Link } from "react-router-dom";
import landingimage from "../../images/landingcat.png";
import { Button } from "@mui/material";
// import landingimage from "./images/landingcat.png";
import "./Frontpage.css";

const Front = () => {
  return (
    <div
      className="landingimage"
      style={{ backgroundImage: `url(${landingimage})` }}
    >
      <div className="landingimage__herotext">
        <h1 className="landingimage__herotitle">Pet Finder</h1>
        <p>
          Lorem ipsum dolor sit amet consectetur, adipisicing elit. Nam
          accusamus vero non tempore iure modi mollitia vitae similique tenetur
          inventore illo itaque facilis, provident sapiente delectus dolorum
          nulla veniam ullam.
        </p>

        <div className="landingimage__herotextbuttons">
          <Link to="map" relative="path">
            <Button variant="contained">See Map</Button>
          </Link>

          <Button variant="contained">Report Lost Cat</Button>
        </div>
      </div>
      {/* <Link to="/map">Sightings map</Link> */}
    </div>
  );
};

export default Front;
