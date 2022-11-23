import React from 'react';
import { useRef } from "react";
import { Divider, Typography, FormHelperText, Button, Box, Container, TextField } from '@mui/material';
import axios from "axios";
import { useNavigate } from "react-router-dom";

function Wanting() {
    const ownerName = useRef("");
    const email = useRef("");
    const catName = useRef("");
    const position = useRef("");
    const evenInfo = useRef("");

    const navigate = useNavigate();
    function wantingHandler() { 
        var payload = {
            developerName: ownerName.current.value,
            qualification: email.current.value,
            expertise: catName.current.value,
            imageUrl: position.current.value,
            imageUrl: evenInfo.current.value,
        };

        axios
            .post("https://localhost:7073/SuperDeveloper", payload)
            .then((response) => {
                navigate("/");
            });
    }
    return (
        <div>
            <Container
                variant="outlined"
                sx={{ width: 400, maxWidth: '100%', gap: 1.5 }}>
               <Typography variant="h4" color="inherit" noWrap>
                    Pet Finder Form
                </Typography>
                <Divider />
                <Box component="form"
                    sx={{
                        '& .MuiTextField-root': { m: 1, width: '25ch' },
                    }}
                    noValidate
                    autoComplete="off">

                    <TextField
                        helperText="Please enter owner name"
                        id="ownerName"
                        label="Owner Name"
                    />
                    <TextField
                        helperText="Please enter your email"
                        id="email"
                        label="email"
                    />
                    <TextField
                        helperText="Please enter your cat name"
                        id="catName"
                        label="Cat Name"
                    />
                    <TextField
                        helperText="Please enter your Location"
                        id="position"
                        label="Cat Location"
                    />
                    <TextField
                        helperText="Please enter event info"
                        id="eventInfo"
                        label="Event information"
                    />

                </Box>
                <Button variant="contained" onClick={wantingHandler} sx={{ mt: 3, ml: 1 }}>Submit</Button>
            </Container>
        </div>
    )
}

export default Wanting