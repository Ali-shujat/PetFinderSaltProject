import React from 'react';
import { useState } from "react";
import { Divider, Typography, Input, Button, Box, Container, TextField, FormControl } from '@mui/material';
import axios from "axios";
import { useNavigate } from "react-router-dom";
import './Wanting.css';
import SendIcon from '@mui/icons-material/Send';

function Wanting() {
    const [ownerName, setOwnerName] = useState('');
    const [email, setEmail] = useState('');
    const [catName, setCatName] = useState('');
    const [position, setPosition] = useState([]);
    const [eventInfo, setEventInfo] = useState('');


    //const navigate = useNavigate();
    const wantingHandler = async () => {
        try {
            const payload = {
                OwnerName: ownerName,
                Email: email,
                CatName: catName,
                Position: [90.45, 89.67],
                EventInfo: eventInfo,
            };
            console.log(payload);

            const response = await axios.post("http://localhost:5110/api/Wanting", payload);
            console.log(response);
        }
        catch (e) {
            console.log(e);
        }
    }
    return (
        <div className='wanting'>
            <Container
                variant="outlined"
                sx={{ width: 400, maxWidth: '100%', gap: 1.5 }}>
                <Typography variant="h5" color="inherit" noWrap sx={{ color: 'DarkMagenta', m: 1 }}>
                    <b>PET FINDER FORM</b>
                </Typography>

                <Box component="form"
                    sx={{
                        '& .MuiTextField-root': { m: 1, mt: 2, width: '30ch' },
                    }}
                    noValidate
                >
                    <TextField
                        id="ownerName"
                        placeholder="Please enter your name"
                        label="Owner Name"
                        value={ownerName}
                        onChange={e => setOwnerName(e.target.value)}
                    />

                    <TextField
                        label="Email"
                        placeholder="Please enter your email"
                        value={email}
                        onChange={e => setEmail(e.target.value)}
                    />
                    <TextField
                        id="catName"
                        placeholder="Please enter cat name"
                        label="cat Name"
                        value={catName}
                        onChange={e => setCatName(e.target.value)}
                    />
                    <TextField
                        label="Location"
                        placeholder="Please enter your Location"
                        value={position}
                        onChange={e => setPosition(e.target.value)}
                    />
                    <TextField
                        label="Event Information"
                        placeholder="Please enter event info"
                        minRows={3}
                        value={eventInfo}
                        onChange={e => setEventInfo(e.target.value)}
                    />
                </Box>
                <Button variant="contained" color="success" endIcon={<SendIcon />} onClick={wantingHandler} sx={{ mt: 3 }}>Submit</Button>
            </Container>
        </div>
    )
}

export default Wanting