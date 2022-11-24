import React from 'react'
import { FormControl, InputLabel, Input, FormHelperText, TextField, Box } from '@mui/material';

export default function AddWanting() {
    return (
        <>
            {/* <Box
                component="form"
                sx={{
                    '& .MuiTextField-root': { m: 1, width: '25ch' },
                }}
                noValidate
                autoComplete="off">
                <TextField id="outlined-basic" label="Outlined" variant="outlined" />
                <TextField id="outlined-basic" label="Outlined" variant="outlined" />
                <TextField id="outlined-basic" label="Outlined" variant="outlined" />
                <TextField id="outlined-basic" label="Outlined" variant="outlined" />
                <TextField id="outlined-basic" label="Outlined" variant="outlined" />
            </Box> */}
            <FormControl>
                <InputLabel htmlFor="my-input">Email address</InputLabel>
                <Input id="my-input" aria-describedby="my-helper-text" />
                <FormHelperText id="my-helper-text">We'll never share your email.</FormHelperText>
            </FormControl>
            <FormControl
                margin="normal"
                color="primary"
                variant="filled"
                sx={{ display: 'flex', flexDirection: 'column', justifyContent: 'space-around' }}
            >
                <TextField
                    sx={{ width: 300 }}
                    label="Name"
                    variant="filled"
                    placeholder="Name"
                />
               
                
              
            </FormControl>

        </>
    )
}
