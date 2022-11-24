import React from 'react';
import { useRef } from "react";
import { Divider, Typography, Input, Button, Box, Container, TextField, FormControl } from '@mui/material';
import axios from "axios";
import { useNavigate } from "react-router-dom";
import './Wanting.css';

function Wanting() {
    const ownerName = useRef("");
    const email = useRef("");
    const catName = useRef("");
    const position = useRef("");
    const evenInfo = useRef("");

    //const navigate = useNavigate();
    function wantingHandler() {
        var payload = {
            OwnerName: ownerName.current.value,
            Email: email.current.value,
            CatName: catName.current.value,
            Position: position.current.focus(),
            EventInfo: evenInfo.current.focus(),
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
        <div className='wanting'>
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
                >

                    <input style={{ width: '30ch', margin: '1rem' }}
                        placeholder="Please enter owner name"
                        ref={ownerName}
                        type="text"
                    />
                    <input style={{ width: '30ch', margin: '1rem' }}
                        placeholder="Please enter your email"
                        ref={email}
                        type="text"
                    />
                    <FormControl>
                        <TextField
                            helperText="Please enter your cat name"
                            id="catName"
                            label="Cat Name"
                            ref={catName}
                        />
                        <TextField
                            helperText="Please enter your Location"
                            id="position"
                            label="Cat Location"
                            ref={position}
                        />
                        <TextField
                            helperText="Please enter event info"
                            id="eventInfo"
                            label="Event information"
                            ref={evenInfo}
                        />
                    </FormControl>

                </Box>
                <Button variant="contained" onClick={wantingHandler} sx={{ mt: 3, ml: 1 }}>Submit</Button>
            </Container>
        </div>
    )
}

export default Wanting