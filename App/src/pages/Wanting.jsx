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
            Position: position.current.value,
            EventInfo: evenInfo.current.value,
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
                    <input
                        placeholder="Please enter owner name"
                        ref={ownerName}
                        type="text"
                    />
                    
                    <input
                        placeholder="Please enter your email"
                        ref={email}
                        type="text"
                    />
                    <input
                        placeholder="Please enter your cat name"
                        ref={catName}
                        type="text"
                    />
                    <input
                        placeholder="Please enter your Location"
                        ref={position}
                        type="text"
                    />
                    <input
                        placeholder="Please enter event info"
                        ref={evenInfo}
                        type="text"
                    />
                </Box>
                <Button variant="contained" color="success" onClick={wantingHandler} sx={{ mt: 3 }}>Submit</Button>
            </Container>
        </div>
    )
}

export default Wanting