import * as React from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Unstable_Grid2/Grid2';
import landingimage from "../../images/landingcat.png";
import { useState, useEffect } from 'react';
import axios from "axios";


export default function Cards() {
    const [Cats, setCats] = useState([]);
     useEffect(() => {
         axios.get("https://petfinderapi.azurewebsites.net/api/Wanting").then((response) => {
          setCats((data) => {
            return response.data;
          });
        });
      }, []);
      console.log(Cats);
    const data = [
        { name: "lilly 1", description: 13000 },
        { name: "lilly 2", description: 16500 },
        { name: "lilly 3", description: 14250 },
        { name: "lilly 4", description: 19000 },
        { name: "lilly 33", description: 14250 },
        { name: "lilly 42", description: 19000 }
    ]

    return (
        <>
            <Grid
                container
                spacing={2}
                direction="row"
                justify="flex-start"
                alignItems="flex-start"
            >
                {data.map(elem => (
                    <Grid item xs={12} sm={6} md={3} mt={3} key={data.indexOf(elem)}>
                        <Card sx={{ maxWidth: 345, border:'1px solid' }}>
                            <CardMedia
                                component="img"
                                height="140"
                                image='${landingimage}'
                                alt="green iguana"
                            />
                            <CardContent>
                                <Typography gutterBottom variant="h5" component="div">
                                {`Name : ${elem.name}`}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                {`Description : ${elem.description}`}, amet consectetur adipisicing elit. Dicta, repellendus!
                                </Typography>
                            </CardContent>
                            <CardActions>
                                <Button size="small">Contact</Button>
                                <Button size="small">Location</Button>
                            </CardActions>
                        </Card>
                    </Grid>
                ))}
            </Grid>
        </>
    )
}
