import React from 'react'
import { FormControl, InputLabel, Button, FormHelperText, TextField, Box } from '@mui/material';
import { useRef } from "react";
import axios from "axios";

export default function AddWanting() {
    const [name, setName] = React.useState('Cat in the Hat');
    const [ownerName, setOwnerName] = React.useState('');
    const [catName, setCatName] = React.useState('');

    const handleChange = (event) => {
        setName(event.target.value);
    };


    //const navigate = useNavigate();
    function wantingHandler() {
        var payload = {
            OwnerName: ownerName,
            CatName: catName,

        };
        console.log(payload);
        axios
            .post("https://localhost:7164/api/Cats/wanting", payload)
            .then((response) => {
                //navigate("/");
                console.log(response);
            })
            .catch((error) => {
                console.log(error.response);
            });
    }

    return (
        <Box
            component="form"
            sx={{
                '& > :not(style)': { m: 1, mt: 3, width: '25ch' },
            }}
            noValidate
            autoComplete="off"
        >
            <TextField
                id="ownerName"
                label="Owner Name"
                value={ownerName}
                onChange={e => setOwnerName(e.target.value)}
            />
            <TextField
                id="catName"
                label="cat Name"
                value={catName}
                onChange={e => setCatName(e.target.value)}
            />
            <Button variant="contained" color="success" onClick={wantingHandler} sx={{ mt: 3 }}>Submit</Button>
        </Box>
    )
}
